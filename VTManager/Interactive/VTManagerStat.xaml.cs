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
            this.DataContext = this;
        }

        public void NotifyPropertyChanged(string info) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        private static string _value = "0";
        public string Value
        {
            get { return _value; } 
            set { _value = value; NotifyPropertyChanged("Value"); }
        }
        private string _target = "Of Something";
        public string Target
        {
            get { return _target; }
            set { _target = value; NotifyPropertyChanged("Target"); }
        }
        private int _limit = 0;
        public int Limit
        {
            get { return _limit; }
            set { _limit = value; NotifyPropertyChanged("Limit"); }
        }
    }
}
