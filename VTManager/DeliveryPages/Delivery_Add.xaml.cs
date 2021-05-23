using System;
using System.Collections;
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

namespace VTManager.DeliveryPages
{
    /// <summary>
    /// Логика взаимодействия для Delivery_Add.xaml
    /// </summary>
    public partial class Delivery_Add : Page
    {
        /*Объекты лейблов под выполняемые запросы*/
        private Label t1 = new Label();
        private Label t2 = new Label();
        private Label t3 = new Label();
        private VTQuery query = new VTQuery();
        public Delivery_Add()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {                        /*  Плейсхолдеры   */
            if (string.IsNullOrWhiteSpace(count_field.Text))
            {
                count_field.Text = "кол-во...";
                count_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
            select_personal_cbox.SelectedIndex = 0;
            select_provider_cbox.SelectedIndex = 0;
            select_resource_cbox.SelectedIndex = 0;
            SQLUtils.runRecursiveQuery(VTDataGridQueries.totalWarehousePersonal, "warehouse_personal", t1);
            string personalCountStr = t1.Content.ToString();
            List<string> personalId = new List<string>();
            foreach (string s in personalCountStr.Split('&')) personalId.Add(s);
            t1.Content = "";
            for (int i = 0; i < personalId.Count-1; ++i)
            {
                SQLUtils.runQuery(query.select("firstName", "name", "personal", "id = " + personalId[i]), "name", t1);
                
                string namesCountStr = t1.Content.ToString();
                select_personal_cbox.Items.Add(namesCountStr);
            }
            string resourceNames = query.select("name", "name", "resource", "id = ");
            string providerNames = query.select("fullName", "names", "providers", "id = ");
            ///*<summary> Метод, возвращающий список каких-либо значений из выполненного запроса в комбобокс.
            ///   для несложный условий подходит, в остальном работает плохо <see cref="SQLUtils"> подробнее в самом классе</see> </summary>*///
            SQLUtils.fillCombobox(1, VTDataGridQueries.totalResourceTypes, "resource_count", resourceNames, "name", select_resource_cbox);
            SQLUtils.fillCombobox(1, VTDataGridQueries.totalProviders, "provider_count", providerNames, "names", select_provider_cbox);
            t1.Content = "";
            SQLUtils.showTable(VTDataGridQueries.deliveryTable, VTManagerConfig.deliveryCols, request_dg);
        }
        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            string providerValue = select_provider_cbox.SelectedItem.ToString();
            string resourceValue = select_resource_cbox.SelectedItem.ToString();
            string personalValue = select_personal_cbox.SelectedItem.ToString();
            SQLUtils.runQuery(query.select("providers.id", "ids", "providers", "fullName = " + "\"" + providerValue + "\" "), "ids", t1);
            SQLUtils.runQuery(query.select("resource.id", "ids", "resource", "name = " + "\"" + resourceValue + "\" "), "ids", t2);
            SQLUtils.runQuery(query.select("personal.id", "ids", "personal", "firstName = " + "\"" + personalValue + "\" "), "ids", t3);
            string providerIdValue = t1.Content.ToString();
            string resourceIdValue = t2.Content.ToString();
            string personalIdValue = t3.Content.ToString();
            string insertValues = "(NULL, " + providerIdValue + ", " + resourceIdValue + ", " + personalIdValue + ", " + count_field.Text + ", 0, " + "\'" + date_field.Text + "\'" + ", 0)";
            if (count_field.Text != "кол-во..." && (!(date_field.Text.Contains('_'))))
            {
                debug_textbox.Text = "Запрос на поставку материала " + resourceValue + " успешно создан.";
                SQLUtils.runQuery(VTDataGridQueries.addDelivery + insertValues);
                SQLUtils.showTable(VTDataGridQueries.deliveryTable, VTManagerConfig.deliveryCols, request_dg);
            }
            else debug_textbox.Text = "Заполните все поля!";
        }
        private void count_field_GotFocus(object sender, RoutedEventArgs e)
        {
            if (count_field.Text == "кол-во...")
            {
                count_field.Text = "";
                count_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void count_field_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(count_field.Text))
            {
                count_field.Text = "кол-во...";
                count_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
        }
        private void count_field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
        private void export_button_Click(object sender, RoutedEventArgs e)
        {
            ExportUtils.exportToExcel(request_dg, page_header.Content.ToString().Trim(), "G");
        }
        private void print_button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog pd = new System.Windows.Controls.PrintDialog();
            if ((bool)pd.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(pd.PrintableAreaWidth, pd.PrintableAreaHeight);
                request_dg.Measure(pageSize);
                request_dg.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                pd.PrintVisual(request_dg, Title);
                ProcessingPage.ThisFrame.Refresh();
            }
        }
    }
}