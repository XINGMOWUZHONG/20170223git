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
    public class PccDal
    {
        public static DataSet getDatasetByTable(  string table)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from " + table  );
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
            if (objCache["pcc_conn"] == null)
            {
                conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["conn"]);
                conn.Open();
                objCache.Insert("pcc_conn", conn);
            }
            else
            {
                conn = (SqlConnection)objCache["pcc_conn"];
            }
            return DbHelperSQL.Query(sql.ToString(), conn);
        }
    }
}
