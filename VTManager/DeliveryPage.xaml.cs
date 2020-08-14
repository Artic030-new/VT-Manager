using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для DeliveryPage.xaml
    /// </summary>
    public partial class DeliveryPage : Page
    {
        public static Frame ThisFrame;
        public DeliveryPage()
        {
            InitializeComponent();
            ThisFrame = item_frame;
            /*Таймер. Обновляет страницу каждые 2 минуты*/
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 120000;
            timer1.Tick += t_Tick;
            timer1.Enabled = true;
        }
        static void navigate(string uri)
        {
            removeMainComponents();
            ThisFrame.Visibility = Visibility.Visible;
            ThisFrame.NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }
        static void removeMainComponents()
        {
            /*удаляет элементы при переходе с главной стр*/
        }
        private void home_MouseDown(object sender, MouseButtonEventArgs e)
        {
            removeMainComponents();
            item_frame.Visibility = Visibility.Hidden;
            MainMenuWindow.ThisFrame.Visibility = Visibility.Hidden;
        }
        private void refresh_MouseDown(object sender, MouseButtonEventArgs e)
        {
            item_frame.Refresh();
        }
        private void t_Tick(object sender, EventArgs e)
        {
            item_frame.Refresh();
        }
        private void item1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            navigate("DeliveryPages/Delivery_Providers.xaml");
        }
        private void item2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            navigate("DeliveryPages/Delivery_Deliveries.xaml");
        }
        private void item3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            navigate("DeliveryPages/Delivery_Add.xaml");
        }
    }
}