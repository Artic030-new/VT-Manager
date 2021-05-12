using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VTManager.Interactive;

namespace VTManager.Utils
{
    class SQLUtils
    {
        public static void runQuery(string query) {
            //Открывает соединение, выполняет запрос к базе и закрывает соединение.
            MySqlConnection cn = new MySqlConnection(VTManagerConfig.data);
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;
            cmd.Connection = cn;
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            cn.Close();
        }
        public static void runQuery(string query, string v) {
            //Открывает соединение, выполняет запрос к базе и закрывает соединение.
            MySqlConnection cn = new MySqlConnection(VTManagerConfig.data);
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;
            cmd.Connection = cn;
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            cn.Close();
        }
        public static void runQuery(string query, string target_column, System.Windows.Controls.Label source) {
            /*Вторая перегрузка метода. Открывает соединение, выполняет запрос к базе и хранит результат в Метке.
             Можно получить только первое по счёту поле полученных данных*/
            MySqlConnection cn = new MySqlConnection(VTManagerConfig.data);
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;
            cmd.Connection = cn;
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            if (reader.Read()) source.Content = reader[target_column].ToString();
            cn.Close();
        }

        public static void runQuery(string query, string target_column, VTManager.Interactive.VTManagerChart source)
        {
            /*Третья перегрузка метода. Тоже самое, что и вторая, но записывает ЧИСЛОВЫЕ данные в контрол рейтинга
             Используется для красивого вывода статистики, например.*/
            MySqlConnection cn = new MySqlConnection(VTManagerConfig.data);
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;
            cmd.Connection = cn;
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                bool b = double.TryParse(reader[target_column].ToString(), out _);
                if (b) source.Value = double.Parse(reader[target_column].ToString());
            }
            cn.Close();
        }

        public static void fillStatistics(Page chartsPage) {
       //     runQuery();
        }

        public static void runRecursiveQuery(string query, string target_column, System.Windows.Controls.Label source) {
            /*Рекурсивный метод запроса. Читает все выбранные данные с помощью запроса и хранит в Метке сплошным потоком строк
                & - как разделитель каждого кортежа в потоке полученных данных.
                можно разрезать на массив строк используя split('&');         */
            MySqlConnection cn = new MySqlConnection(VTManagerConfig.data);
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;
            cmd.Connection = cn;
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            while (reader.Read()) source.Content += reader[target_column].ToString() + "&";
            cn.Close();
        }
        public static void showTable(string query, string[] cols_in_query, System.Windows.Controls.DataGrid source) {
            /*Заполняет Сетку Данных с помощью SQL запроса. Для заполнения требуется указать:
             1 - запрос на выборку всех данных
             2 - массив названий колонок с таким же количеством колонок в запросе  
             3 - сама Сетка Данных      */
            MySqlConnection cn = new MySqlConnection(VTManagerConfig.data);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = query;
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            for (int с = 0; с < cols_in_query.Length; ++с)
                dt.Columns[с].ColumnName = cols_in_query[с].ToString();
            source.ItemsSource = dt.DefaultView;
            cn.Close();
        }
        public static void fillCombobox(int startId, string totalIdsQuery, string targetColInQuery, string outputColumnQuery, string targetColInQuery2, ComboBox cb) {
            /*Заполняет комбобокс значениями желаемого табличного поля, читая id от 1 до конца. 
            параметр 1 - начальный id с которого начинается подбор (используется в крайнем случае, лучше всегда с 1)
            параметр 2 - Запрос считающий количество записей в таблице (все id в таблице)
            параметр 3 - Целевая колонка запроса (название после sql инструкции AS)
            параметр 4 - Запрос получающий колонку по ключу (id). Например: Получаем список name[i] по id[i]
            параметр 5 - Целевая колонка запроса(название после sql инструкции AS)
            параметр 6 - Комбобокс, который должен быть заполнен name's-ами */
            Label l = new Label();
            SQLUtils.runQuery(totalIdsQuery, targetColInQuery, l);
            string resCountStr = l.Content.ToString();
            int resCount = int.Parse(resCountStr);
            l.Content = "";
            for (int id = startId; id <= resCount + (startId - 1); id++) {
                SQLUtils.runQuery(outputColumnQuery + id, targetColInQuery2, l);
                string currentResStr = l.Content.ToString();
                cb.Items.Add(currentResStr);
            }
        }
    }
}