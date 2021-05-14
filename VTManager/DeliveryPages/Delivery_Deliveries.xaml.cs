using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace VTManager.DeliveryPages
{
    /// <summary>
    /// Логика взаимодействия для Delivery_Deliveries.xaml
    /// </summary>
    public partial class Delivery_Deliveries : Page
    {
        public Delivery_Deliveries()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SQLUtils.showTable(VTDataGridQueries.deliveriesQuery, VTManagerConfig.deliveriesCols, deliveries_dg);
            /*                          Плэйсхолдеры                            */
            if (string.IsNullOrWhiteSpace(provider_field.Text)) {
                provider_field.Text = "поставщик...";
                provider_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
            if (string.IsNullOrWhiteSpace(resource_field.Text)) {
                resource_field.Text = "ресурс...";
                resource_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
            if (string.IsNullOrWhiteSpace(count_field.Text)) {
                count_field.Text = "кол-во...";
                count_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
            if (string.IsNullOrWhiteSpace(personal_field.Text)) {
                personal_field.Text = "фам.сотрудника...";
                personal_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
            if (date_field.Text.Contains("-")) {
                date_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
        }
        private void search_button_Click(object sender, RoutedEventArgs e) {
            string search = VTDataGridQueries.deliveriesQuery + " WHERE date LIKE " + "\'" + date_field.Text + "%\'";
            string filters = (!(provider_field.Text == "поставщик...")) ?
                search += " AND providers.fullName LIKE " + "\'%" + StringUtils.replaceAllUnsupportedChr(provider_field.Text.Trim(StringUtils.trimmer)) + "%\'"
               : (!(resource_field.Text == "ресурс...")) ?
                    search += " AND resource.name LIKE " + "\'%" + StringUtils.replaceAllUnsupportedChr(resource_field.Text.Trim(StringUtils.trimmer)) + "%\'"
                : (!(count_field.Text == "кол-во...")) ?
                    search += " AND deliveries.count LIKE " + "\'" + StringUtils.replaceAllUnsupportedChr(count_field.Text.Trim(StringUtils.trimmer)) + "%\'"
                        : (!(personal_field.Text == "фам.сотрудника...")) ?
                            search += " AND shift = " + StringUtils.replaceAllUnsupportedChr(personal_field.Text.Trim(StringUtils.trimmer))
                                        : search += "";
            SQLUtils.showTable(search, VTManagerConfig.deliveriesCols, deliveries_dg);
            debug_textbox.Text = "Результат:  " + deliveries_dg.Items.Count + StringUtils.computeSuffix(deliveries_dg.Items.Count);
        }
        private void export_button_Click(object sender, RoutedEventArgs e) {
            ExportUtils.exportToExcel(deliveries_dg, page_header.Content.ToString().Trim(), "F");
        }
        private void print_button_Click(object sender, RoutedEventArgs e) {
            System.Windows.Controls.PrintDialog pd = new System.Windows.Controls.PrintDialog();
            if ((bool)pd.ShowDialog().GetValueOrDefault()) {
                Size pageSize = new Size(pd.PrintableAreaWidth, pd.PrintableAreaHeight);
                deliveries_dg.Measure(pageSize);
                deliveries_dg.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                pd.PrintVisual(deliveries_dg, Title);
                ProcessingPage.ThisFrame.Refresh();
            }
        }
        private void date_field_GotFocus(object sender, RoutedEventArgs e) {
            date_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
        }
        private void provider_field_GotFocus(object sender, RoutedEventArgs e) {
            if (provider_field.Text == "поставщик...") {
                provider_field.Text = "";
                provider_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void provider_field_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(provider_field.Text)) {
                provider_field.Text = "поставщик...";
                provider_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
        }
        private void provider_field_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }
        private void resource_field_GotFocus(object sender, RoutedEventArgs e) {
            if (resource_field.Text == "ресурс...") {
                resource_field.Text = "";
                resource_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void resource_field_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(resource_field.Text)) {
                resource_field.Text = "ресурс...";
                resource_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
        }
        private void resource_field_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }
        private void count_field_GotFocus(object sender, RoutedEventArgs e) {
            if (count_field.Text == "кол-во...") {
                count_field.Text = "";
                count_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void count_field_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(count_field.Text)) {
                count_field.Text = "кол-во...";
                count_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
        }
        private void count_field_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
        private void personal_field_GotFocus(object sender, RoutedEventArgs e) {
            if (personal_field.Text == "фам.сотрудника...") {
                personal_field.Text = "";
                personal_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void personal_field_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(personal_field.Text)) {
                personal_field.Text = "фам.сотрудника...";
                personal_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
        }
        private void personal_field_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }
        private void done_button_Click(object sender, RoutedEventArgs e) {
            Label t1 = new Label();
            Label t2 = new Label();
            DataRowView data_row = (DataRowView)deliveries_dg.SelectedItem;
            string price = Interaction.InputBox(Messages._ENTER_THE_COST);
            try {
                string id = data_row.Row.ItemArray[0].ToString();
                string count = data_row.Row.ItemArray[4].ToString();
                string checkd = data_row.Row.ItemArray[6].ToString();
                if (!(checkd.Equals("True"))) {
                    bool is_number = int.TryParse(price, out int n);
                    if (price != "") {
                        if (is_number) {
                            SQLUtils.runQuery("SELECT resource.id AS id FROM deliveries JOIN resource ON resource.id = deliveries.resourceId WHERE deliveries.id = " + id, "id", t1);
                            SQLUtils.runQuery("SELECT deliveries.count AS count FROM deliveries JOIN resource ON resource.id = deliveries.resourceId WHERE deliveries.id = " + id, "count", t2);
                            string the_id = t1.Content.ToString().Trim();
                            string the_count = t2.Content.ToString().Trim();
                            SQLUtils.runQuery("UPDATE storage_contains SET count = (count + " + the_count + ") WHERE resourceId = " + the_id + "; UPDATE deliveries SET done = 1, price = " + price + " WHERE id = " + id + "");
                            debug_textbox.Text = "Поставка №" + id + " успешно завершена.";
                            SQLUtils.showTable(VTDataGridQueries.deliveriesQuery, VTManagerConfig.deliveriesCols, deliveries_dg);
                        }
                        else debug_textbox.Text = Messages._COST_ABOVE_ZERO;
                    } else debug_textbox.Text = Messages._COST_NOT_SET;
                } else {
                    new VTManagerDialog(Messages._WARNING_MESSAGE, Messages._ORDER_HAS_BEEN_SOLVED);
                }
            } catch (System.NullReferenceException) { debug_textbox.Text = Messages._NO_ENTRY_SELECTED; }
        }
    }
}