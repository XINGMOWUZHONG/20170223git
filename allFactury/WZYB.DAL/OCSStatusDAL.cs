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
	public class OCSStatusDAL
	{
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(int carId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_OCSStatus");
            strSql.Append(" where id=@carId ");
            SqlParameter[] parameters = {
					new SqlParameter("@carId", SqlDbType.Int,4)};
            parameters[0].Value = carId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public static bool ExistsBy(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_OCSStatus");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Exists(strSql.ToString());
        }



        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int carId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_OCSStatus ");
            strSql.Append(" where id=@carId ");
            SqlParameter[] parameters = {
					new SqlParameter("@carId", SqlDbType.Int,4)};
            parameters[0].Value = carId;

            int i = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (i > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public static int DeleteBy(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_OCSStatus ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,line,position,displaystate ");
            strSql.Append(" FROM T_OCSStatus ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }
            if(strWhere .IndexOf("id=") > -1)
            {
                string id = strWhere.Replace ("id=","").Trim ();
                return getdataset(strSql.ToString(), int.Parse(id));
            }
            else
            {
                return DbHelperSQL.Query(strSql.ToString());
            }
            
        }

        #endregion  成员方法
        
        #region 自定义方法

        public static int getCountByLine(string line)
        {
            string strSql = "select count(*) from T_OCSStatus where line = '" + line + "'";
            object obj = DbHelperSQL.GetSingle(strSql);
            return Convert.ToInt32(obj);
        }

        #endregion

        public static DataSet getdataset(string sql, int id)
        {
            System.Web.Caching.Cache objCache = System.Web.HttpRuntime.Cache;
            SqlConnection conn = null;
            if (objCache["ocs_conn" + id.ToString()] == null)
            {
                conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["conn"]);
                conn.Open();
                objCache.Insert("ocs_conn" + id.ToString(), conn);
            }
            else
            {
                conn = (SqlConnection)objCache["ocs_conn" + id.ToString()];
            }
            return DbHelperSQL.Query(sql.ToString(), conn);
        }
    }
}

