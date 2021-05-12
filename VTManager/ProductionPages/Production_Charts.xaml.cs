using System;
using System.Collections.Generic;
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
using VTManager.Interactive;
using VTManager.Utils;

namespace VTManager.ProductionPages
{
    /// <summary>
    /// Логика взаимодействия для Production_Charts.xaml
    /// </summary>
    public partial class Production_Charts : Page
    {
        public Production_Charts() {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e) {
            showStoredVts();
        }

        void showStoredVts() {
            Interactive.VTManagerChart[] charts = { vt_mark2, vt_mark3, vt_mark4, vt_mark5, vt_mark6, vt_mark7, vt_mark8, vt_mark9, vt_mark10};
            String[] marks = { "6К4", "6К7", "6Ж3", "6С1П", "6С2С", "6И1П", "6Х2П", "6Х6С", "6Ц10П" };
            for (int c = 0; c < charts.Length; c++) {
                SQLUtils.runQuery(VTChartQueries.selectVt(marks[c]), "mk", charts[c]);
            }
        }
    }
}