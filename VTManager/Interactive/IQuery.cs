using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTManager.Interactive
{
    interface IQuery {
        string select(String selectors, String from);
        string selectAll(String from);
        string selectSum(String sum_col, String az, String from);
        string selectCount(String name, String from, String where);
        string selectCountAll(String az, String from);
        string selectCountInTons(String name, String from, String where);
        string selectCountEntry(String az, String from);
        string selectJoinSum(String sum_col, String az, String from, String join, String idColumn, String where);
        string selectJoinCount(String name, String from, String join, String idColumn, String where);
        string delete(String name, String from, String where);
        string update(String table, String updateColumn, String where);
    }
}
