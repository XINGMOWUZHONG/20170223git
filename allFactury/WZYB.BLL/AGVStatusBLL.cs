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
    public class AGVStatusBLL
    {
        public static string AGVtable = System.Configuration.ConfigurationManager.AppSettings["AGV"].ToString();
        public static string PlatForm = System.Configuration.ConfigurationManager.AppSettings["PlatForm"].ToString();
        public static WZYB.Model.AGVStatus GetAgvModel(int id)
        {
            try
            {
                DataSet ds = AGVStatusDAL.getDatasetByIdAndTable(id, AGVtable);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return DataTableToAgvList(ds.Tables[0])[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AGVStatus> DataTableToAgvList(DataTable dt)
        {
            List<AGVStatus> modelList = new List<AGVStatus>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AGVStatus model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new AGVStatus();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = uint.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["line"].ToString() != "")
                    {
                        model.line = dt.Rows[n]["line"].ToString() ;
                    }
                    if (dt.Rows[n]["carstate"].ToString() != "")
                    {
                        model.carstate = uint.Parse(dt.Rows[n]["carstate"].ToString());
                    }
                    if (dt.Rows[n]["palletstate"].ToString() != "")
                    {
                        model.palletstate = uint.Parse(dt.Rows[n]["palletstate"].ToString());
                    }
                    if (dt.Rows[n]["source"].ToString() != "")
                    {
                        model.source = dt.Rows[n]["source"].ToString() ;
                    }
                    if (dt.Rows[n]["target"].ToString() != "")
                    {
                        model.target = dt.Rows[n]["target"].ToString();
                    }
                    if (dt.Rows[n]["taskstate"].ToString() != "")
                    {
                        model.taskstate = uint.Parse(dt.Rows[n]["taskstate"].ToString());
                    }
                    if (dt.Rows[n]["complatestate"].ToString() != "")
                    {
                        model.complatestate = uint.Parse(dt.Rows[n]["complatestate"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public static string[] getPostiveLine()
        {
            DataSet ds = AGVStatusDAL.getDatasetByWhere(PlatForm, " direction = 1");
            if(ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string[] str = new string[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    str[i] = ds.Tables[0].Rows[i]["line"].ToString();
                }
                return str;
            }
            return null;
        }

        public static Dictionary<string, string> getPlatFormLine()
        {
            DataSet ds = AGVStatusDAL.getDatasetByWhere(PlatForm, " Platformid <> 0 order by Platformid asc ");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                Dictionary<string, string> Platline = new Dictionary<string, string>();
                for (int i = 0; i < dt.Rows.Count;i++ )
                {
                    string row = dt.Rows[i]["Platformid"].ToString();
                    if (Platline.ContainsKey (row))
                    {
                        Platline[row] = Platline[row].ToString() + "," + dt.Rows[i]["line"].ToString();
                    }
                    else
                    {
                        Platline.Add(row, dt.Rows[i]["line"].ToString());
                    }
                }
                return Platline;
            }
            return null;
        }

    }
}
