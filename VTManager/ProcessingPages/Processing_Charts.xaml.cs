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

namespace VTManager
{
    /// <summary>
    /// Логика взаимодействия для Processing_Charts.xaml
    /// </summary>
    public partial class Processing_Charts : Page
    {
        public Processing_Charts()
        {
            InitializeComponent();
        }
        private void processing_charts_page_Loaded(object sender, RoutedEventArgs e)
        {
            SQLUtils.runQuery(VTChartQueries.totalProductionQuery, "all_vt", block1.block_value);
            SQLUtils.runQuery(VTChartQueries.totalLossQuery, "all_vt", block2.block_value);
            SQLUtils.runQuery(VTChartQueries.totalPentode, "all_vt", vt_type1);
            SQLUtils.runQuery(VTChartQueries.totalTriode, "all_vt", vt_type2);
            SQLUtils.runQuery(VTChartQueries.totalTriode2, "all_vt", vt_type3);
            SQLUtils.runQuery(VTChartQueries.totalDoubleDiode, "all_vt", vt_type4);
            SQLUtils.runQuery(VTChartQueries.totalCenotrone, "all_vt", vt_type5);
        }
       
        private void block1_value_Loaded(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(block1.block_value.Content) < 499)
                block1.block_value.Foreground = Brushes.Red;
        }
        private void block2_value_Loaded(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDouble(block2.block_value.Content) < 5)
                block2.block_value.Foreground = Brushes.Red;
        }
    }
}
