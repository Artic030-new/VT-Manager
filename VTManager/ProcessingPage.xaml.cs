using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VTManager;
using VTManager.Interactive;

namespace VTManager
{
    public partial class ProcessingPage : Page, IVTPage
    {
        public static Frame ThisFrame;
        public ProcessingPage()
        {
            InitializeComponent();
            ThisFrame = item_frame;
            /*Таймер. Обновляет страницу каждые 2 минуты*/
            refresh();

        }
        public void refresh()
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 120000;
            timer1.Tick += t_Tick;
            timer1.Enabled = true;
        }
        public void navigate(string uri) 
        {
            removeMainComponents();
            ThisFrame.Visibility = Visibility.Visible;
            ThisFrame.NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }
        public static void removeMainComponents()
        {
            /*удаляет элементы при переходе с главной стр**/
        }
        private void item1_MouseDown(object sender, MouseButtonEventArgs e)
        {
           navigate("ProcessingPages/Processing_Search.xaml");
        }
        private void item2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            navigate("ProcessingPages/Processing_Charts.xaml");
        }
        private void item3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            navigate("ProcessingPages/Processing_Resources.xaml");
        }
        private void item4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            navigate("ProcessingPages/Processing_Add.xaml");
        }
        private void refresh_label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            item_frame.Refresh();
        }
        private void t_Tick(object sender, EventArgs e)
        {
            item_frame.Refresh();
        }
        private void home_MouseDown(object sender, MouseButtonEventArgs e)
        {
            removeMainComponents();
            item_frame.Visibility = Visibility.Hidden;
            MainMenuWindow.ThisFrame.Visibility = Visibility.Hidden;
        }
    }
}

