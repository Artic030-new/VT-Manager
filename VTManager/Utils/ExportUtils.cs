using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using Excel = Microsoft.Office.Interop.Excel;
namespace WpfApp1
{
    class ExportUtils
    {
        public static Excel.Application runExcel() 
        {
           return new Excel.Application();
        }

        public static void exportToExcel(System.Windows.Controls.DataGrid dg, string table_name, string last_excel_row)
        {
            try
            {
                Excel.Application xcel = runExcel();
                Excel.Workbook wb = null;
                Excel.Worksheet ws = null;
                SaveFileDialog openDlg = new SaveFileDialog();
                openDlg.FileName = "Выгрузка из " + table_name;
                openDlg.Filter = "Excel Таблицы (.xls)|*.xls |Excel Таблицы (.xlsx)|*.xlsx";
                openDlg.FilterIndex = 2;
                openDlg.RestoreDirectory = true;
                    if (openDlg.ShowDialog() == DialogResult.OK)
                    {
                        xcel.DisplayAlerts = false;
                        wb = xcel.Workbooks.Add();
                        ws = wb.ActiveSheet;
                        dg.SelectAllCells();
                        dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                        ApplicationCommands.Copy.Execute(null, dg);
                        ws.Paste();
                        ws.Range["A1", "H1"].Font.Bold = true;
                        ws.Range["A1", "H1"].HorizontalAlignment = Excel.Constants.xlCenter;
                        int number1 = ws.UsedRange.Rows.Count;
                        Microsoft.Office.Interop.Excel.Range r = ws.Range["A1", last_excel_row + number1];
                        r.Borders.LineStyle = XlLineStyle.xlDouble;
                        r.WrapText = false;
                        r.Font.Size = 18;
                        ws.Columns.EntireColumn.AutoFit();
                        wb.SaveAs(openDlg.FileName);
                        xcel.Visible = true;
                    }
            }
            catch (Exception)
            {

            }
        }
      
    }
}
