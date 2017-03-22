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
                return DbHelperSQL.Query(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
