using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VTManager.Interactive;

namespace VTManager
{
    /// <summary>
    /// Логика взаимодействия для VTManagerDialog.xaml
    /// </summary>
    public partial class VTManagerDialog : Window
    {
        public VTManagerDialog()
        {
            InitializeComponent();
            #region =========   КОМАНДЫ    =========
            DragApplicationCmd = new VTActionCommand(OnDragApplicationCmdExecute, CanDragApplicationCmdExecuted);
            OkCmd = new VTActionCommand(OnOkCmdExecute, CanOkCmdExecuted);
            #endregion =========   КОМАНДЫ    =========
            this.DataContext = this;
        }
        // Вывод окна на месте
        public VTManagerDialog(string header, string message) {
            InitializeComponent();
            dialog_label.Content = header;
            contained_info.Text = message;
            Show();
        }
        #region =========   КОМАНДЫ    =========
        /// <summary> Перемещение окна мышью </summary>
        public ICommand DragApplicationCmd { get; }
        private bool CanDragApplicationCmdExecuted(object o) => true;
        private void OnDragApplicationCmdExecute(object o) => this.DragMove();
        /// <summary> Перемещение окна мышью </summary>
        public ICommand OkCmd { get; }
        private bool CanOkCmdExecuted(object o) => true;
        private void OnOkCmdExecute(object o) => this.Close();
        #endregion =========   КОМАНДЫ    =========
    }
}
