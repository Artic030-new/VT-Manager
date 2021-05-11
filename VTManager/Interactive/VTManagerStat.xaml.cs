using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace VTManager.Interactive
{
    /// <summary>
    /// Логика взаимодействия для VTManagerStat.xaml
    /// </summary>
    public partial class VTManagerStat : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public VTManagerStat()
        {
            InitializeComponent();
        }

        public void NotifyPropertyChanged(string info) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        private string _value;
        public string ItemValue {
            get { return _value; } 
            set { _value = value; }
        }
        private string _target;
        public string ItemTarget {
            get { return _target; }
            set { _target = value; }
        }
    }
}
