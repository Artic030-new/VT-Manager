﻿using MySql.Data.MySqlClient;
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
            #region =========   КОМАНДЫ    =========
            ToHomeCmd = new VTActionCommand(OnToHomeCmdExecute, CanToHomeCmdExecuted);
            RefreshCmd = new VTActionCommand(OnRefreshCmdExecute, CanRefreshCmdExecuted);
            Item1Cmd = new VTActionCommand(OnItem1CmdExecute, CanItem1CmdExecuted);
            Item2Cmd = new VTActionCommand(OnItem2CmdExecute, CanItem2CmdExecuted);
            Item3Cmd = new VTActionCommand(OnItem3CmdExecute, CanItem3CmdExecuted);
            Item4Cmd = new VTActionCommand(OnItem4CmdExecute, CanItem4CmdExecuted);
            #endregion =========   КОМАНДЫ    =========
            /*Таймер. Обновляет страницу каждые 2 минуты*/
            refresh();
            this.DataContext = this;

        }
        #region =========   КОМАНДЫ    =========
        /// <summary> Возврат в главное меню </summary>
        public ICommand ToHomeCmd { get; }
        private bool CanToHomeCmdExecuted(object o) => true;
        private void OnToHomeCmdExecute(object o)
        {
            removeMainComponents();
            item_frame.Visibility = Visibility.Hidden;
            MainMenuWindow.ThisFrame.Visibility = Visibility.Hidden;
        }
        /// <summary> Обновить страницу </summary>
        public ICommand RefreshCmd { get; }
        private bool CanRefreshCmdExecuted(object o) => true;
        private void OnRefreshCmdExecute(object o) => item_frame.Refresh();
        /// <summary> К разделу 1 </summary>
        public ICommand Item1Cmd { get; }
        private bool CanItem1CmdExecuted(object o) => true;
        private void OnItem1CmdExecute(object o) => navigate("ProcessingPages/Processing_Search.xaml");
        /// <summary> К разделу 2 </summary>
        public ICommand Item2Cmd { get; }
        private bool CanItem2CmdExecuted(object o) => true;
        private void OnItem2CmdExecute(object o) => navigate("ProcessingPages/Processing_Charts.xaml");
        /// <summary> К разделу 3 </summary>
        public ICommand Item3Cmd { get; }
        private bool CanItem3CmdExecuted(object o) => true;
        private void OnItem3CmdExecute(object o) => navigate("ProcessingPages/Processing_Resources.xaml");
        /// <summary> К разделу 4 </summary>
        public ICommand Item4Cmd { get; }
        private bool CanItem4CmdExecuted(object o) => true;
        private void OnItem4CmdExecute(object o) => navigate("ProcessingPages/Processing_Add.xaml");
        #endregion =========   КОМАНДЫ    =========

        private void t_Tick(object sender, EventArgs e) => item_frame.Refresh();
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
    }
}

