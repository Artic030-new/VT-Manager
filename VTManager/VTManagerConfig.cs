using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTManager
{
    class VTManagerConfig
    {
        /*******************        Данные для подключения      ************************/
        /* Адрес сервера для подключения приложения к БД */
        public static string server = "http://vtmanager.ru/";
        /* Адрес директории, содержащей файл конфигурации */
        public static string config = "C:\\VTManager\\";
        /* Название файла конфигурации */
        public static string config_file = "userdata.vtcfg"; 
        /*Данные для подключения к БД*/
        public static string host = "localhost;";
        public static string user = "root;";
        public static string password = ";";
        public static string database = "vtmanager";
        public static string data = "server=" + host + "user=" + user + "password=" + password + "database=" + database;
        /********************      Вывод табличных рядов        **********************/
            /* Выводимые поля в поиске работ*/
        public static string[] planCols = { "Смена", "Cотрудник", "Марка", "Дата", "Количество", "План", "Факт", "Завершен" };
            /* Выводимые поля незавершенных работ*/
        public static string[] unsolvedCols = { "Смена", "Cотрудник", "Марка", "Дата", "Количество", "План"};
        /* Выводимые поля клиентов*/
        public static string[] clientCols = { "Логин", "ФИО", "Почта"};
        /*  Выводимые поля заказов  */
        public static string[] ordersCols = { "№ заказа", "ФИО клиента", "Количество", "Марка", "Стоимость заказа", "Дата", "Завершен" };
        /*  Выводимые поля поставщиков  */
        public static string[] providersCols = { "ФИО", "Телефон", "Почта" };
        public static string[] deliveriesCols = { "№ поставки",  "Дата", "Поставщик", "Материал", "Количество", "Принят", "Завершен" };
        public static string[] deliveryCols = { "Поставщик", "Материал", "Сотрудник", "Кол-во", "Дата"};
        /* Выводимые поля готовой продукции*/
        public static string[] vtsCols = {"Марка", "Количество", "Склад" };
    }
}