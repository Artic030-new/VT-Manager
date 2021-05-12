using System.Windows;
using System.Windows.Controls;
using VTManager.Utils;
using VTManager.Interactive;
using System;
using System.Windows.Media;

namespace VTManager.ClientPages
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
            SQLUtils.runQuery(VTChartQueries.totalSaled, "all_sales", block1.block_value);
            SQLUtils.runQuery(VTChartQueries.totalOrders, "all_orders", block2.block_value);
            SQLUtils.runQuery(VTChartQueries.totalClients, "all_clients", block3.block_value);
            SQLUtils.runQuery(VTChartQueries.totalMark1, "all_mk1", vt_mark1);
            SQLUtils.runQuery(VTChartQueries.totalMark2, "all_mk2", vt_mark2);
            SQLUtils.runQuery(VTChartQueries.totalMark3, "all_mk3", vt_mark3);
            SQLUtils.runQuery(VTChartQueries.totalMark4, "all_mk4", vt_mark4);
            SQLUtils.runQuery(VTChartQueries.totalSaledPentode, "all_vt", vt_type1);
            SQLUtils.runQuery(VTChartQueries.totalSaledTriode, "all_vt", vt_type2);
            SQLUtils.runQuery(VTChartQueries.totalSaledDoubleDiode, "all_vt", vt_type3);
            SQLUtils.runQuery(VTChartQueries.totalSaledCenotrone, "all_vt", vt_type4);
        }

        private void main_costs_Loaded(object sender, RoutedEventArgs e)
        {
            if(Convert.ToInt32(block1.block_value.Content.ToString()) < block1.Limit)
                block1.block_value.Foreground = Brushes.Red;
            if (Convert.ToInt32(block2.block_value.Content.ToString()) < block2.Limit)
                block2.block_value.Foreground = Brushes.Red;
            if (Convert.ToInt32(block3.block_value.Content.ToString()) < block3.Limit)
                block3.block_value.Foreground = Brushes.Red;
        }
    }
}
