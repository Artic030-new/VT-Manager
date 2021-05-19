using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Xml;
using System.Xml.Linq;
using VTManager.Interactive;
using VTManager.Utils;

namespace VTManager
{
    /// <summary>
    /// Логика взаимодействия для Slider.xaml
    /// </summary>
    public partial class Slider : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private static VTQuery query = new VTQuery();
        public Slider() {
            InitializeComponent();
            #region =========   КОМАНДЫ    =========
            UnloginCmd = new VTActionCommand(OnUnloginCmdExecute, CanUnloginCmdExecuted);
            OpenConfDirCmd = new VTActionCommand(OnOpenConfDirCmdExecute, CanOpenConfDirCmdExecuted);
            SaveStandartsCmd = new VTActionCommand(OnSaveStandartsExecute, CanSaveStandartsExecuted);
            CheckConnectCmd = new VTActionCommand(OnCheckConnectCmdExecute, CanCheckConnectCmdExecuted);
            #endregion =========   КОМАНДЫ    =========

            #region =========   ПАРАМЕТРЫ   =========
            LossRatio = VTManagerConfig.xmldata.Descendants("lossRatio").First().Value; 
            SandCost = VTManagerConfig.xmldata.Descendants("sandCost").First().Value;
            SiliconeCost = VTManagerConfig.xmldata.Descendants("siliconeCost").First().Value;
            SteelCost = VTManagerConfig.xmldata.Descendants("steelCost").First().Value;
            OrcglassCost = VTManagerConfig.xmldata.Descendants("orcglassCost").First().Value;
            PtpfCost = VTManagerConfig.xmldata.Descendants("ptpfCost").First().Value;
            Timeout = Convert.ToInt32(VTManagerConfig.xmldata.Descendants("callTimeout").First().Value);

            #endregion =========   ПАРАМЕТРЫ   =========
            this.DataContext = this;
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #region =========   КОМАНДЫ    =========
        /// <summary> Завершение работы приложения </summary>
        public ICommand UnloginCmd { get; }
        private bool CanUnloginCmdExecuted(object o) => true;
        private void OnUnloginCmdExecute(object o) {
            DataStreamUtils.writeData(AuthWindow.loginUsr, "", "False");
            MainMenuWindow.ThisWindow.Close();
            AuthWindow aw = new AuthWindow();
            aw.Show();
        }
        /// <summary> Открыть папку конфигурации </summary>
        public ICommand OpenConfDirCmd { get; }
        private bool CanOpenConfDirCmdExecuted(object o) => true;
        private void OnOpenConfDirCmdExecute(object o) => Process.Start(VTManagerConfig.config);
        /// <summary> Сохранить нормативную информацию по сырью в БД и конфиг </summary>
        public ICommand SaveStandartsCmd { get; }
        private bool CanSaveStandartsExecuted(object o) => true;
        private void OnSaveStandartsExecute(object o) {
            XDocument t = XDocument.Load(VTManagerConfig.config + VTManagerConfig.db_config_file);
            t.Root.Element("VTStandarts").Element("lossRatio").SetValue(LossRatio);
            t.Root.Element("VTStandarts").Element("sandCost").SetValue(SandCost);
            t.Root.Element("VTStandarts").Element("siliconeCost").SetValue(SiliconeCost);
            t.Root.Element("VTStandarts").Element("steelCost").SetValue(SteelCost);
            t.Root.Element("VTStandarts").Element("orcglassCost").SetValue(OrcglassCost);
            t.Root.Element("VTStandarts").Element("ptpfCost").SetValue(PtpfCost);
            t.Root.Element("VTSettings").Element("callTimeout").SetValue(Timeout);
            updateStats();
            t.Save(VTManagerConfig.config + VTManagerConfig.db_config_file);
        }
        /// <summary> Проверить соединение с сервером  </summary>
        public ICommand CheckConnectCmd { get; }
        private bool CanCheckConnectCmdExecuted(object o) => true;
        private void OnCheckConnectCmdExecute(object o) {
            try {
                SQLUtils.ping();
                new VTManagerDialog(Messages._OK_MESSAGE, Messages._CONNECTION_IS_DONE);
            } catch (Exception) {
                new VTManagerDialog(Messages._ERROR_MESSAGE, Messages._CONNECTION_IS_LOST);
            }
        }
        #endregion =========   КОМАНДЫ    =========

        #region =========   ПАРАМЕТРЫ   =========
        public string LossRatio { get; set; }
        public string SandCost { get; set; }
        public string SiliconeCost { get; set; }
        public string SteelCost { get; set; }
        public string OrcglassCost { get; set; }
        public string PtpfCost { get; set; }
        public int Timeout { get; set; }

        public string Text { get; set; }
        #endregion =========   ПАРАМЕТРЫ   =========

        #region =========   МЕТОДЫ   =========
        void updateStats() {
            Dictionary<Int32, String> resources = new Dictionary<Int32, String> {
                { 1, SandCost },
                { 2, SiliconeCost },
                { 9, SteelCost },
                { 4, OrcglassCost },
                { 7, PtpfCost },
            };
            foreach (var resource in resources) 
                SQLUtils.runQuery(query.update("resource", "costPerShift = " + resource.Value.Trim(new char[] { ' ', ';' }).Replace(",", "."), "resource.id = " + resource.Key + ""));
        }
        #endregion =========   МЕТОДЫ   =========

    }

}

