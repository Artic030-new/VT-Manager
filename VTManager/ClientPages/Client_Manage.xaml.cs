﻿using System;
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
using WpfApp1.Utils;
using WpfApp1.Interactive;

namespace WpfApp1.ClientPages
{
    /// <summary>
    /// Логика взаимодействия для Client_Manage.xaml
    /// </summary>
    public partial class Client_Manage : Page
    {
        public Client_Manage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SQLUtils.showTable(VTDataGridQueries.clientsQuery, VTManagerConfig.clientCols, clients_dg);
            /*                          Плэйсхолдеры                            */
            if (string.IsNullOrWhiteSpace(firstname_field.Text))
            {
                firstname_field.Text = "фамилия...";
                firstname_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
            if (string.IsNullOrWhiteSpace(lastname_field.Text))
            {
                lastname_field.Text = "имя...";
                lastname_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
            if (string.IsNullOrWhiteSpace(thirdname_field.Text))
            {
                thirdname_field.Text = "отчество...";
                thirdname_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
            if (string.IsNullOrWhiteSpace(email_field.Text))
            {
                email_field.Text = "эл.почта...";
                email_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
        }
        private void firstname_field_GotFocus(object sender, RoutedEventArgs e)
        {
            if (firstname_field.Text == "фамилия...")
            {
                firstname_field.Text = "";
                firstname_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void firstname_field_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstname_field.Text))
            {
                firstname_field.Text = "фамилия...";
                firstname_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
        }
        private void firstname_field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }
        private void lastname_field_GotFocus(object sender, RoutedEventArgs e)
        {
            if (lastname_field.Text == "имя...")
            {
                lastname_field.Text = "";
                lastname_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void lastname_field_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lastname_field.Text))
            {
                lastname_field.Text = "имя...";
                lastname_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
        }
        private void lastname_field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }
        private void thirdname_field_GotFocus(object sender, RoutedEventArgs e)
        {
            if (thirdname_field.Text == "отчество...")
            {
                thirdname_field.Text = "";
                thirdname_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void thirdname_field_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(thirdname_field.Text))
            {
                thirdname_field.Text = "отчество...";
                thirdname_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
        }
        private void thirdname_field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }
        private void email_field_GotFocus(object sender, RoutedEventArgs e)
        {
            if (email_field.Text == "эл.почта...")
            {
                email_field.Text = "";
                email_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void email_field_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(email_field.Text))
            {
                email_field.Text = "эл.почта...";
                email_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
        }
     
        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            string initials = "", email = "";
            string initialsif = (!(firstname_field.Text == "фамилия...")) ?
                initials += StringUtils.replaceAllUnsupportedChr(firstname_field.Text.Trim(StringUtils.trimmer))
                : (!(lastname_field.Text == "имя...")) ?
                    initials += StringUtils.replaceAllUnsupportedChr(lastname_field.Text.Trim(StringUtils.trimmer))
                    : (!(thirdname_field.Text == "отчество...")) ?
                        initials += StringUtils.replaceAllUnsupportedChr(thirdname_field.Text.Trim(StringUtils.trimmer))
                        : initials += "";
            string emailif = (!(email_field.Text == "эл.почта...")) ?
                email += email_field.Text : email += "";
            string search = VTDataGridQueries.clientsQuery + " WHERE fullName LIKE " + "\'%" + initials + "%\' AND email LIKE \'%" + email + "%\'";
            SQLUtils.showTable(search, VTManagerConfig.clientCols, clients_dg);
            debug_textbox.Text = "Результат:  " + clients_dg.Items.Count + StringUtils.computeSuffix(clients_dg.Items.Count);
        }
        private void sec_button_Click(object sender, RoutedEventArgs e)
        {
            Label res1 = new Label();
            Label res2 = new Label();
            DataRowView data_row = (DataRowView)clients_dg.SelectedItem;
            try
            {
                string selected_name = data_row.Row.ItemArray[1].ToString();
                if (selected_name.Length > 0)
                {
                    SQLUtils.runQuery("SELECT phone AS phone FROM users WHERE fullName = " + "\"" + selected_name + "\"", "phone", res1);
                    SQLUtils.runQuery("SELECT address AS address FROM users WHERE fullName = " + "\"" + selected_name + "\"", "address", res2);
                    debug_textbox.Text = "Моб. телефон клиента " + selected_name + " : " + res1.Content.ToString() + "\n" + "Адрес клиента " + selected_name + " : " + res2.Content.ToString();
                }
            }
            catch (System.NullReferenceException)
            {
                debug_textbox.Text = "Клиент не выбран.";
            }
        }
        private void ban_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView data_row = (DataRowView)clients_dg.SelectedItem;
                string selected_name = data_row.Row.ItemArray[1].ToString();
                if (selected_name.Length > 0)
                    SQLUtils.runQuery("UPDATE users SET ban = 1 WHERE fullName = " + "\"" + selected_name + "\"");
            }
            catch (System.NullReferenceException)
            {
                debug_textbox.Text = "Клиент не выбран.";
            }
        }
    }
}