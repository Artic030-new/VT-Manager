using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VTManager
{
    [Serializable]
    public class VTManagerConfig
    {

        /* Адрес директории, содержащей файл конфигурации */
        public static string config = "C:\\VTManager\\";
        /* Название файла конфигурации пользователя*/
        public static string config_file = "userdata.json";
        /* Название файла конфигурации базы данных*/
        public static string db_config_file = "vtmanager.json";

        [JsonPropertyName("serverData")]
        public VTManager_ServerData ServerData { get; set; }
        [JsonPropertyName("userData")]
        public VTManager_UserData UserData { get; set; }
        [JsonPropertyName("standarts")]
        public VTManager_Standarts Standarts { get; set; }
        [JsonPropertyName("settings")]
        public VTManager_Settings Settings { get; set; }

        public static VTManagerConfig vt_empty = new VTManagerConfig
        {
            ServerData = new VTManager_ServerData
            {
                Database = "vtmanager",
                Host = "localhost",
                User = "root",
                WebServer = @"http://vtmanager.ru/"
            },
            Standarts = new VTManager_Standarts
            {
                LossRatio = 125.34M,
                OrcglassCost = 0.17M,
                PtPfCost = 0.09M,
                SandCost = 13.73M,
                SiliconeCost = 5.46M,
                SteelCost = 14.0M
            },
            Settings = new VTManager_Settings
            {
                CallTimeout = 900
            }
        };
        public static VTManagerConfig CreateConfig()
        {
            try
            {
                if (File.Exists(config + db_config_file))
                {
                    return JsonConvert.DeserializeObject<VTManagerConfig>(File.ReadAllText(config + db_config_file));
                }
                else
                {
                    return vt_empty;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
    }
    [Serializable]
    public class VTManager_ServerData
    {
        public string WebServer { get; set; }
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
    }
    [Serializable]
    public class VTManager_UserData
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public bool KeepEntry { get; set; }
    }
    [Serializable]
    public class VTManager_Standarts
    {
        public decimal LossRatio { get; set; }
        public decimal SandCost { get; set; }
        public decimal SiliconeCost { get; set; }
        public decimal SteelCost { get; set; }
        public decimal OrcglassCost { get; set; }
        public decimal PtPfCost { get; set; }
    }
    [Serializable]
    public class VTManager_Settings
    {
        public int CallTimeout { get; set; }
    }
}
