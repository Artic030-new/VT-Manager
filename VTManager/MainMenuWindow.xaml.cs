using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
using VTManager.Utils;

namespace VTManager
{
    /// <summary>
    /// Логика взаимодействия для MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        public static Frame ThisFrame;
        public static Window ThisWindow;
        private static VTQuery query = new VTQuery();
        //Буфер результатов запросов
        private static Label l1 = new Label(), l2 = new Label(), l3 = new Label();
        /// <summary>
        /// === Фиксирование времени ===
        /// </summary> ///
        DispatcherTimer dt = new DispatcherTimer();
        Stopwatch sw = new Stopwatch();
        TimeSpan ts;
        string cd = "{0}";
        System.Windows.Forms.Timer timer;
        // Текущее отработанное время, выведенное на экране
        public static string currentTime = string.Empty;
        // Текущее время отдыха, выведенное на экране
        public static string currentTimeRest = string.Empty;
        // Определяет максимальное время отдыха, в зависимости от типа (ОБЕД, ОТДЫХ)
        public static double maxUnitTime = .0D;
        // Время отдыха по умолчанию (мин)
        public static int _DEFAULT_REST_TIME = 15;
        // Время обеда по умолчанию (мин)
        public static int _DEFAULT_LUNCH_TIME = 60;
        // Определяет обедал ли сотрудник в данный рабочий день
        public static bool hadLunch = false;
        // Накопитель времени отдыха
        public static TimeSpan timeRestCollector;
        // Временные показатели сотрудника за текущую сессию (смену)
        public static string sessionWorkTime = string.Empty;
        public static string sessionRestTime = string.Empty;
        public static MainMenuWindow Instance { get; private set; }
        public MainMenuWindow()
        {
            InitializeComponent();
            ThisFrame = menu_frame;
            ThisWindow = this;
            addSqlTime();
            #region =========   КОМАНДЫ    =========
            CloseApplicationCmd = new VTActionCommand(OnCloseApplicationCmdExecute, CanCloseApplicationCmdExecuted);
            MaximizeApplicationCmd = new VTActionCommand(OnMaximizeApplicationCmdExecute, CanMaximizeApplicationCmdExecuted);
            MinimizeApplicationCmd = new VTActionCommand(OnMinimizeApplicationCmdExecute, CanMinimizeApplicationCmdExecuted);
            HideApplicationCmd = new VTActionCommand(OnHideApplicationCmdExecute, CanHideApplicationCmdExecuted);
            DragApplicationCmd = new VTActionCommand(OnDragApplicationCmdExecute, CanDragApplicationCmdExecuted);
            ToProcessingCmd = new VTActionCommand(OnToProcessingCmdExecute, CanToProcessingCmdExecuted);
            ToClientsCmd = new VTActionCommand(OnToClientsCmdExecute, CanToClientsCmdExecuted);
            ToDeliveryCmd = new VTActionCommand(OnToDeliveryCmdExecute, CanToDeliveryCmdExecuted);
            ToProductionCmd = new VTActionCommand(OnToProductionCmdExecute, CanToProductionCmdExecuted);
            ToRestCmd = new VTActionCommand(OnToRestCmdExecute, CanToRestCmdExecuted);
            ToLunchCmd = new VTActionCommand(OnToLunchCmdExecute, CanToLunchCmdExecuted);
            ResumeCmd = new VTActionCommand(OnResumeCmdExecute, CanResumeCmdExecuted);
            #endregion =========   КОМАНДЫ    =========
            continue_button.IsEnabled = false;
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
            this.DataContext = this;
        }
        #region =========   КОМАНДЫ    =========
        /// <summary> Завершение работы приложения </summary>
        public ICommand CloseApplicationCmd { get; }
        private bool CanCloseApplicationCmdExecuted(object o) => true;
        private void OnCloseApplicationCmdExecute(object o)  { keepTime(); Application.Current.Shutdown(0); }
        /// <summary> Развернуть приложение в полный экран </summary>
        public ICommand MaximizeApplicationCmd { get; }
        private bool CanMaximizeApplicationCmdExecuted(object o) => true;
        private void OnMaximizeApplicationCmdExecute(object o) {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            maximize_button.Visibility = Visibility.Hidden;
            minimize_button.Visibility = Visibility.Visible;
        }
        
        /// <summary> Свернуть приложение в оконный режим </summary>
        public ICommand MinimizeApplicationCmd { get; }
        private bool CanMinimizeApplicationCmdExecuted(object o) => true;
        private void OnMinimizeApplicationCmdExecute(object o)
        {
            minimize_button.Visibility = Visibility.Hidden;
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            maximize_button.Visibility = Visibility.Visible;
        }
        /// <summary> Сворачивание приложения </summary>
        public ICommand HideApplicationCmd { get; }
        private bool CanHideApplicationCmdExecuted(object o) => true;
        private void OnHideApplicationCmdExecute(object o) => WindowState = WindowState.Minimized;
        /// <summary> Перемещение окна </summary>
        public ICommand DragApplicationCmd { get; }
        private bool CanDragApplicationCmdExecuted(object o) => true;
        private void OnDragApplicationCmdExecute(object o) => this.DragMove();
        /// <summary> В раздел Производство </summary>
        public ICommand ToProcessingCmd { get; }
        private bool CanToProcessingCmdExecuted(object o) => true;
        private void OnToProcessingCmdExecute(object o) {
            menu_frame.Visibility = Visibility.Visible;
            menu_frame.NavigationService.Navigate(new Uri("ProcessingPage.xaml", UriKind.Relative));
        }
        /// <summary> В раздел Работа с клиентами </summary>
        public ICommand ToClientsCmd { get; }
        private bool CanToClientsCmdExecuted(object o) => true;
        private void OnToClientsCmdExecute(object o)
        {
            menu_frame.Visibility = Visibility.Visible;
            menu_frame.NavigationService.Navigate(new Uri("ClientPage.xaml", UriKind.Relative));
        }
        /// <summary> В раздел Поставки </summary>
        public ICommand ToDeliveryCmd { get; }
        private bool CanToDeliveryCmdExecuted(object o) => true;
        private void OnToDeliveryCmdExecute(object o)
        {
            menu_frame.Visibility = Visibility.Visible;
            menu_frame.NavigationService.Navigate(new Uri("DeliveryPage.xaml", UriKind.Relative));
        }
        /// <summary> В раздел Готовая продукция </summary>
        public ICommand ToProductionCmd { get; }
        private bool CanToProductionCmdExecuted(object o) => true;
        private void OnToProductionCmdExecute(object o)
        {
            menu_frame.Visibility = Visibility.Visible;
            menu_frame.NavigationService.Navigate(new Uri("ProductionPage.xaml", UriKind.Relative));
        }
        /// <summary> Взять перерыв </summary>
        public ICommand ToRestCmd { get; }
        private bool CanToRestCmdExecuted(object o) => true;
        private void OnToRestCmdExecute(object o) => toRest(rest1_button, _DEFAULT_REST_TIME);
        /// <summary> Взять обед </summary>
        public ICommand ToLunchCmd { get; }
        private bool CanToLunchCmdExecuted(object o) => true;
        private void OnToLunchCmdExecute(object o) { toRest(rest2_button, _DEFAULT_LUNCH_TIME); hadLunch = true; /*После установки данного флага уйти в обед повторно невозможно*/ }
        /// <summary> Продолжить работу, разблокировать рабочую область и зафиксировать время отсутствия </summary>
        public ICommand ResumeCmd { get; }
        private bool CanResumeCmdExecuted(object o) => true;
        private void OnResumeCmdExecute(object o) {
            togglePanel();
            sw.Start();
            dt.Start();
            timer.Stop();
            timer.Dispose();
            currentTimeRest = rest_time_label.Content.ToString();
            if (DateTime.TryParseExact(currentTimeRest, "HH:mm:ss", null, DateTimeStyles.None, out _))
            {
                TimeSpan ts2 = TimeSpan.FromMinutes(maxUnitTime);
                ///<summary> Получить разницу между максимальным временем перерыва (15 или 60) и оставшемся 
                ///Пример: Сотрудник отошёл на 7 минут и 30 секунд, затем продолжил работу => (00:15:00 - 00:12:30) = 00:07:30  </summary>
                TimeSpan currentTime = -(ts - ts2);
                // Прибавить к накопителю зафиксированное время
                timeRestCollector += currentTime;
            }
            else return;
            rest_time_label.Content = "00:00:00";
            toggleWorkingElements();
            continue_button.IsEnabled = false;
        }
        #endregion =========   КОМАНДЫ    =========
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sw.Start();
            dt.Start();
            user_info_textbox.Text += AuthWindow.loginUsr + "!";
        }
        void dt_Tick(object sender, EventArgs e)
        { ///<summary> Отображает текущее время работы в правой панели главного меню </summary>///
            if (sw.IsRunning)
            {
                TimeSpan ts = sw.Elapsed;
                parseSqlTime(sessionWorkTime, ref ts);
                currentTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                current_time_label.Content = currentTime;
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        { ///<summary> Отображает отчёт времени перерыва в правой панели главного меню </summary>///
            ts = ts.Add(TimeSpan.FromSeconds(-1));
            rest_time_label.Content = String.Format(cd, ts.ToString());
            if (ts == TimeSpan.Zero)
            { // Приостановить ход рабочего времени и заблокировать рабочие элементы пока время перерыва не иссякло
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
        /// <summary> Выйти в перерыв, заблокировав рабочую область и запустить отчёт времени перерыва </summary> 
        void toRest(System.Windows.Controls.Button toRestButton, int count)
        {
            togglePanel();
            sw.Stop();
            dt.Stop();
            continue_button.IsEnabled = true;
            parseSqlTime(sessionRestTime, ref timeRestCollector);
            ts = TimeSpan.FromMinutes(count);
            maxUnitTime = count;
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
            else 
            {
                rest1_button.IsEnabled = true;
                if(!hadLunch) rest2_button.IsEnabled = true;
            }
        }
        void keepTime()
        {
            //Получить строку текущей даты в типичном для mysql базы данных формате
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            try // Выбрать последнюю сессию рабочего времени и перерыва сотрудника, если получится
            { 
                string selectUserId = query.select("id", "id", "personal", "login = \"" + AuthWindow.loginUsr + "\"");
                SQLUtils.runQuery(selectUserId, "id", l1);
                if (l1.Content.ToString().Length > 0)
                {
                    string selectLastUserSessionId = query.select("id", "id", "sessions", "personalId = " + l1.Content.ToString().Trim() + " ORDER BY id DESC LIMIT 1");
                    string selectLastUserSessionDate = query.select("date", "date", "sessions", "personalId = " + l1.Content.ToString().Trim() + " ORDER BY id DESC LIMIT 1");
                    SQLUtils.runQuery(selectLastUserSessionId, "id", l2);
                    SQLUtils.runQuery(selectLastUserSessionDate, "date", l3);
                    if (l2.Content.ToString().Length > 0) //Подготовить текущую дату в формате mysql, если выбранный сотрудник найден
                    {
                        string updateLastUserSessionDate = query.update("sessions", "workTime = \'" + currentTime.Substring(0, 8).Trim() + "\'", "sessions.id = " + l2.Content.ToString().Trim());
                        string updateLastUserSessionDate2 = query.update("sessions", "restTime = \'" + timeRestCollector.ToString().Trim() + "\'", "sessions.id = " + l2.Content.ToString().Trim());
                        DateTime datesql = DateTime.ParseExact(l3.Content.ToString().Substring(0, 10).Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
                        if (date.ToString().Equals(datesql.ToString("yyyy-MM-dd").Substring(0, 10).Trim()))
                        { // Выполнить запросы на обновление сессии рабочего времени, если дата запуска приложения сегодняшняя
                            SQLUtils.runQuery(updateLastUserSessionDate);
                            SQLUtils.runQuery(updateLastUserSessionDate2);
                        }
                        else
                        { // Выполнить запросы на добавление новой сесии, если дата запуска приложения отличается от сегодняшней (Вчерашняя и т.д. сессия)
                            string insertSession = "INSERT INTO sessions (id, personalId, sip, date, workTime, restTime)";
                            //Получить IP-адрес компьютера сотрудника
                            string ip = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[0].ToString();
                            string sessionValues = "VALUES (NULL, \"" + l1.Content.ToString().Trim() + "\", \'" + ip + "\', " + "\'" + date + "\'" + ", \'" + currentTime.Substring(0, 8).Trim() + "\', \'" + timeRestCollector.ToString().Trim() + "\')";
                            SQLUtils.runQuery(insertSession + sessionValues);
                        }
                    }
                }
            } catch(Exception e) { // Вставить новую сессию для сотрудника, если он не был найден
                string insertSession = "INSERT INTO sessions (id, personalId, sip, date, workTime, restTime)";
                //Получить IP-адрес компьютера сотрудника
                string ip = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[0].ToString();
                string sessionValues = "VALUES (NULL, \"" + l1.Content.ToString().Trim() + "\", \'" + ip + "\', " + "\'"+ date + "\'" + ", \'" + currentTime.Substring(0, 8).Trim() + "\', \'" + timeRestCollector.ToString().Trim() + "\')";
                SQLUtils.runQuery(insertSession + sessionValues);
            } 
        }
        public static void parseSqlTime(String timeStamp, ref TimeSpan timer)
        {   // Разбивает данные в виде полученного времени работы сотрудника на часы, минуты и секунды, и добавляет их к текущему таймеру
            String[] workSess = timeStamp.Split(':');
            int sessWrHr = Convert.ToInt32(workSess[0].ElementAt(0) == '0' ? workSess[0].ElementAt(1).ToString() : workSess[0]);
            int sessWrMin = Convert.ToInt32(workSess[1].ElementAt(0) == '0' ? workSess[1].ElementAt(1).ToString() : workSess[1]);
            int sessWrSec = Convert.ToInt32(workSess[2].ElementAt(0) == '0' ? workSess[2].ElementAt(1).ToString() : workSess[2]);
            timer = timer.Add(TimeSpan.FromHours(sessWrHr)); 
            timer = timer.Add(TimeSpan.FromMinutes(sessWrMin));
            timer = timer.Add(TimeSpan.FromSeconds(sessWrSec));
        }
        public static void addSqlTime() {
            try
            { //  Получить время последней сессии сотрудника и добавить к таймеру (продолжение при случайном или намеренном закрытии программы)
                string selectUserId = query.select("id", "id", "personal", "login = \"" + AuthWindow.loginUsr + "\"");
                SQLUtils.runQuery(selectUserId, "id", l1);
                string selectLastUserWt = query.select("workTime", "wt", "sessions", "personalId = " + l1.Content.ToString().Trim() + " ORDER BY id DESC LIMIT 1");
                string selectLastUserRt = query.select("restTime", "rt", "sessions", "personalId = " + l1.Content.ToString().Trim() + " ORDER BY id DESC LIMIT 1");
                SQLUtils.runQuery(selectLastUserWt, "wt", l2);
                SQLUtils.runQuery(selectLastUserRt, "rt", l3);
                sessionWorkTime = l2.Content.ToString();
                sessionRestTime = l3.Content.ToString();
                l1.Content = string.Empty; l2.Content = string.Empty; l3.Content = string.Empty;
            }
            catch (Exception) {  /*Some problems*/  }
        }
    }
}