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
    public class RackDAL
    {

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet getRackDatasetById(int id)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from " + System.Configuration.ConfigurationManager.AppSettings["StorageTable"].ToString() + " where id =" + id.ToString());
                return DbHelperSQL.Query(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet getRackDatasetByCoordinate(int x, int y, int z, int type)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from " + System.Configuration.ConfigurationManager.AppSettings["StorageTable"].ToString() + " where colum=" + x.ToString() + " and row =" + y.ToString() + " and rack_z =" + z.ToString() + " and racktype=" + type.ToString() + "");
                return DbHelperSQL.Query(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet getRackDatasetAll(int type)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from " + System.Configuration.ConfigurationManager.AppSettings["StorageTable"].ToString() + " where rackid = "+type .ToString ());
                return DbHelperSQL.Query(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool deleteRackByid(int id)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete  from " + System.Configuration.ConfigurationManager.AppSettings["StorageTable"].ToString() + " where id =" + id.ToString());
                int i= DbHelperSQL.ExecuteSql(strSql.ToString());
                if(i>0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getRackDatasetAllStorage()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from " + System.Configuration.ConfigurationManager.AppSettings["StorageTable2"].ToString());
                return DbHelperSQL.QueryStorage(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
