using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApp1.ProcssingPages
{
    /// <summary>
    /// Логика взаимодействия для Processing_Add.xaml
    /// </summary>
    public partial class Processing_Add : Page
    {
        public Processing_Add()
        {
            InitializeComponent();
        }
        /*Объекты лейблов под выполняемые запросы*/
        public Label t1 = new Label();
        public Label t2 = new Label();
        /*Текущее время*/
        readonly DateTime theDate = DateTime.Now;
        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            string markValue = select_vt_cbox.SelectedItem.ToString();
            SQLUtils.runQuery("SELECT vt.id AS ids FROM vt WHERE mark = " + "\"" + markValue + "\" ", "ids", t1);
            string personalValue = select_personal_cbox.SelectedItem.ToString();
            SQLUtils.runQuery("SELECT personal.id AS ids FROM personal WHERE firstName = " + "\"" + personalValue + "\" ", "ids", t2);
            string markIdValue = t1.Content.ToString();
            string personalIdValue = t2.Content.ToString();
            string insertValues = "(NULL, 1, " + personalIdValue + ", " + markIdValue + ", " + shift_field.Text + ", \'" + theDate.ToString("yyyy-MM-dd") +"\', " + plan_field.Text + ", "+ count_field.Text + ", 0, 0)";
            if (shift_field.Text != "№ смены..." && plan_field.Text != "раб.план" && count_field.Text != "кол-во")
            {
                SQLUtils.runQuery(VTDataGridQueries.addPlan + insertValues);
                debug_textbox.Text = "Рабочий план № " + shift_field.Text + " успешно создан.";
            }
            else debug_textbox.Text = "Заполните все поля!";
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {                            /*  Плейсхолдеры    */
            if (string.IsNullOrWhiteSpace(shift_field.Text))
            {
                shift_field.Text = "№ смены...";
                shift_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
            if (string.IsNullOrWhiteSpace(plan_field.Text))
            {
                plan_field.Text = "раб.план";
                plan_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
            if (string.IsNullOrWhiteSpace(count_field.Text))
            {
                count_field.Text = "кол-во";
                count_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
            /*Лампа выбранная при загрузке формы*/
            select_vt_cbox.SelectedIndex = 0;
            /*Сотрудник выбранный при загрузке формы*/
            select_personal_cbox.SelectedIndex = 0;
            string vtNames = "SELECT mark AS mark FROM vt WHERE id = ";
            /*  Заполняет комбобокс всеми видами ламп из бд. 
                id в таблице с марками ламп начинаются с 2*/
            SQLUtils.fillCombobox(2, VTDataGridQueries.totalVtMarks, "marks_count", vtNames, "mark", select_vt_cbox);
            /*Рекурсивный запрос. Выбирает все id персонала, являющегося Радиотехником или инженером-радиотехником*/
            SQLUtils.runRecursiveQuery(VTDataGridQueries.totalProcessingPersonal, "processing_personal", t1);
            string personalCountStr = t1.Content.ToString();
            /*Коллекция с выбранными id специалистов*/
            List<string> personalid = new List<string>();
            /*Разрезает сплошной результат рекурсивного запроса на отдельные записи из БД и записывает в коллекцию ниже */
            foreach (string s in personalCountStr.Split('&'))
                personalid.Add(s);
            /*Коллекция с фамилиями персонала*/
            ArrayList personal = new ArrayList();
            for (int id = 0; id <= personalid.Count - 2; id++)
            {
                SQLUtils.runQuery("SELECT firstName AS name FROM personal WHERE id = " + personalid[id], "name", t1);
                string namesCountStr = t1.Content.ToString();
                personal.Add(namesCountStr);
            }
            /*Заполнение комбобокса персонала*/
            for (int c = 0; c <= personalid.Count - 2; c++)
                select_personal_cbox.Items.Add(personal[c].ToString());
            /*Показывает таблицу с данными о всех незакрытых сменах*/
            SQLUtils.showTable(VTDataGridQueries.unsolvedProcessingQuery, VTManagerConfig.unsolvedCols, unsolved_plans_dg);
        }
        private void export_button_Click(object sender, RoutedEventArgs e)
        {
            ExportUtils.exportToExcel(unsolved_plans_dg, page_header.Content.ToString().Trim(), "F");
        }
        private void print_button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog pd = new System.Windows.Controls.PrintDialog();
            if ((bool)pd.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(pd.PrintableAreaWidth, pd.PrintableAreaHeight);
                unsolved_plans_dg.Measure(pageSize);
                unsolved_plans_dg.Arrange(new Rect(15, 15, pageSize.Width, pageSize.Height));
                pd.PrintVisual(unsolved_plans_dg, Title);
                ProcessingPage.ThisFrame.Refresh();
            }
        }
        private void shift_field_GotFocus(object sender, RoutedEventArgs e)
        {
            if (shift_field.Text == "№ смены...")
            {
                shift_field.Text = "";
                shift_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void shift_field_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(shift_field.Text))
            {
                shift_field.Text = "№ смены...";
                shift_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
        }
        private void shift_field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
        private void plan_field_GotFocus(object sender, RoutedEventArgs e)
        {
            if (plan_field.Text == "раб.план")
            {
                plan_field.Text = "";
                plan_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void plan_field_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(plan_field.Text))
            {
                plan_field.Text = "раб.план";
                plan_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
        }
        private void plan_field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
        private void count_field_GotFocus(object sender, RoutedEventArgs e)
        {
            if (count_field.Text == "кол-во")
            {
                count_field.Text = "";
                count_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void count_field_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(count_field.Text))
            {
                count_field.Text = "кол-во";
                count_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)151, (byte)170, (byte)222));
            }
        }
        private void count_field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

    }
}