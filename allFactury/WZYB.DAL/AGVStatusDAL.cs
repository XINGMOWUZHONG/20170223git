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
    public class AGVStatusDAL
    {
        public AGVStatusDAL()
        { }
        public static DataSet getDatasetByIdAndTable(int id, string table)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from " + table + " where id =" + id.ToString());
                return getdataset(strSql.ToString(),id);
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
                return DbHelperSQL.Query(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet getDatasetByWhere(string table,string str)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from " + table + " where " + str);
                return DbHelperSQL.Query(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet getDatasetByWhere(string sql)
        {
            try
            {
                StringBuilder strSql = new StringBuilder(sql);
                return DbHelperSQL.Query(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet getdataset(string sql,int id)
        {
            System.Web.Caching.Cache objCache = System.Web.HttpRuntime.Cache;
            SqlConnection conn = null;
            if (objCache["agv_conn"+id.ToString ()] == null)
            {
                conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["conn"]);
                conn.Open();
                objCache.Insert("agv_conn"+id.ToString (), conn);
            }
            else
            {
                conn = (SqlConnection)objCache["agv_conn" + id.ToString()];
            }
            return DbHelperSQL.Query(sql.ToString(), conn);
        }
    }
}
