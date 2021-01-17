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
        /* Запросы к диаграммам сделанных ламп*/
        public static string totalProductionQuery = "SELECT fact, SUM(fact) AS all_vt FROM processing";
        public static string totalLossQuery = "SELECT fact, SUM((fact) * 0.1 / 125.349577464324) AS all_vt FROM processing"; /*Отлов брака*/
        public static string totalPentode = "SELECT Sum(fact) AS all_vt FROM vt JOIN processing ON vt.id = processing.vtId WHERE vt.vtType = \"Пентод\"";
        public static string totalTriode = "SELECT Sum(fact) AS all_vt FROM vt JOIN processing ON vt.id = processing.vtId WHERE vt.vtType = \"Триод\"";
        public static string totalTriode2 = "SELECT Sum(fact) AS all_vt FROM vt JOIN processing ON vt.id = processing.vtId WHERE vt.vtType = \"Триод-Гептод\"";
        public static string totalDoubleDiode = "SELECT Sum(fact) AS all_vt FROM vt JOIN processing ON vt.id = processing.vtId WHERE vt.vtType = \"Двойной диод\"";
        public static string totalCenotrone = "SELECT Sum(fact) AS all_vt FROM vt JOIN processing ON vt.id = processing.vtId WHERE vt.vtType = \"Кенотрон\"";
        /* Запросы к диаграммам остатка ресурсов*/
        public static String totalDryMix(String itemName, int id) {
            return "SELECT (count / 1000.00) AS " + itemName + " FROM storage_contains WHERE resourceId = " + id.ToString();
        }
        public static String selectVt(String itemName) {
            return query.selectJoinCount("mk", "vt_lots", "vt", "vtId", "mark = \"" + itemName + "\"");
        }

        public static String selectDryMix(int id) {
            return query.selectCountInTons("mix", "storage_contains", "resourceId = " + id.ToString());
        }
        public static String selectResource(int id) {
            return query.selectCount("res", "storage_contains", "resourceId = " + id.ToString());
        }

        public static string totalSand = query.selectCountInTons("sand_count", "storage_contains", "resourceId = 1");
        public static string totalSilicon =  query.selectCountInTons("silicon_count", "storage_contains", "resourceId = 2");
        public static string totalGraphene = query.selectCount("graphene_count", "storage_contains", "resourceId = 3");  
        public static string totalBGlass = query.selectCount("bglass_count", "storage_contains", "resourceId = 4");
        public static string totalBA = query.selectCount("BA_count", "storage_contains", "resourceId = 5"); 
        public static string totalEC = query.selectCount("EC_count", "storage_contains", "resourceId = 6"); 
        public static string totalAcetone = query.selectCount("acetone_count", "storage_contains", "resourceId = 8");
        /* Запросы к диаграммам статистики продаж*/
        public static string totalSaled = query.selectSum("amount", "all_sales", "shopcart_vacushop");
        public static string totalClients = "SELECT count(*) AS all_clients FROM users";
        public static string totalOrders = "SELECT count(*) AS all_orders FROM orders";
        public static string totalMark1 = "SELECT sum(count) AS all_mk1 FROM orders WHERE vtId = 2";
        public static string totalMark2 = "SELECT sum(count) AS all_mk2 FROM orders WHERE vtId = 3";
        public static string totalMark3 = "SELECT sum(count) AS all_mk3 FROM orders WHERE vtId = 4";
        public static string totalMark4 = "SELECT sum(count) AS all_mk4 FROM orders WHERE vtId = 5";
        public static string totalSaledPentode = "SELECT Sum(count) AS all_vt FROM orders JOIN vt ON vt.id = orders.vtId WHERE vt.vtType = \"Пентод\"";
        public static string totalSaledTriode = "SELECT Sum(count) AS all_vt FROM orders JOIN vt ON vt.id = orders.vtId WHERE vt.vtType = \"Триод\"";
        public static string totalSaledDoubleDiode = "SELECT Sum(count) AS all_vt FROM orders JOIN vt ON vt.id = orders.vtId WHERE vt.vtType = \"Двойной диод\"";
        public static string totalSaledCenotrone = "SELECT Sum(count) AS all_vt FROM orders JOIN vt ON vt.id = orders.vtId WHERE vt.vtType = \"Кенотрон\"";
        /* Запросы к диаграммам хранимых на складе радиоламп*/
    /*    public static string storedMk2 = selectVt("6К4");
        public static string storedMk3 = query.selectJoinCount("mk", "vt_lots", "vt", "vtId", "mark = \"6К7\"");
        public static string storedMk4 = query.selectJoinCount("mk", "vt_lots", "vt", "vtId", "mark = \"6Ж3\"");
        public static string storedMk5 = query.selectJoinCount("mk", "vt_lots", "vt", "vtId", "mark = \"6С1П\"");
        public static string storedMk6 = query.selectJoinCount("mk", "vt_lots", "vt", "vtId", "mark = \"6С2С\"");
        public static string storedMk7 = query.selectJoinCount("mk", "vt_lots", "vt", "vtId", "mark = \"6И1П\"");
        public static string storedMk8 = query.selectJoinCount("mk", "vt_lots", "vt", "vtId", "mark = \"6Х2П\"");
        public static string storedMk9 = query.selectJoinCount("mk", "vt_lots", "vt", "vtId", "mark = \"6Х6С\"");
        public static string storedMk10 = query.selectJoinCount("mk", "vt_lots", "vt", "vtId", "mark = \"6Ц10П\"");*/
    }

}
