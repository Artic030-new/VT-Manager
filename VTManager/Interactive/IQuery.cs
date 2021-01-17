using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTManager.Interactive
{
    interface IQuery {
        string selectSum(String sum_col, String az, String from);
        string selectCount(String name, String from, String where);
        string selectCountInTons(String name, String from, String where);
        string selectCountEntry(String az, String from);
        string selectJoinCount(String name, String from, String join, String idColumn, String where);
        string delete(String name, String from, String where);
    }
}
