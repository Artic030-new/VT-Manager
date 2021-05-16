using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VTManager.Interactive
{
    class SliderViewModel : INotifyPropertyChanged
    {
        

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
        #region СВОЙСТВА
        private int _lossRatio;
        private int? _result = null;

        public int LossRatio {
            get => _lossRatio;
            set { 
                _lossRatio = Convert.ToInt32(VTManagerConfig.xmldata.Descendants("lossRatio").First().Value); 
                NotifyPropertyChanged("LossRatio"); 
            }
        }
        public int? Result { get => _result; private set { _result = value; NotifyPropertyChanged("Result"); } }

        #endregion

        #region КОМАНДЫ
        ICommand _addData;
        public ICommand AddCommand => _addData ?? (_addData = new SliderShowCommand(OnAdd));
        #endregion

        #region
        private void OnAdd(object parameter) => Result = 2;
        #endregion
    }
}
