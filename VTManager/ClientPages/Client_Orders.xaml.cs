using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.Interactive;
using WpfApp1.Utils;

namespace WpfApp1.ClientPages
{
    /// <summary>
    /// Логика взаимодействия для Client_Orders.xaml
    /// </summary>
    public partial class Client_Orders : Page
    {
        public static VTManagerDialog warn_msg = new VTManagerDialog();
        public Client_Orders()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SQLUtils.showTable(VTDataGridQueries.ordersQuery, VTManagerConfig.ordersCols, orders_dg);
            if (string.IsNullOrWhiteSpace(order_number_field.Text))
            {
                order_number_field.Text = "№ заказа...";
                order_number_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
            if (string.IsNullOrWhiteSpace(initials_field.Text))
            {
                initials_field.Text = "фио клиента...";
                initials_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
            if (string.IsNullOrWhiteSpace(vt_field.Text))
            {
                vt_field.Text = "радиолампа...";
                vt_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
            if (order_date_field.Text.Contains("-"))
            {
                order_date_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
        }
        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            string search = VTDataGridQueries.ordersQuery + " WHERE date LIKE " + "\'" + order_date_field.Text + "%\'";
            string filters = (!(order_number_field.Text == "№ заказа...")) ?
                search += " AND orders.id = " + order_number_field.Text.Trim(StringUtils.trimmer)
                : (!(vt_field.Text == "радиолампа...")) ?
                    search += " AND vt.mark LIKE " + "\'" + vt_field.Text.Trim(StringUtils.trimmer) + "%\'"
                        : (!(initials_field.Text == "фио клиента...")) ?
                            search += " AND users.fullName LIKE " + "\'" + initials_field.Text.Trim(StringUtils.trimmer) + "%\'"
                                : search += "";
            SQLUtils.showTable(search, VTManagerConfig.ordersCols, orders_dg);
            debug_textbox.Text = "Результат:  " + orders_dg.Items.Count + StringUtils.computeSuffix(orders_dg.Items.Count);
        }
        private void order_number_field_GotFocus(object sender, RoutedEventArgs e)
        {
            if (order_number_field.Text == "№ заказа...")
            {
                order_number_field.Text = "";
                order_number_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void order_number_field_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(order_number_field.Text))
            {
                order_number_field.Text = "№ заказа...";
                order_number_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
        }
        private void order_number_field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
        private void order_date_field_GotFocus(object sender, RoutedEventArgs e)
        {
            order_date_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
        }
        private void vt_field_GotFocus(object sender, RoutedEventArgs e)
        {
            if (vt_field.Text == "радиолампа...")
            {
                vt_field.Text = "";
                vt_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void vt_field_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(vt_field.Text))
            {
                vt_field.Text = "радиолампа...";
                vt_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
        }
        private void vt_field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.Text, 0)) e.Handled = true;
        }
        private void initials_field_GotFocus(object sender, RoutedEventArgs e)
        {
            if (initials_field.Text == "фио клиента...")
            {
                initials_field.Text = "";
                initials_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void initials_field_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(initials_field.Text))
            {
                initials_field.Text = "фио клиента...";
                initials_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
        }
        private void initials_field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.Text, 0)) e.Handled = true;
        }

        private void erase_button_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data_row = (DataRowView)orders_dg.SelectedItem;
            try
            {
                string checkd = data_row.Row.ItemArray[5].ToString();
           
                string id = data_row.Row.ItemArray[0].ToString();
                if (!(checkd.Equals("True")))
                {
                    SQLUtils.runQuery("DELETE FROM orders WHERE id = " + id.Trim());
                    debug_textbox.Text = "Заказ № " + id.Trim() + " успешно отменён.";
                }
                else
                {
                    warn_msg.dialog_label.Content = "Внимание";
                    warn_msg.contained_info.Text = "Отменить завершённый заказ нельзя";
                    warn_msg.Show();
                }
            }
            catch (System.NullReferenceException) { debug_textbox.Text = "Выберите запись в таблице!"; }
        }
        private void done_button_Click(object sender, RoutedEventArgs e)
        {
            Label t1 = new Label();
            DataRowView data_row = (DataRowView)orders_dg.SelectedItem;
            try
            {
                string checkd = data_row.Row.ItemArray[5].ToString();
                string id = data_row.Row.ItemArray[0].ToString();
                string mark = data_row.Row.ItemArray[2].ToString();
                string count = data_row.Row.ItemArray[3].ToString();
                if (!(checkd.Equals("True")))
                {
                    SQLUtils.runQuery("SELECT vt.id AS id FROM vt JOIN vt_lots ON vt.id = vt_lots.vtId WHERE vt.mark = \"" + mark + "\"", "id", t1);
                    string the_id = t1.Content.ToString().Trim();
                    SQLUtils.runQuery("UPDATE vt_lots SET count = (count - " + count + ") WHERE vtId = " + the_id + "; UPDATE orders SET done = 1 WHERE id = " + id);
                    debug_textbox.Text = "Заказ №" + id + " успешно завершён.";
                }
                else 
                {
                    warn_msg.dialog_label.Content = "Внимание";
                    warn_msg.contained_info.Text = "Заказ уже был завершен";
                    warn_msg.Show();
                }
            }
            catch (System.NullReferenceException) { debug_textbox.Text = "Выберите запись!"; }
        }
    }
}