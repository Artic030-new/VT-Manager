using System;
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
using System.Data;
using MySql.Data.MySqlClient;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Threading;
using System.Configuration;

namespace VTManager
{
    public class DataStreamUtils
    {

        public static void writeData(string k) {
            using (var writer = new StreamWriter(VTManagerConfig.config + VTManagerConfig.config_file)) {
                writer.WriteLine(k);
            }
        }
        public static void writeData(string l, string p, string k) {
            using (var writer = new StreamWriter(VTManagerConfig.config + VTManagerConfig.config_file)) {
                writer.WriteLine(l);
                writer.WriteLine(Convert.ToBase64String(Encoding.UTF8.GetBytes(p)));
                writer.WriteLine(k);
            }
        }
        /* Метод, читающий данные для входа из файла */
     
        /* Метод, записывающий состояние чекбокса "запомнить пароль" */
        public static string deactivateKeep() {
            using (var reader = new StreamReader(VTManagerConfig.config + VTManagerConfig.config_file))
            {
                string[] k = File.ReadAllLines(VTManagerConfig.config, Encoding.UTF8);
                if (k.Length > 3)
                    k[2] = "False";
                string g = k[2];
                return g;
            }
        }
    }
}
