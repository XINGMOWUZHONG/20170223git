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
        #region  成员方法
        public static string CGK_pallert = System.Configuration.ConfigurationManager .AppSettings [ "LKtable_pallert"].ToString ();
        public static string CGK_ddj =  System.Configuration.ConfigurationManager .AppSettings ["LKtable_car"].ToString ();
        public static string CGK_csc = System.Configuration.ConfigurationManager.AppSettings["LKtable_csc"].ToString();
       
        public static CGKcar GetCGKcarModel(int id)
        {
            DataSet ds = CGKDAL.getDatasetByIdAndTable(id, CGK_csc);
            if(ds!=null )
            {
               return DataTableToCGKcar(ds.Tables[0])[0];
            }
            return null;
        }
        public static CGKddj GetCGKddjModel(int id)
        {
            DataSet ds = CGKDAL.getDatasetByIdAndTable(id, CGK_csc);
            if (ds != null)
            {
                return DataTableToCGKddj(ds.Tables[0])[0];
            }
            return null;
        }
        public static CGKpellert GetCGKpellertModel(int id)
        {
            DataSet ds = CGKDAL.getDatasetByIdAndTable(id, CGK_csc);
            if (ds != null)
            {
                return DataTableToCGKpellert(ds.Tables[0])[0];
            }
            return null;
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
                    if (dt.Rows[n]["state"].ToString() != "")
                    {
                        model.CGKcar_state = int.Parse(dt.Rows[n]["state"].ToString());
                    }
                    if (dt.Rows[n]["tgt"].ToString() != "")
                    {
                        model.CGKcar_tgt = float.Parse(dt.Rows[n]["tgt"].ToString());
                    }
                    if (dt.Rows[n]["source"].ToString() != "")
                    {
                        model.CGKcar_source = float.Parse(dt.Rows[n]["source"].ToString());
                    }
                    if (dt.Rows[n]["current"].ToString() != "")
                    {
                        model.CGKcar_current = float.Parse(dt.Rows[n]["current"].ToString());
                    }
                    if (dt.Rows[n]["pallertstate"].ToString() != "")
                    {
                        model.CGKcar_pallertstate = int.Parse(dt.Rows[n]["pallertstate"].ToString());
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
                    if (dt.Rows[n]["state"].ToString() != "")
                    {
                        model.CGKddj_state = int.Parse(dt.Rows[n]["state"].ToString());
                    }
                    if (dt.Rows[n]["tgt"].ToString() != "")
                    {
                        model.CGKddj_tgt = float.Parse(dt.Rows[n]["tgt"].ToString());
                    }
                    if (dt.Rows[n]["source"].ToString() != "")
                    {
                        model.CGKddj_source = float.Parse(dt.Rows[n]["source"].ToString());
                    }
                    if (dt.Rows[n]["current"].ToString() != "")
                    {
                        model.CGKddj_current = float.Parse(dt.Rows[n]["current"].ToString());
                    }
                    if (dt.Rows[n]["pallertstate"].ToString() != "")
                    {
                        model.CGKddj_pallertstate = int.Parse(dt.Rows[n]["pallertstate"].ToString());
                    }
                    if (dt.Rows[n]["forktgt"].ToString() != "")
                    {
                        model.CGKddj_forktgt = float.Parse(dt.Rows[n]["forktgt"].ToString());
                    }
                    if (dt.Rows[n]["plattgt"].ToString() != "")
                    {
                        model.CGKddj_platformtgt = float.Parse(dt.Rows[n]["plattgt"].ToString());
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
                        model.CGKpellertid = int.Parse(dt.Rows[n]["CGKpellertid"].ToString());
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
