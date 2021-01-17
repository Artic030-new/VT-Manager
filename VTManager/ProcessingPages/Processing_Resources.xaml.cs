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

namespace VTManager.ProcssingPages
{
    /// <summary>
    /// Логика взаимодействия для Processing_Resources.xaml
    /// </summary>
    public partial class Processing_Resources : Page
    {
        public Processing_Resources() {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) {
            showRemains();
        }

        void showRemains() {
            SQLUtils.runQuery(VTChartQueries.selectDryMix(1), "mix", res1);
            SQLUtils.runQuery(VTChartQueries.selectDryMix(2), "mix", res2);
            SQLUtils.runQuery(VTChartQueries.selectResource(3), "res", res3);
            SQLUtils.runQuery(VTChartQueries.selectResource(4), "res", res4);
            SQLUtils.runQuery(VTChartQueries.selectResource(5), "res", res5);
            SQLUtils.runQuery(VTChartQueries.selectResource(6), "res", res6);
            SQLUtils.runQuery(VTChartQueries.selectResource(8), "res", res7);
        }
    }
}
