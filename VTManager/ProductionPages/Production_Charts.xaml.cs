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

namespace WpfApp1.ProductionPages
{
    /// <summary>
    /// Логика взаимодействия для Production_Charts.xaml
    /// </summary>
    public partial class Production_Charts : Page
    {
        public Production_Charts()
        {
            InitializeComponent();
        }
    /*  
     *   Неведомый crack .. (2) 
     *  private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SQLUtils.runQuery(VTChartQueries.storedMk2, "mk", vt_mark2);
            SQLUtils.runQuery(VTChartQueries.storedMk3, "mk", vt_mark3);
            SQLUtils.runQuery(VTChartQueries.storedMk4, "mk", vt_mark4);
            SQLUtils.runQuery(VTChartQueries.storedMk5, "mk", vt_mark5);
            SQLUtils.runQuery(VTChartQueries.storedMk6, "mk", vt_mark6);
            SQLUtils.runQuery(VTChartQueries.storedMk7, "mk", vt_mark7);
            SQLUtils.runQuery(VTChartQueries.storedMk8, "mk", vt_mark8);
            SQLUtils.runQuery(VTChartQueries.storedMk9, "mk", vt_mark9);
            SQLUtils.runQuery(VTChartQueries.storedMk10, "mk", vt_mark10);
         
        }*/
        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            SQLUtils.runQuery(VTChartQueries.storedMk2, "mk", vt_mark2);
            SQLUtils.runQuery(VTChartQueries.storedMk3, "mk", vt_mark3);
            SQLUtils.runQuery(VTChartQueries.storedMk4, "mk", vt_mark4);
            SQLUtils.runQuery(VTChartQueries.storedMk5, "mk", vt_mark5);
            SQLUtils.runQuery(VTChartQueries.storedMk6, "mk", vt_mark6);
            SQLUtils.runQuery(VTChartQueries.storedMk7, "mk", vt_mark7);
            SQLUtils.runQuery(VTChartQueries.storedMk8, "mk", vt_mark8);
            SQLUtils.runQuery(VTChartQueries.storedMk9, "mk", vt_mark9);
            SQLUtils.runQuery(VTChartQueries.storedMk10, "mk", vt_mark10);
        }
    }
}