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
                strSql.Append("select * from " + System.Configuration.ConfigurationManager.AppSettings["OcsLift"].ToString() + " order by LiftId asc");
                return DbHelperSQL.Query(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
      
    }
}

