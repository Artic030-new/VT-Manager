using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            this.DataContext = this;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #region ПАРАМЕТРЫ

        private List<string> items;
        public List<string> Items
        {
            get
            {
                items = new List<string> { 
                    VTManagerConfig.xmldata.Descendants("lossRatio").First().Value,
                    VTManagerConfig.xmldata.Descendants("sandCost").First().Value,
                    VTManagerConfig.xmldata.Descendants("siliconeCost").First().Value,
                    VTManagerConfig.xmldata.Descendants("steelCost").First().Value,
                    VTManagerConfig.xmldata.Descendants("orcglassCost").First().Value,
                    VTManagerConfig.xmldata.Descendants("ptpfCost").First().Value,
                };
                return items;
            }
        }
        #endregion
    }

}

