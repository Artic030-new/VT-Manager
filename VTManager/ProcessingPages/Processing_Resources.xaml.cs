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
using WpfApp1.Interactive;
using WpfApp1.Utils;

namespace WpfApp1.ProcssingPages
{
    /// <summary>
    /// Логика взаимодействия для Processing_Resources.xaml
    /// </summary>
    public partial class Processing_Resources : Page
    {
        public Processing_Resources()
        {
            InitializeComponent();
        }

      

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SQLUtils.runQuery(VTChartQueries.totalSand, "sand_count", res1);
            SQLUtils.runQuery(VTChartQueries.totalSilicon, "silicon_count", res2);
            SQLUtils.runQuery(VTChartQueries.totalGraphene, "graphene_count", res3);
            SQLUtils.runQuery(VTChartQueries.totalBGlass, "bglass_count", res4);
            SQLUtils.runQuery(VTChartQueries.totalBA, "BA_count", res5);
            SQLUtils.runQuery(VTChartQueries.totalEC, "EC_count", res6);
            SQLUtils.runQuery(VTChartQueries.totalAcetone, "acetone_count", res7);
           
        }
    }
}
