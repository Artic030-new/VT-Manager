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
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using WpfApp1.Utils;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public static Window ThisWindow;
        public AuthWindow()
        {
            InitializeComponent();
            ThisWindow = this;
        }
        private void login_button_Click(object sender, RoutedEventArgs e)
        {
            string loginUsr = login_field.Text;
            string passUsr = password_field.Password;
            WebUtils.login(loginUsr, passUsr);
            if ((bool)keep.IsChecked)
                DataStreamUtils.writeData(loginUsr, passUsr, keep.IsChecked.ToString());
        }
        private void header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(VTManagerConfig.config);
            if (!di.Exists)
            {
                di.Create();
                if (!(File.Exists(VTManagerConfig.config + VTManagerConfig.config_file)))
                {
                    FileStream fstream = new FileStream(VTManagerConfig.config + VTManagerConfig.config_file, FileMode.Create);
                }
            }
            header_label.Content = "VT Manager";
            using (var reader = new StreamReader(VTManagerConfig.config + VTManagerConfig.config_file))
            {
                login_field.Text = reader.ReadLine();
                password_field.Password = Encoding.UTF8.GetString(Convert.FromBase64String(reader.ReadLine()));
                if (reader.ReadLine() == "True")
                    keep.IsChecked = true;
                else if (!((bool)keep.IsChecked))
                {
                    DataStreamUtils.deactivateKeep();
                }
            }
        }
        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void hide_button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            if (!((bool)keep.IsChecked))
                DataStreamUtils.deactivateKeep();
        }
    }
}
