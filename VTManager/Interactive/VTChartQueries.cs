using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Interactive
{
    class VTChartQueries
    {
        /* Запросы к диаграммам сделанных ламп*/
        public static string totalProductionQuery = "SELECT fact, SUM(fact) AS all_vt FROM processing";
        public static string totalLossQuery = "SELECT fact, SUM((fact) * 0.1 / 125.349577464324) AS all_vt FROM processing"; /*Отлов брака*/
        public static string totalPentode = "SELECT Sum(fact) AS all_vt FROM vt JOIN processing ON vt.id = processing.vtId WHERE vt.vtType = \"Пентод\"";
        public static string totalTriode = "SELECT Sum(fact) AS all_vt FROM vt JOIN processing ON vt.id = processing.vtId WHERE vt.vtType = \"Триод\"";
        public static string totalTriode2 = "SELECT Sum(fact) AS all_vt FROM vt JOIN processing ON vt.id = processing.vtId WHERE vt.vtType = \"Триод-Гептод\"";
        public static string totalDoubleDiode = "SELECT Sum(fact) AS all_vt FROM vt JOIN processing ON vt.id = processing.vtId WHERE vt.vtType = \"Двойной диод\"";
        public static string totalCenotrone = "SELECT Sum(fact) AS all_vt FROM vt JOIN processing ON vt.id = processing.vtId WHERE vt.vtType = \"Кенотрон\"";
        /* Запросы к диаграммам остатка ресурсов*/
        public static string totalSand = "SELECT (count / 1000.00) AS sand_count FROM storage_contains WHERE resourceId = 1";
        public static string totalSilicon = "SELECT (count / 1000.00) AS silicon_count FROM storage_contains WHERE resourceId = 2";
        public static string totalGraphene = "SELECT count AS graphene_count FROM storage_contains WHERE resourceId = 3";
        public static string totalBGlass = "SELECT count AS bglass_count FROM storage_contains WHERE resourceId = 4";
        public static string totalBA = "SELECT count AS BA_count FROM storage_contains WHERE resourceId = 5";
        public static string totalEC = "SELECT count AS EC_count FROM storage_contains WHERE resourceId = 6";
        public static string totalAcetone = "SELECT count AS acetone_count FROM storage_contains WHERE resourceId = 8";
        /* Запросы к диаграммам статистики продаж*/
        public static string totalSaled = "SELECT Sum(count) AS all_sales FROM orders";
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
        public static string storedMk2 = "SELECT vt_lots.count AS mk FROM vt_lots JOIN vt ON vt.id = vtId WHERE vt.mark = \"6К4\"";
        public static string storedMk3 = "SELECT vt_lots.count AS mk FROM vt_lots JOIN vt ON vt.id = vtId WHERE vt.mark = \"6К7\"";
        public static string storedMk4 = "SELECT vt_lots.count AS mk FROM vt_lots JOIN vt ON vt.id = vtId WHERE vt.mark = \"6Ж3\"";
        public static string storedMk5 = "SELECT vt_lots.count AS mk FROM vt_lots JOIN vt ON vt.id = vtId WHERE vt.mark = \"6С1П\"";
        public static string storedMk6 = "SELECT vt_lots.count AS mk FROM vt_lots JOIN vt ON vt.id = vtId WHERE vt.mark = \"6С2С\"";
        public static string storedMk7 = "SELECT vt_lots.count AS mk FROM vt_lots JOIN vt ON vt.id = vtId WHERE vt.mark = \"6И1П\"";
        public static string storedMk8 = "SELECT vt_lots.count AS mk FROM vt_lots JOIN vt ON vt.id = vtId WHERE vt.mark = \"6Х2П\"";
        public static string storedMk9 = "SELECT vt_lots.count AS mk FROM vt_lots JOIN vt ON vt.id = vtId WHERE vt.mark = \"6Х6С\"";
        public static string storedMk10 = "SELECT vt_lots.count AS mk FROM vt_lots JOIN vt ON vt.id = vtId WHERE vt.mark = \"6Ц10П\"";
    }

}
