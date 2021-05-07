using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTManager.Interactive
{
    class VTChartQueries
    {
        public static VTQuery query = new VTQuery();
        /* Вспомогательные реализации запросов */
        public static String totalDryMix(String itemName, int id)
        {
            return "SELECT (count / 1000.00) AS " + itemName + " FROM storage_contains WHERE resourceId = " + id.ToString();
        }
        public static String selectVt(String itemName)
        {
            return query.selectJoinCount("mk", "vt_lots", "vt", "vtId", "mark = \"" + itemName + "\"");
        }
        public static String selectDryMix(int id)
        {
            return query.selectCountInTons("mix", "storage_contains", "resourceId = " + id.ToString());
        }
        public static String selectResource(int id)
        {
            return query.selectCount("res", "storage_contains", "resourceId = " + id.ToString());
        }

        /* Запросы к диаграммам сделанных ламп*/
        public static string totalProductionQuery = query.selectSum("fact", "all_vt", "processing");
        public static string totalLossQuery = "SELECT fact, SUM((fact) * 0.1 / 125.349577464324) AS all_vt FROM processing"; /*Отлов брака*/

        public static string totalPentode = query.selectJoinSum("fact", "all_vt", "vt", "processing", "vtId", "vtType = \"Пентод\"");
        public static string totalTriode = query.selectJoinSum("fact", "all_vt", "vt", "processing", "vtId", "vtType = \"Триод\"");
        public static string totalTriode2 = query.selectJoinSum("fact", "all_vt", "vt", "processing", "vtId", "vtType = \"Триод-Гептод\"");
        public static string totalDoubleDiode = query.selectJoinSum("fact", "all_vt", "vt", "processing", "vtId", "vtType = \"Двойной диод\"");
        public static string totalCenotrone = query.selectJoinSum("fact", "all_vt", "vt", "processing", "vtId", "vtType = \"Кенотрон\"");

        public static string totalSand = query.selectCountInTons("sand_count", "storage_contains", "resourceId = 1");
        public static string totalSilicon =  query.selectCountInTons("silicon_count", "storage_contains", "resourceId = 2");
        public static string totalGraphene = query.selectCount("graphene_count", "storage_contains", "resourceId = 3");  
        public static string totalBGlass = query.selectCount("bglass_count", "storage_contains", "resourceId = 4");
        public static string totalBA = query.selectCount("BA_count", "storage_contains", "resourceId = 5"); 
        public static string totalEC = query.selectCount("EC_count", "storage_contains", "resourceId = 6"); 
        public static string totalAcetone = query.selectCount("acetone_count", "storage_contains", "resourceId = 8");

        public static string totalSaled = query.selectSum("amount", "all_sales", "shopcart_vacushop");

        public static string totalClients = query.selectCountAll("all_clients", "users");
        public static string totalOrders = query.selectCountAll("all_orders", "orders");

        public static string totalMark1 = query.selectSum("count", "all_mk1", "orders", "vtId = 2");
        public static string totalMark2 = query.selectSum("count", "all_mk2", "orders", "vtId = 3");
        public static string totalMark3 = query.selectSum("count", "all_mk3", "orders", "vtId = 4");
        public static string totalMark4 = query.selectSum("count", "all_mk4", "orders", "vtId = 5");

        public static string totalSaledPentode = query.selectJoinSum("count", "all_vt", "vt", "orders", "vtId", "vtType = \"Пентод\"");
        public static string totalSaledTriode = query.selectJoinSum("count", "all_vt", "vt", "orders", "vtId", "vtType = \"Триод\"");
        public static string totalSaledDoubleDiode = query.selectJoinSum("count", "all_vt", "vt", "orders", "vtId", "vtType = \"Двойной диод\"");
        public static string totalSaledCenotrone = query.selectJoinSum("count", "all_vt", "vt", "orders", "vtId", "vtType = \"Кенотрон\"");

    }

}
