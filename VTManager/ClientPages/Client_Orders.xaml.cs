using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using VTManager.Interactive;
using VTManager.Utils;

namespace VTManager.ClientPages
{
    /// <summary>
    /// Логика взаимодействия для Client_Orders.xaml
    /// </summary>
    public partial class Client_Orders : Page
    {
        public static VTManagerDialog warn_msg;
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
                order_number_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
            if (string.IsNullOrWhiteSpace(initials_field.Text))
            {
                initials_field.Text = "фио клиента...";
                initials_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
            if (string.IsNullOrWhiteSpace(vt_field.Text))
            {
                vt_field.Text = "радиолампа...";
                vt_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
            if (order_date_field.Text.Contains("-"))
            {
                order_date_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
        }
        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            string search = VTDataGridQueries.ordersQuery + " WHERE date LIKE " + "\'" + order_date_field.Text + "%\'";
            string filters = (!(order_number_field.Text == "№ заказа...")) ?
                search += " AND shopcart_vacushop.id = " + order_number_field.Text.Trim(StringUtils.trimmer)
                : (!(vt_field.Text == "радиолампа...")) ?
                    search += " AND shopcart_vacushop.name LIKE " + "\'" + vt_field.Text.Trim(StringUtils.trimmer) + "%\'"
                        : (!(initials_field.Text == "фио клиента...")) ?
                            search += " AND dle_users.fullname LIKE " + "\'" + initials_field.Text.Trim(StringUtils.trimmer) + "%\'"
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
                order_number_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
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
                vt_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
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
                initials_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
        }
        private void initials_field_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!Char.IsLetterOrDigit(e.Text, 0)) e.Handled = true;
        }
        private void erase_button_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data_row = (DataRowView)orders_dg.SelectedItem;
            string checkd = data_row.Row.ItemArray[6].ToString();
            string id = data_row.Row.ItemArray[0].ToString();
            string fullname = data_row.Row.ItemArray[1].ToString();
            string price = data_row.Row.ItemArray[4].ToString();
            try {
                if (!(checkd.Equals("True"))) {
                    SQLUtils.runQuery("DELETE FROM shopcart_vacushop WHERE id = " + id.Trim());
                    SQLUtils.runQuery("UPDATE dle_users SET money = (money + " + price + ") WHERE fullname = " + "\'" + fullname.Trim() + "\'");
                    debug_textbox.Text = "Заказ № " + id.Trim() + " успешно отменён.";
                } else {
                    warn_msg = new VTManagerDialog();
                    warn_msg.dialog_label.Content = "Внимание";
                    warn_msg.contained_info.Text = "Завершенный заказ нельзя отменить";
                    warn_msg.Show();
                }
            } catch (System.NullReferenceException) { debug_textbox.Text = "Выберите запись в таблице!"; }
        }
        private void done_button_Click(object sender, RoutedEventArgs e)
        {
            Label t1 = new Label(); Label t2 = new Label();
            DataRowView data_row = (DataRowView)orders_dg.SelectedItem;
            try {
                string checkd = data_row.Row.ItemArray[6].ToString();
                string id = data_row.Row.ItemArray[0].ToString();
                string mark = data_row.Row.ItemArray[3].ToString();
                if (!(checkd.Equals("True"))) {
                    SQLUtils.runQuery("SELECT amount AS amount FROM shopcart_vacushop WHERE id = \"" + id + "\"", "amount", t1);
                    string the_amount = t1.Content.ToString().Trim();
                    SQLUtils.runQuery("SELECT vt.id as id FROM vt WHERE mark = \"" + mark + "\" ", "id", t2);
                    try {
                        SQLUtils.runQuery("SELECT vt_lots.count as id FROM vt_lots WHERE vtId = " + t2.Content.ToString().Trim(), "id", t1);
                        if (Convert.ToInt32(t1.Content.ToString()) >= Convert.ToInt32(the_amount)) {
                            SQLUtils.runQuery("UPDATE vt_lots SET count = (count - " + the_amount + ") WHERE vtId = " + t2.Content.ToString().Trim() + "; UPDATE shopcart_vacushop SET solved = 1 WHERE id = " + id);
                            debug_textbox.Text = "Заказ № " + id.Trim() + " успешно завершён.";
                        } else {
                            debug_textbox.Text = "Недостаточно номенклатуры на складе";
                        }
                    }
                    catch (System.NullReferenceException) { debug_textbox.Text = "Наличие партии не согласовано! Уточните информацию у кладовщика"; }
                } else {
                    warn_msg = new VTManagerDialog();
                    warn_msg.dialog_label.Content = "Внимание";
                    warn_msg.contained_info.Text = "Заказ уже был завершен";
                    warn_msg.Show();
                }
            } catch (System.NullReferenceException) { debug_textbox.Text = "Выберите запись в таблице!"; }
        }
    }
}