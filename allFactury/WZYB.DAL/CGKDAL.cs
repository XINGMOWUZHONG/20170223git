using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZYB.DBUtility;

namespace WZYB.DAL
{
    /// <summary>
    /// 数据访问类AGVStatusDAL。
    /// </summary>
    public class CGKDAL
    {
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet getDatasetByIdAndTable(int id, string table)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from "+table+" where id ="+id.ToString ());
            return DbHelperSQL.Query(strSql.ToString());
        }

        public static DataSet getDatasetByTable( string table)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + table + "");
            return DbHelperSQL.Query(strSql.ToString());
        }

        
    }
}
