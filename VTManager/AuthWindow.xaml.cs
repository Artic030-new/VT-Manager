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
using System.Threading;
using VTManager.Utils;

namespace VTManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public static Window ThisWindow;
        public static VTManagerDialog error_msg = new VTManagerDialog();
        public static string loginUsr;
        public static string passUsr;
        Mutex mutex = new Mutex(false, "VTManager");
        public AuthWindow() {
            InitializeComponent();
            ThisWindow = this;   
        }
        private void login_button_Click(object sender, RoutedEventArgs e)
        {
            loginUsr = login_field.Text;
            passUsr = password_field.Password;
            WebUtils.login(loginUsr, passUsr);
            if ((bool)keep.IsChecked)
                DataStreamUtils.writeData(loginUsr, passUsr, keep.IsChecked.ToString());
        }
        private void header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) { this.DragMove(); }
        private void Window_Activated(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(VTManagerConfig.config);
            FileStream fstream;
            if (!di.Exists) {
                di.Create();
                if (!(File.Exists(VTManagerConfig.config + VTManagerConfig.config_file))) 
                    fstream = new FileStream(VTManagerConfig.config + VTManagerConfig.config_file, FileMode.Create);   
            }
            else {
                using (var reader = new StreamReader(VTManagerConfig.config + VTManagerConfig.config_file)) {
                    login_field.Text = reader.ReadLine();
                    password_field.Password = Encoding.UTF8.GetString(Convert.FromBase64String(reader.ReadLine()));
                    if (reader.ReadLine() == "True")
                        keep.IsChecked = true;
                    else if (!((bool)keep.IsChecked)) 
                        DataStreamUtils.deactivateKeep();
                }
            }
            header_label.Content = "VT Manager";   
        }
        private void close_button_Click(object sender, RoutedEventArgs e) { Application.Current.Shutdown(0); }
        private void hide_button_Click(object sender, RoutedEventArgs e) { WindowState = WindowState.Minimized; }
        private void Window_Closed(object sender, EventArgs e)
        {
            if (!((bool)keep.IsChecked))
                DataStreamUtils.deactivateKeep();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!mutex.WaitOne(500, false)) {
                this.Close();
                error_msg.dialog_label.Content = "Ошибка";
                error_msg.contained_info.Text = "Приложение уже запущено";
                error_msg.Show();
                Thread.Sleep(3000);
                Application.Current.Shutdown(0);
            }
        }
    }
}
