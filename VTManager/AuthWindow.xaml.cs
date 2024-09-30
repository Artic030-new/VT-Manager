using System;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.IO;
using System.Threading;
using VTManager.Utils;
using VTManager.Interactive;
using VTManager.ViewModels;
using System.Runtime.Remoting.Contexts;

namespace VTManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public static Window ThisWindow;
        public static string loginUsr;
        public static string passUsr;

        private AuthWindowVM context;

        private VTManagerConfig config;
        
        Mutex mutex = new Mutex(false, "VTManager");
        public AuthWindow() {
            InitializeComponent();
            config = VTManagerConfig.CreateConfig();
            if ()
            context = new AuthWindowVM
            {
                KeepEntry = 
            }
            ThisWindow = this;
            #region =========   КОМАНДЫ    =========
            CloseApplicationCmd = new VTActionCommand(OnCloseApplicationCmdExecute, CanCloseApplicationCmdExecuted);
            HideApplicationCmd = new VTActionCommand(OnHideApplicationCmdExecute, CanHideApplicationCmdExecuted);
            DragApplicationCmd = new VTActionCommand(OnDragApplicationCmdExecute, CanDragApplicationCmdExecuted);
            LoginCmd = new VTActionCommand(OnLoginCmdExecute, CanLoginCmdExecuted);
            #endregion =========   КОМАНДЫ    =========
            this.DataContext = this;
        }

        #region =========   КОМАНДЫ    =========
        /// <summary> Завершение работы приложения </summary>
        public ICommand CloseApplicationCmd { get; }
        private bool CanCloseApplicationCmdExecuted(object o) => true;
        private void OnCloseApplicationCmdExecute(object o) => Application.Current.Shutdown(0);
        /// <summary> Сворачивание приложения </summary>
        public ICommand HideApplicationCmd { get; }
        private bool CanHideApplicationCmdExecuted(object o) => true;
        private void OnHideApplicationCmdExecute(object o) => WindowState = WindowState.Minimized;
        /// <summary> Перемещение окна мышью </summary>
        public ICommand DragApplicationCmd { get; }
        private bool CanDragApplicationCmdExecuted(object o) => true;
        private void OnDragApplicationCmdExecute(object o) => this.DragMove();
        /// <summary> Команда авторизации сотрудника </summary>
        public ICommand LoginCmd { get; }
        private bool CanLoginCmdExecuted(object o) => true;
        private void OnLoginCmdExecute(object o) {
            loginUsr = login_field.Text;
            passUsr = password_field.Password;
            WebUtils.login(loginUsr, passUsr);
            if ((bool)keep.IsChecked) DataStreamUtils.writeData(loginUsr, passUsr, keep.IsChecked.ToString());
            else DataStreamUtils.writeData(loginUsr, "", keep.IsChecked.ToString());
            System.IO.FileInfo file = new System.IO.FileInfo(db_config_file);
            if (file.Length < 1) VTManagerConfig.xml.Save(db_config_file); 
        }
        #endregion =========   КОМАНДЫ    =========
        private void Window_Activated(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(db_config_dir);
            if (!di.Exists) {
                di.Create();   
            }
            else {
                if (!File.Exists($"{db_config_dir}{db_config_file}"))
                    new FileStream($"{db_config_dir}{db_config_file}", FileMode.Create);
                System.IO.FileInfo file = new System.IO.FileInfo($"{db_config_dir}{db_config_file}");
                if (file.Length > 1)
                {
                    using (var reader = new StreamReader($"{db_config_dir}{db_config_file}"))
                    {
                        login_field.Text = reader.ReadLine();
                        password_field.Password = Encoding.UTF8.GetString(Convert.FromBase64String(reader.ReadLine()));
                        if (reader.ReadLine() == "True")
                            keep.IsChecked = true;
                    }
                }
            }
            if (!File.Exists(db_config_file))
            {
                new FileStream(db_config_file, FileMode.Create);
            }
            header_label.Content = "VT Manager";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!mutex.WaitOne(500, false)) {
                this.Close();
                new VTManagerDialog(Messages._ERROR_MESSAGE, Messages._MUTEX_IS_DUPLICATED);
                Thread.Sleep(3000);
                Application.Current.Shutdown(0);
            }
        }
    }
}
