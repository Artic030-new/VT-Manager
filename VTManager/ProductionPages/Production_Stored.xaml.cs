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
using VTManager;
using VTManager.Interactive;
using VTManager.Utils;

namespace VTManager.ProductionPages
{
    /// <summary>
    /// Логика взаимодействия для Production_Stored.xaml
    /// </summary>
    public partial class Production_Stored : Page
    {
        public Production_Stored() {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e) {
            SQLUtils.showTable(VTDataGridQueries.productionQuery, VTManagerConfig.vtsCols, production_dg);
            /*                          Плэйсхолдеры                            */
            if (string.IsNullOrWhiteSpace(storage_field.Text)) {
                storage_field.Text = "склад...";
                storage_field.Foreground = new SolidColorBrush(Color.FromArgb( (byte)255, 74, 91, 138));
            }
            if (string.IsNullOrWhiteSpace(vt_field.Text)) {
                vt_field.Text = "марка...";
                vt_field.Foreground = new SolidColorBrush(Color.FromArgb((byte)255, 74, 91, 138));
            }
        }
        private void search_button_Click(object sender, RoutedEventArgs e) {
            string search = VTDataGridQueries.productionQuery + " WHERE storages.name LIKE " + "\'" + storage_field.Text.Replace("склад...", "") + "%\'";
            string filters = (!(vt_field.Text == "марка...")) ?
                search += " AND vt.mark LIKE " + "\'" + StringUtils.replaceAllUnsupportedChr(vt_field.Text.Trim(StringUtils.trimmer)) + "%\'"
                    : search += "";
                SQLUtils.showTable(search, VTManagerConfig.vtsCols, production_dg);
                debug_textbox.Text = "Результат:  " + production_dg.Items.Count + StringUtils.computeSuffix(production_dg.Items.Count);
        }
        private void export_button_Click(object sender, RoutedEventArgs e) {
            ExportUtils.exportToExcel(production_dg, page_header.Content.ToString().Trim(), "C");
        }
        private void print_button_Click(object sender, RoutedEventArgs e) {
            System.Windows.Controls.PrintDialog pd = new System.Windows.Controls.PrintDialog();
            if ((bool)pd.ShowDialog().GetValueOrDefault()) {
                Size pageSize = new Size(pd.PrintableAreaWidth, pd.PrintableAreaHeight);
                production_dg.Measure(pageSize);
                production_dg.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                pd.PrintVisual(production_dg, Title);
                ProcessingPage.ThisFrame.Refresh();
            }
        }
        private void storage_field_GotFocus(object sender, RoutedEventArgs e) {
            if (storage_field.Text == "склад...") {
                storage_field.Text = "";
                storage_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void storage_field_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(storage_field.Text)) {
                storage_field.Text = "склад...";
                storage_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
        }
        private void storage_field_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!Char.IsLetterOrDigit(e.Text, 0)) e.Handled = true;
        }
        private void vt_field_GotFocus(object sender, RoutedEventArgs e) {
            if (vt_field.Text == "марка...") {
                vt_field.Text = "";
                vt_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void vt_field_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(vt_field.Text)) {
                vt_field.Text = "марка...";
                vt_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
        }
        private void vt_field_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!Char.IsLetterOrDigit(e.Text, 0)) e.Handled = true;
        }
    }
}