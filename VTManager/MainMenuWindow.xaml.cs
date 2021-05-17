using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using VTManager.Interactive;

namespace VTManager
{
    /// <summary>
    /// Логика взаимодействия для MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        public static Frame ThisFrame;
        public static int _DEFAULT_REST_TIME = 15;
        public static int _DEFAULT_LUNCH_TIME = 60;
        public static bool hadLunch = false;
        DispatcherTimer dt = new DispatcherTimer();
        Stopwatch sw = new Stopwatch();
        TimeSpan ts;
        string cd = "{0}";
        System.Windows.Forms.Timer timer;
        string currentTime = string.Empty;
        string currentTime2 = string.Empty;
        public static MainMenuWindow Instance { get; private set; }
        public MainMenuWindow()
        {
            InitializeComponent();
            ThisFrame = menu_frame;
            #region =========   КОМАНДЫ    =========
            CloseApplicationCmd = new VTActionCommand(OnCloseApplicationCmdExecute, CanCloseApplicationCmdExecuted);
            MaximizeApplicationCmd = new VTActionCommand(OnMaximizeApplicationCmdExecute, CanMaximizeApplicationCmdExecuted);
            MinimizeApplicationCmd = new VTActionCommand(OnMinimizeApplicationCmdExecute, CanMinimizeApplicationCmdExecuted);
            HideApplicationCmd = new VTActionCommand(OnHideApplicationCmdExecute, CanHideApplicationCmdExecuted);
            #endregion =========   КОМАНДЫ    =========
            continue_button.IsEnabled = false;
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
            this.DataContext = this;
        }

        #region =========   КОМАНДЫ    =========
        /// <summary> Завершение работы приложения </summary>
        public ICommand CloseApplicationCmd { get; }
        private void OnCloseApplicationCmdExecute(object o) => Application.Current.Shutdown(0);
        private bool CanCloseApplicationCmdExecuted(object o) => true;
        /// <summary> Развернуть приложение в полный экран </summary>
        public ICommand MaximizeApplicationCmd { get; }
        private void OnMaximizeApplicationCmdExecute(object o) {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            maximize_button.Visibility = Visibility.Hidden;
            minimize_button.Visibility = Visibility.Visible;
        }
        private bool CanMaximizeApplicationCmdExecuted(object o) => true;
        /// <summary> Свернуть приложение в оконный режим </summary>
        public ICommand MinimizeApplicationCmd { get; }
        private void OnMinimizeApplicationCmdExecute(object o)
        {
            minimize_button.Visibility = Visibility.Hidden;
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            maximize_button.Visibility = Visibility.Visible;
        }
        private bool CanMinimizeApplicationCmdExecuted(object o) => true;
        /// <summary> Сворачивание приложения </summary>
        public ICommand HideApplicationCmd { get; }
        private void OnHideApplicationCmdExecute(object o) => WindowState = WindowState.Minimized;
        private bool CanHideApplicationCmdExecuted(object o) => true;
        #endregion =========   КОМАНДЫ    =========
        private void processing_button_Click(object sender, RoutedEventArgs e)
        {
            menu_frame.Visibility = Visibility.Visible;
            menu_frame.NavigationService.Navigate(new Uri("ProcessingPage.xaml", UriKind.Relative));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            menu_frame.Visibility = Visibility.Visible;
            menu_frame.NavigationService.Navigate(new Uri("ClientPage.xaml", UriKind.Relative));
        }
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            menu_frame.Visibility = Visibility.Visible;
            menu_frame.NavigationService.Navigate(new Uri("DeliveryPage.xaml", UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            menu_frame.Visibility = Visibility.Visible;
            menu_frame.NavigationService.Navigate(new Uri("ProductionPage.xaml", UriKind.Relative));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sw.Start();
            dt.Start();
            user_info_textbox.Text += AuthWindow.loginUsr + "!";
        }

        void dt_Tick(object sender, EventArgs e)
        {
            if (sw.IsRunning)
            {
                TimeSpan ts = sw.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                current_time_label.Content = currentTime;
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            ts = ts.Add(TimeSpan.FromSeconds(-1));
            rest_time_label.Content = String.Format(cd, ts.ToString());

            if (ts == TimeSpan.Zero)
            {
                togglePanel();
                sw.Start();
                dt.Start();
                timer.Stop();
                timer.Dispose();
                timer = null;
                toggleWorkingElements();
                rest_time_label.Content = "00:00:00";
            }

        }

        void togglePanel()
        {
            if (processing_button.IsEnabled || vt_button.IsEnabled || delivery_button.IsEnabled || clients_button.IsEnabled)
            {
                processing_button.IsEnabled = false;
                vt_button.IsEnabled = false;
                delivery_button.IsEnabled = false;
                clients_button.IsEnabled = false;
                processing_button.Opacity = 0.3;
                clients_button.Opacity = 0.3;
                vt_button.Opacity = 0.3;
                delivery_button.Opacity = 0.3;
            }
            else
            {
                processing_button.IsEnabled = true;
                vt_button.IsEnabled = true;
                delivery_button.IsEnabled = true;
                clients_button.IsEnabled = true;
                processing_button.Opacity = 1.0;
                clients_button.Opacity = 1.0;
                vt_button.Opacity = 1.0;
                delivery_button.Opacity = 1.0;
            }
        }
        private void rest1_button_Click(object sender, RoutedEventArgs e)
        {
            toRest(rest1_button, _DEFAULT_REST_TIME);
        }
        private void rest2_button_Click(object sender, RoutedEventArgs e)
        {
            toRest(rest2_button, _DEFAULT_LUNCH_TIME);
            hadLunch = true;
        }

        private void continue_button_Click(object sender, RoutedEventArgs e)
        {
            togglePanel();
            sw.Start();
            dt.Start();
            timer.Stop();
            timer.Dispose();
            rest_time_label.Content = "00:00:00";
            toggleWorkingElements();
            continue_button.IsEnabled = false;
        }
        void toRest(System.Windows.Controls.Button toRestButton, int count)
        {
            togglePanel();
            sw.Stop();
            dt.Stop();
            continue_button.IsEnabled = true;
            ts = TimeSpan.FromMinutes(count);
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;
            rest_time_label.Content = String.Format(cd, ts.ToString());
            toggleWorkingElements();
            timer.Start();
        }

        void toggleWorkingElements() {
            if (rest1_button.IsEnabled || rest2_button.IsEnabled)
            {
                rest1_button.IsEnabled = false;
                rest2_button.IsEnabled = false;
            }
            else {
                rest1_button.IsEnabled = true;
                if(!hadLunch) rest2_button.IsEnabled = true;
            }
        }

     
    }
}