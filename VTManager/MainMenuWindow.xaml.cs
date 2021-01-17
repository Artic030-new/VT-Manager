using System;
using System.Collections.Generic;
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

        public static MainMenuWindow Instance { get; private set; }
        public MainMenuWindow()
        {
            InitializeComponent();
            ThisFrame = menu_frame;
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
            user_info_textbox.Text += AuthWindow.loginUsr + "!";
        }
    }
}
