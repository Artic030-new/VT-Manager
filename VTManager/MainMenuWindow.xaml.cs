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
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        private void hide_button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void maximize_button_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            maximize_button.Visibility = Visibility.Hidden;
            minimize_button.Visibility = Visibility.Visible;

        }
        private void minimize_button_Click(object sender, RoutedEventArgs e)
        {
            minimize_button.Visibility = Visibility.Hidden;
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            maximize_button.Visibility = Visibility.Visible;
        }
        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(0);
        }
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
                working_elements.IsEnabled = true;
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
        }
        private void rest3_button_Click(object sender, RoutedEventArgs e)
        {
            toRest(rest3_button, _DEFAULT_REST_TIME);
        }
        private void rest4_button_Click(object sender, RoutedEventArgs e)
        {
            toRest(rest4_button, _DEFAULT_REST_TIME);
        }

        private void continue_button_Click(object sender, RoutedEventArgs e)
        {

        }
        void toRest(System.Windows.Controls.Button toRestButton, int count)
        {
            togglePanel();
            sw.Stop();
            dt.Stop();
            ts = TimeSpan.FromMinutes(count);
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;
            rest_time_label.Content = String.Format(cd, ts.ToString());
            toRestButton.IsEnabled = false;
            working_elements.IsEnabled = false;
            timer.Start();
        }

    }
}