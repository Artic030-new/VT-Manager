﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTManager.Interactive
{
     public class VTQuery : IQuery, IChartable {
        public string selectAll(String from)
        {
            return "SELECT * FROM " + from;
        }
        public string select(String selectors, String from)
        {
            return "SELECT " + selectors + " FROM " + from;
        }
        public string select(String selector, String az, String from, String where)
        {
            return "SELECT " + selector + " AS " + az + " FROM " + from + " WHERE " + where;
        }
        public string selectCount(String name, String from, String where)
        {
            return "SELECT count AS " + name + " FROM " + from + " WHERE " + where;
        }
        public string selectCountAll(string az, string from)
        {
            return "SELECT count(*) AS " + az + " FROM " + from;
        }
        public string selectCountInTons(String name, String from, String where)
        {
            return "SELECT (count / 1000.00) AS " + name + " FROM " + from + " WHERE " + where;
        }
        public string selectCountEntry(String az, String from)
        {
            return "SELECT count(*) AS " + az + " FROM " + from;
        }
        public string selectJoinCount(String name, String from, String join, String idColumn, String where)
        {
            return "SELECT " + from + ".count AS " + name + " FROM " + from + " JOIN " + join + " ON " + join + ".id = " + idColumn + " WHERE " + join + "." + where;
        }
        public string selectSum(String sum_col, String az, String from)
        {
            return "SELECT Sum(" + sum_col + ") AS " + az + " FROM " + from;
        }
        public string selectSum(String sum_col, String az, String from, String where)
        {
            return "SELECT Sum(" + sum_col + ") AS " + az + " FROM " + from + " WHERE " + where;
        }
        public string selectJoinSum(String sum_col, String az, String from, String join, String idColumn, String where)
        {
            return "SELECT Sum(" + sum_col + ") AS " + az + " FROM " + from + " JOIN " + join + " ON " + from + ".id = " + join + "." + idColumn + " WHERE " + from + "." + where;
        }
        public string delete(String from, String where, String value) {
            return "DELETE FROM " + from + " WHERE " + from + "." + where + " = "+ value + "";
        }
        public string update(String table, String updateColumn, String where) {
            return "UPDATE " + table + " SET " + updateColumn + " WHERE " + where;
        }
    }
}
