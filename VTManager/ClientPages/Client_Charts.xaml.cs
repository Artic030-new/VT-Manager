using System.Windows;
using System.Windows.Controls;
using WpfApp1.Utils;
using WpfApp1.Interactive;
using System;
using System.Windows.Media;

namespace WpfApp1.ClientPages
{
    /// <summary>
    /// Логика взаимодействия для Client_Charts.xaml
    /// </summary>
    public partial class Client_Charts : Page
    {
        public Client_Charts()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SQLUtils.runQuery(VTChartQueries.totalSaled, "all_sales", block1_value);
            SQLUtils.runQuery(VTChartQueries.totalOrders, "all_orders", block2_value);
            SQLUtils.runQuery(VTChartQueries.totalClients, "all_clients", block3_value);
            SQLUtils.runQuery(VTChartQueries.totalMark1, "all_mk1", vt_mark1);
            SQLUtils.runQuery(VTChartQueries.totalMark2, "all_mk2", vt_mark2);
            SQLUtils.runQuery(VTChartQueries.totalMark3, "all_mk3", vt_mark3);
            SQLUtils.runQuery(VTChartQueries.totalMark4, "all_mk4", vt_mark4);
            SQLUtils.runQuery(VTChartQueries.totalSaledPentode, "all_vt", vt_type1);
            SQLUtils.runQuery(VTChartQueries.totalSaledTriode, "all_vt", vt_type2);
            SQLUtils.runQuery(VTChartQueries.totalSaledDoubleDiode, "all_vt", vt_type3);
            SQLUtils.runQuery(VTChartQueries.totalSaledCenotrone, "all_vt", vt_type4);
        }
        private void block1_value_Loaded(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(block1_value.Content) < 499)
                block1_value.Foreground = Brushes.Red;
        }
    }
}
