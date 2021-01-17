using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using VTManager.Interactive;
using VTManager.Utils;

namespace VTManager
{
    public partial class Processing_Search : System.Windows.Controls.Page
    {
        public static VTManagerDialog warn_msg = new VTManagerDialog();
        public Processing_Search() {
            InitializeComponent();
        }

        public System.Windows.Controls.Label t1 = new System.Windows.Controls.Label();
        public System.Windows.Controls.Label t2 = new System.Windows.Controls.Label();
        private void search_button_Click(object sender, RoutedEventArgs e) {
            string search = VTDataGridQueries.processingQuery + " WHERE date LIKE " + "\'" + date_field.Text + "%\'";
            string filters = (!(personal_field.Text == "сотрудник...")) ?search += " AND firstName LIKE " + "\'" + StringUtils.replaceAllUnsupportedChr(personal_field.Text.Trim(StringUtils.trimmer)) + "%\'"
                : (!(vt_field.Text == "радиолампа...")) ?
                    search += " AND mark LIKE " + "\'" + StringUtils.replaceAllUnsupportedChr(vt_field.Text.Trim(StringUtils.trimmer)) + "%\'"
                        : (!(shift_field.Text == "№ смены...")) ?
                            search += " AND shift = " + StringUtils.replaceAllUnsupportedChr(shift_field.Text.Replace("№ смены...", "0"))
                                : (!(plan_field.Text == "раб.план")) ?
                                    search += " AND plan = " + StringUtils.replaceAllUnsupportedChr(plan_field.Text.Replace("раб.план", "0"))
                                        : search += "";
            SQLUtils.showTable(search, VTManagerConfig.planCols, processing_scores_dg);
            debug_textbox.Text = "Результат:  " + processing_scores_dg.Items.Count + StringUtils.computeSuffix(processing_scores_dg.Items.Count);
        }
        private void Page_Loaded(object sender, RoutedEventArgs e) {
            SQLUtils.showTable(VTDataGridQueries.processingQuery, VTManagerConfig.planCols, processing_scores_dg);
            /*                          Плэйсхолдеры                            */
            if (string.IsNullOrWhiteSpace(personal_field.Text)) {
                personal_field.Text = "сотрудник...";
                personal_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
            if (string.IsNullOrWhiteSpace(plan_field.Text)) {
                plan_field.Text = "раб.план";
                plan_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
            if (string.IsNullOrWhiteSpace(shift_field.Text)) {
                shift_field.Text = "№ смены...";
                shift_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
            if (string.IsNullOrWhiteSpace(vt_field.Text)) {
                vt_field.Text = "радиолампа...";
                vt_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
            if (date_field.Text.Contains("-")) {
                date_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
        }
        private void personal_field_GotFocus(object sender, RoutedEventArgs e) {
            if (personal_field.Text == "сотрудник...") {
                personal_field.Text = "";
                personal_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void personal_field_LostFocus(object sender, RoutedEventArgs e) {

            if (string.IsNullOrWhiteSpace(personal_field.Text)) {
                personal_field.Text = "сотрудник...";
                personal_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
        }
        private void wshop_field_GotFocus(object sender, RoutedEventArgs e) {
            if (plan_field.Text == "раб.план") {
                plan_field.Text = "";
                plan_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void wshop_field_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(plan_field.Text)) {
                plan_field.Text = "раб.план";
                plan_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
        }
        private void shift_field_GotFocus(object sender, RoutedEventArgs e) {
            if (shift_field.Text == "№ смены...") {
                shift_field.Text = "";
                shift_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void shift_field_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(shift_field.Text)) {
                shift_field.Text = "№ смены...";
                shift_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
        }
        private void vt_field_GotFocus(object sender, RoutedEventArgs e) {
            if (vt_field.Text == "радиолампа...") {
                vt_field.Text = "";
                vt_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
            }
        }
        private void vt_field_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(vt_field.Text)) {
                vt_field.Text = "радиолампа...";
                vt_field.Foreground = new SolidColorBrush(Color.FromArgb(255, 74, 91, 138));
            }
        }
        private void date_field_GotFocus(object sender, RoutedEventArgs e) {
            date_field.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)39, (byte)48, (byte)73));
        }
        private void plan_field_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
        private void shift_field_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
        private void personal_field_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }
        private void export_button_Click(object sender, RoutedEventArgs e) {
            ExportUtils.exportToExcel(processing_scores_dg, page_header.Content.ToString().Trim(), "H");
        }
        private void print_button_Click(object sender, RoutedEventArgs e) {
            System.Windows.Controls.PrintDialog pd = new System.Windows.Controls.PrintDialog();
            if ((bool)pd.ShowDialog().GetValueOrDefault()) {
                Size pageSize = new Size(pd.PrintableAreaWidth, pd.PrintableAreaHeight);
                processing_scores_dg.Measure(pageSize);
                processing_scores_dg.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                pd.PrintVisual(processing_scores_dg, Title);
                ProcessingPage.ThisFrame.Refresh();
            }
        }
        private void done_button_Click(object sender, RoutedEventArgs e) {
            Thread t = new Thread(solveAndStoreVts);
            /*Закрыть смену, списать использованный ресурс и занести готовые лампы на склад*/
            void solveAndStoreVts() {
                done_button.Dispatcher.BeginInvoke(new System.Action(delegate () {
                    string fact = Interaction.InputBox("Введите фактическое кол-во произведённых ламп: ");
                    DataRowView data_row = (DataRowView)processing_scores_dg.SelectedItem;
                    /*Получаем ряд в таблице, содержащий № смены, если он выбран*/
                    try {
                        string shiftValue = data_row.Row.ItemArray[0].ToString();
                        string markValue = data_row.Row.ItemArray[2].ToString();
                        string planValue = data_row.Row.ItemArray[5].ToString();
                        string factValue = data_row.Row.ItemArray[6].ToString();
                        /*Получаем ряд в таблице, содержащий чекбоксы*/
                        string checkd = data_row.Row.ItemArray[7].ToString();
                        /*  Выбираем количество всех типов ресурса для изготовления ламп  */
                        string allResourcesStr;
                        SQLUtils.runQuery("SELECT count(*) AS all_resources FROM storage_contains", "all_resources", t1);
                        allResourcesStr = t1.Content.ToString();
                        /*Записываем это количество как границу для цикла */
                        int allResources = int.Parse(allResourcesStr);
                        /*Проверяет если процесс не был завершён (не стоит галка в таблице)*/
                        if (!(checkd.Equals("True"))) {
                            bool is_number = int.TryParse(fact, out int n);
                            if (fact != "") {
                                if (is_number) {
                                    SQLUtils.runQuery("UPDATE processing SET done = 1 WHERE shift = " + shiftValue);
                                    SQLUtils.runQuery("UPDATE processing SET fact = " + fact + " WHERE shift = " + shiftValue);
                                    /*Коллекция со списком коэффициентов затрат для каждого ресурса*/
                                    ArrayList shiftCosts = new ArrayList();
                                    /*Предопределённый нулевой элемент коллекции, так как в базе данных ресурсы считаются с 1*/
                                    shiftCosts.Add("0.00");
                                    for (int resCostId = 1; resCostId <= allResources; resCostId++) {
                                        string s;
                                        /*Выбирает единицы затраты каждого resource.id*/
                                        SQLUtils.runQuery("SELECT costPerShift FROM resource WHERE id = " + resCostId, "costPerShift", t1);
                                        s = t1.Content.ToString();
                                        /*Добавляем каждую {resCostId}-ую затрату в  коллекцию выше*/
                                        shiftCosts.Add(s);
                                    } for (int resId = 1; resId <= allResources; resId++)
                                        /*Вычитаем затраченное количество со склада для каждого ресурса. Единицы затраты записаны в коллекцию*/
                                        SQLUtils.runQuery("UPDATE storage_contains SET count = (count - (" + planValue + "*" + Convert.ToString(shiftCosts[resId]).Replace(",", ".") + ") / 100) WHERE resourceId = " + resId);
                                    /*Прибавляем фактически изготовленную партию на склад*/
                                    SQLUtils.runQuery("UPDATE vt JOIN processing ON vt.id = processing.vtId JOIN vt_lots ON vt.id = vt_lots.vtId SET vt_lots.count = (vt_lots.count + " + fact + ") WHERE processing.shift = " + shiftValue + " AND vt.mark = " + "\"" + markValue + "\"");
                                    t1.IsEnabled = true;
                                    debug_textbox.Text = "Смена №" + shiftValue + " закрыта.\n";
                                } else debug_textbox.Text = "Параметр Факт должен быть числом > 0.";
                            } else debug_textbox.Text = "Значение Факт не указано.";
                        } else {
                            warn_msg.dialog_label.Content = "Внимание";
                            warn_msg.contained_info.Text = "Процесс уже был завершен";
                            warn_msg.Show();
                        }
                    } catch (System.NullReferenceException) { debug_textbox.Text = "Выберите запись в таблице!"; }
                }));
            }
            t.Name = "Идёт процесс закрытия смены...";
            t.Start();
    }

    }
}