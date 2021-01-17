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
            SQLUtils.runQuery(VTChartQueries.selectVt("6К4"), "mk", vt_mark2);
            SQLUtils.runQuery(VTChartQueries.selectVt("6К7"), "mk", vt_mark3);
            SQLUtils.runQuery(VTChartQueries.selectVt("6Ж3"), "mk", vt_mark4);
            SQLUtils.runQuery(VTChartQueries.selectVt("6С1П"), "mk", vt_mark5);
            SQLUtils.runQuery(VTChartQueries.selectVt("6С2С"), "mk", vt_mark6);
            SQLUtils.runQuery(VTChartQueries.selectVt("6И1П"), "mk", vt_mark7);
            SQLUtils.runQuery(VTChartQueries.selectVt("6Х2П"), "mk", vt_mark8);
            SQLUtils.runQuery(VTChartQueries.selectVt("6Х6С"), "mk", vt_mark9);
            SQLUtils.runQuery(VTChartQueries.selectVt("6Ц10П"), "mk", vt_mark10);
        }
    }
}