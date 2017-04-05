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
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from " + table + " where id =" + id.ToString());
                return getdataset(strSql.ToString(), id, table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet getDatasetByTable(string table)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from " + table + "");
                return getdataset(strSql.ToString(),0,table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getdataset(string sql, int id,string table)
        {
            System.Web.Caching.Cache objCache = System.Web.HttpRuntime.Cache;
            SqlConnection conn = null;
            string name = table.Trim ();
            if (id !=0)
            {
                name += id.ToString();
            }
            name += "_conn";
            if (objCache[name] == null)
            {
                conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["conn"]);
                conn.Open();
                objCache.Insert(name, conn);
            }
            else
            {
                conn = (SqlConnection)objCache[name];
            }
            return DbHelperSQL.Query(sql.ToString(), conn);
        }


      

    }
}
