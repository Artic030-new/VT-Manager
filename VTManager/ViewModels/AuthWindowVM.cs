using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTManager.ViewModels
{
    public class AuthWindowVM : BindableBase
    {
        public AuthWindowVM() { }

        #region Свойства
        public string Login { get => login; set { login = value; RaisePropertyChanged(nameof(Login)); } }
        public string Password { get => password; set { password = value; RaisePropertyChanged(nameof(Password)); } }
        public bool KeepEntry { get => keepEntry; set { keepEntry = value; RaisePropertyChanged(nameof(KeepEntry)); } }
        #endregion

        #region Приватные поля свойств
        private string login;
        private string password;
        private bool keepEntry;
        #endregion
    }
}
