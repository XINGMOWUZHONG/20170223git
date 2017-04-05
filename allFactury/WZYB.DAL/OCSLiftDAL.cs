using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WZYB.DBUtility;

namespace WZYB.DAL
{
	/// <summary>
	/// 数据访问类OCSStatusDAL。
	/// </summary>
    public class OCSLiftDAL
	{
        public static DataSet getOcsLiftDatasetAll()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from " + System.Configuration.ConfigurationManager.AppSettings["OcsLift"].ToString() + " order by id asc");
                return getdataset(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet getdataset(string sql)
        {
            System.Web.Caching.Cache objCache = System.Web.HttpRuntime.Cache;
            SqlConnection conn = null;
            if (objCache["ocsLift_conn" ] == null)
            {
                conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["conn"]);
                conn.Open();
                objCache.Insert("ocsLift_conn", conn);
            }
            else
            {
                conn = (SqlConnection)objCache["ocsLift_conn"];
            }
            return DbHelperSQL.Query(sql.ToString(), conn);
        }
        
      
    }
}

