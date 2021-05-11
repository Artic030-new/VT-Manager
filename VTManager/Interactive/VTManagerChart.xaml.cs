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

namespace VTManager
{
    /// <summary>
    /// Interaction logic for VTManagerChart.xaml
    /// </summary>
    public partial class VTManagerChart : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        private string _itemname;
        public string ItemName
        {
            get { return _itemname; }
            set { _itemname = value; }
        }

        private double _value;
        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                UpdateBarHeight();
                NotifyPropertyChanged("Value");
            }
        }

        private double maxValue;
        public double MaxValue
        {
            get { return maxValue; }
            set
            {
                maxValue = value;
                UpdateBarHeight();
                NotifyPropertyChanged("MaxValue");
            }
        }

        private double barHeight;
        public double BarHeight
        {
            get { return barHeight; }
            private set { barHeight = value; NotifyPropertyChanged("BarHeight"); }
        }

        private Brush color;
        public Brush Color
        {
            get { return color; }
            set { color = value; NotifyPropertyChanged("Color"); }
        }

        private Brush textcolor;
        public Brush TextColor
        {
            get { return textcolor; }
            set { textcolor = value; NotifyPropertyChanged("TextColor"); }
        }

        private void UpdateBarHeight()
        {
            if (maxValue > 0)
            {
                var percent = (_value * 100) / maxValue;
                BarHeight = (percent * this.ActualHeight) / 100;
            }
        }

        public VTManagerChart()
        {
            InitializeComponent();
            this.DataContext = this;
            Color = Brushes.Black;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateBarHeight();
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateBarHeight();
        }
    }
}