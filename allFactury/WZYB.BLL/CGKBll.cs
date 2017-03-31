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
    public class CGKBll
    {
        public static string CGK_pallert = System.Configuration.ConfigurationManager.AppSettings["LKtable_pallert"].ToString();
        public static string CGK_ddj = System.Configuration.ConfigurationManager.AppSettings["LKtable_ddj"].ToString();
        public static string CGK_csc = System.Configuration.ConfigurationManager.AppSettings["LKtable_csc"].ToString();
        #region  成员方法


        public static CGKcar GetCGKcarModel(int id)
        {
            try
            {
                DataSet ds = CGKDAL.getDatasetByIdAndTable(id, CGK_csc);
                if (ds != null && ds.Tables.Count >0 && ds.Tables [0].Rows.Count > 0)
                {
                    return DataTableToCGKcar(ds.Tables[0])[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static CGKddj GetCGKddjModel(int id)
        {
            try
            {
                DataSet ds = CGKDAL.getDatasetByIdAndTable(id, CGK_ddj);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return DataTableToCGKddj(ds.Tables[0])[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static CGKpellert GetCGKpellertModel(int id)
        {
            try
            {
                DataSet ds = CGKDAL.getDatasetByIdAndTable(id, CGK_pallert);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return DataTableToCGKpellert(ds.Tables[0])[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<CGKpellert> GetCGKpellertModelAll()
        {
            try
            {
                DataSet ds = CGKDAL.getDatasetByTable(CGK_pallert);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return DataTableToCGKpellert(ds.Tables[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static List<CGKcar> DataTableToCGKcar(DataTable dt)
        {
            List<CGKcar> modelList = new List<CGKcar>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CGKcar model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new CGKcar();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.CGKcar_id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["Carstate"].ToString() != "")
                    {
                        model.CGKcar_state = int.Parse(dt.Rows[n]["Carstate"].ToString());
                    }
                    if (dt.Rows[n]["target"].ToString() != "")
                    {
                        model.CGKcar_tgt = dt.Rows[n]["target"].ToString();
                    }
                    if (dt.Rows[n]["source"].ToString() != "")
                    {
                        model.CGKcar_source = dt.Rows[n]["source"].ToString();
                    }
                    if (dt.Rows[n]["currentlocation"].ToString() != "")
                    {
                        model.CGKcar_current = int.Parse(dt.Rows[n]["currentlocation"].ToString());
                    }
                    if (dt.Rows[n]["palletstate"].ToString() != "")
                    {
                        model.CGKcar_pallertstate = int.Parse(dt.Rows[n]["palletstate"].ToString());
                    }
                    if (dt.Rows[n]["action"].ToString() != "")
                    {
                        model.CGKcar_action = int.Parse(dt.Rows[n]["action"].ToString());
                    }
                    if (dt.Rows[n]["target_z"].ToString() != "")
                    {
                        model.target_z = int.Parse(dt.Rows[n]["target_z"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public static List<CGKddj> DataTableToCGKddj(DataTable dt)
        {
            List<CGKddj> modelList = new List<CGKddj>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CGKddj model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new CGKddj();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.CGKddj_id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["carstate"].ToString() != "")
                    {
                        model.CGKddj_state = int.Parse(dt.Rows[n]["carstate"].ToString());
                    }
                    if (dt.Rows[n]["target"].ToString() != "")
                    {
                        model.CGKddj_tgt = float.Parse(dt.Rows[n]["target"].ToString());
                    }
                    if (dt.Rows[n]["source"].ToString() != "")
                    {
                        model.CGKddj_source = float.Parse(dt.Rows[n]["source"].ToString());
                    }
                    if (dt.Rows[n]["currentlocation"].ToString() != "")
                    {
                        model.CGKddj_current = float.Parse(dt.Rows[n]["currentlocation"].ToString());
                    }
                    if (dt.Rows[n]["palletstate"].ToString() != "")
                    {
                        model.CGKddj_pallertstate = int.Parse(dt.Rows[n]["palletstate"].ToString());
                    }
                    if (dt.Rows[n]["fork_tgt"].ToString() != "")
                    {
                        model.CGKddj_forktgt = float.Parse(dt.Rows[n]["fork_tgt"].ToString());
                    }
                    if (dt.Rows[n]["platform_tgt"].ToString() != "")
                    {
                        model.CGKddj_platformtgt = float.Parse(dt.Rows[n]["platform_tgt"].ToString());
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public static List<CGKpellert> DataTableToCGKpellert(DataTable dt)
        {
            List<CGKpellert> modelList = new List<CGKpellert>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CGKpellert model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new CGKpellert();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.CGKpellertid = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["state"].ToString() != "")
                    {
                        model.CGKpellertstate = int.Parse(dt.Rows[n]["state"].ToString());
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion

    }
}
