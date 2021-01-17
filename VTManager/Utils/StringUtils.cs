using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTManager
{
    class StringUtils
    {
        /* Универсальный отсеиватель лишних символов. Используется как параметр для метода Trim(); */
        public static char[] trimmer = { ' ', '.', ',', '*', '-', '=', '+', '/', '\\', '\'', '`', '!', '@', '#', '$', '%', '^', '&', '(', ')', '_', '[', ']', '<', '>', '?', '№', ';', '|' };
        /* Адрес сервера для подключения приложения к БД */
        public static string mainUrl = VTManagerConfig.server;
        /* Возвращает путь к любому php файлу на сервере */
        public static string buildFileUrl(string fUrl) {
            return mainUrl + fUrl;
        }
        public static string computeSuffix(int i) {
            int last = i % 100 / 10;
            if (last == 1)
                return " Запись";
            switch (i % 10) {
                case 1:
                    return " Запись";
                case 2:
                case 3:
                case 4:
                    return " Записи";
                default:
                    return " Записей";
            }
        }
        // Удаляет все запрещённые для ввода символы
        public static string replaceAllUnsupportedChr(string s) {
            StringBuilder sb = new StringBuilder(s.Length);
            foreach (char c in s) {
                switch (c) {
                    case '\t': case '\n': case '-': case '+':
                    case '=': case '.': case ',': case ':':
                    case ';': case '(': case ')': case '{':
                    case '}': case '[': case ']': case '!':
                    case '#': case '$': case '%': case '^': 
                    case '&': case '*': case '\\':case '/':
                    case '\"': case '\'': case '|': case '`':
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }
    }
}
