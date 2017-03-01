using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZYB.DAL;
using WZYB.Model;

namespace WZYB.BLL
{
    /// <summary>
    /// 业务逻辑类AGVStatusBLL 的摘要说明。
    /// </summary>
    public class OcsLiftBll
    {
        #region  成员方法

 

        public static List<OCSLift> GetOcsLiftAll()
        {
            try
            {
                DataSet ds = OCSLiftDAL.getOcsLiftDatasetAll();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return DataTableToOCSLift(ds.Tables[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<OCSLift> DataTableToOCSLift(DataTable dt)
        {
            List<OCSLift> modelList = new List<OCSLift>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                OCSLift model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new OCSLift();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.LiftId = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["LiftTopstate"].ToString() != "")
                    {
                        model.LiftTopstate = int.Parse(dt.Rows[n]["LiftTopstate"].ToString());
                    }
                    if (dt.Rows[n]["LiftDownstate"].ToString() != "")
                    {
                        model.LiftDownstate = int.Parse(dt.Rows[n]["LiftDownstate"].ToString());
                    }
                   
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion

    }
}
