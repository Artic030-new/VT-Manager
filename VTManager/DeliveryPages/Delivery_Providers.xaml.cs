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
    /// Логика взаимодействия для Delivery_Delivers.xaml
    /// </summary>
    public partial class Delivery_Delivers : Page
    {
        public Delivery_Delivers() {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(initials_field.Text)) {
                initials_field.Text = "фио поставщика...";
                initials_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
            if (string.IsNullOrWhiteSpace(phone_field.Text)) {
                phone_field.Text = "тел...";
                phone_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
            if (string.IsNullOrWhiteSpace(email_field.Text)) {
                email_field.Text = "эл.почта...";
                email_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
        }
        private void initials_field_GotFocus(object sender, RoutedEventArgs e) {
            if (initials_field.Text == "фио поставщика...") {
                initials_field.Text = "";
                initials_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void initials_field_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(initials_field.Text)) {
                initials_field.Text = "фио поставщика...";
                initials_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
        }
        private void initials_field_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }
        private void phone_field_GotFocus(object sender, RoutedEventArgs e) {
            if (phone_field.Text == "тел...") {
                phone_field.Text = "";
                phone_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void phone_field_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(phone_field.Text)) {
                phone_field.Text = "тел...";
                phone_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
        }
        private void phone_field_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
        private void email_field_GotFocus(object sender, RoutedEventArgs e) {
            if (email_field.Text == "эл.почта...") {
                email_field.Text = "";
                email_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void email_field_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(email_field.Text)) {
                email_field.Text = "эл.почта...";
                email_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
        }
        private void search_button_Click(object sender, RoutedEventArgs e) {
            string search = VTDataGridQueries.providersQuery + " WHERE fullName LIKE " + "\'" + StringUtils.replaceAllUnsupportedChr(initials_field.Text.Trim(StringUtils.trimmer).Replace("фио поставщика", "")) + "%\'";
            string filters = (!(phone_field.Text == "тел...")) ?
                search += " AND phone LIKE " + "\'" + StringUtils.replaceAllUnsupportedChr(phone_field.Text.Trim(StringUtils.trimmer)) + "%\'"
                : (!(email_field.Text == "эл.почта...")) ?
                    search += " AND email LIKE " + "\'" + StringUtils.replaceAllUnsupportedChr(email_field.Text.Trim(StringUtils.trimmer)) + "%\'"
                        : search += "";
            SQLUtils.showTable(search, VTManagerConfig.providersCols, providers_dg);
            debug_textbox.Text = "Результат:  " + providers_dg.Items.Count + StringUtils.computeSuffix(providers_dg.Items.Count);
        }
        private void export_button_Click(object sender, RoutedEventArgs e) {
            ExportUtils.exportToExcel(providers_dg, page_header.Content.ToString().Trim(), "C");
        }
        private void print_button_Click(object sender, RoutedEventArgs e) {
            System.Windows.Controls.PrintDialog pd = new System.Windows.Controls.PrintDialog();
            if ((bool)pd.ShowDialog().GetValueOrDefault()) {
                Size pageSize = new Size(pd.PrintableAreaWidth, pd.PrintableAreaHeight);
                providers_dg.Measure(pageSize);
                providers_dg.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                pd.PrintVisual(providers_dg, Title);
                DeliveryPage.ThisFrame.Refresh();
            }
        }
        private void sec_button_Click(object sender, RoutedEventArgs e) {
            Label l1 = new Label();
            Label l2 = new Label();
            DataRowView data_row = (DataRowView)providers_dg.SelectedItem;
            try {
                string selected_name = data_row.Row.ItemArray[0].ToString();
                if (selected_name.Length > 0) {
                    SQLUtils.runQuery("SELECT organization AS org FROM providers WHERE fullName = " + "\"" + selected_name + "\"", "org", l1);
                    SQLUtils.runQuery("SELECT address AS address FROM providers WHERE fullName = " + "\"" + selected_name + "\"", "address", l2);
                    debug_textbox.Text = "Организация поставщика " + selected_name + " : " + l1.Content.ToString() + "\n" + "Адрес поставщика " + selected_name + " : " + l2.Content.ToString();
                }
            } catch (System.NullReferenceException) { debug_textbox.Text = "Поставщик не выбран."; }
        }
    }
}