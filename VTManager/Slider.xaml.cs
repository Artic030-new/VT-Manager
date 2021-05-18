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

namespace VTManager
{
    /// <summary>
    /// Логика взаимодействия для Slider.xaml
    /// </summary>
    public partial class Slider : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Slider()
        {
            InitializeComponent();
            #region =========   КОМАНДЫ    =========
            UnloginCmd = new VTActionCommand(OnUnloginCmdExecute, CanUnloginCmdExecuted);
            OpenConfDirCmd = new VTActionCommand(OnOpenConfDirCmdExecute, CanOpenConfDirCmdExecuted);
            SaveStandartsCmd = new VTActionCommand(OnSaveStandartsExecute, CanSaveStandartsExecuted);
            #endregion =========   КОМАНДЫ    =========
            this.DataContext = this;
        }
        #region =========   КОМАНДЫ    =========
        /// <summary> Завершение работы приложения </summary>
        public ICommand UnloginCmd { get; }
        private void OnUnloginCmdExecute(object o) {
            DataStreamUtils.writeData(AuthWindow.loginUsr, "", "False");
            MainMenuWindow.ThisWindow.Close();
            AuthWindow aw = new AuthWindow();
            aw.Show();
        }
        private bool CanUnloginCmdExecuted(object o) => true;
        /// <summary> Открыть папку конфигурации </summary>
        public ICommand OpenConfDirCmd { get; }
        private void OnOpenConfDirCmdExecute(object o) => Process.Start(VTManagerConfig.config);
        private bool CanOpenConfDirCmdExecuted(object o) => true;



        /// <summary> Сохранить нормативную информацию по сырью в БД </summary>
        public ICommand SaveStandartsCmd { get; }
        private void OnSaveStandartsExecute(object o) {
         //   loss_value.Text = VTManagerConfig.xmldata.Element("VTStandarts").Value;
            //    VTManagerConfig.xmldata.Element("VTStandarts").SetAttributeValue("lossRatio", "999,349577464111");

       
              


            XDocument t = XDocument.Load(VTManagerConfig.config + VTManagerConfig.db_config_file);


            t.Root.Element("VTStandarts").Element("lossRatio").SetValue(loss_value.Text);


            t.Save(VTManagerConfig.config + VTManagerConfig.db_config_file);


            //  xml.Save(VTManagerConfig.config + VTManagerConfig.db_config_file);
            /*  VTManagerConfig.xmldata.Descendants("sandCost").First().Value = SandCost;
              VTManagerConfig.xmldata.Descendants("steelCost").First().Value = SteelCost;*/
            // Application.Current.Shutdown();
            /*    VTManagerConfig.xmldata.Descendants("siliconeCost").First().Value; 
                VTManagerConfig.xmldata.Descendants("steelCost").First().Value;
                VTManagerConfig.xmldata.Descendants("orcglassCost").First().Value;
                VTManagerConfig.xmldata.Descendants("ptpfCost").First().Value;*/
        }
        private bool CanSaveStandartsExecuted(object o) => true;
        #endregion =========   КОМАНДЫ    =========
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #region =========   ПАРАМЕТРЫ   =========

        private int _timeout;
        public int Timeout { get { _timeout = Convert.ToInt32(VTManagerConfig.xmldata.Descendants("callTimeout").First().Value); return _timeout; } }

        private string _lossRatio;
        public string LossRatio { 
            get { _lossRatio = VTManagerConfig.xmldata.Descendants("lossRatio").First().Value; return _lossRatio; }
        }

        private string _sandCost;
        public string SandCost { get { _sandCost = VTManagerConfig.xmldata.Descendants("sandCost").First().Value; return _sandCost; } }
        private string _siliconeCost;
        public string SiliconeCost { get { _siliconeCost = VTManagerConfig.xmldata.Descendants("siliconeCost").First().Value; return _siliconeCost; } }
        private string _steelCost;
        public string SteelCost { 
            get { _steelCost = VTManagerConfig.xmldata.Descendants("steelCost").First().Value; return _steelCost; }
        }
        #endregion =========   ПАРАМЕТРЫ   =========
    }
    
}

