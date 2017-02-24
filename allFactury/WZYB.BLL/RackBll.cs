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
    public class RackBll
    {
        #region  成员方法
      
       
        public static Rack GetRackModelByid(int id)
        {
            DataSet ds = RackDAL.getRackDatasetById(id);
            if(ds!=null )
            {
                return DataTableToRack(ds.Tables[0])[0];
            }
            return null;
        }

        public static Rack GetRackModelByCoordinate(int x,int y,int z,int type)
        {
            DataSet ds = RackDAL.getRackDatasetByCoordinate(x,y,z,type);
            if (ds != null)
            {
                return DataTableToRack(ds.Tables[0])[0];
            }
            return null;
        }


        public static List<Rack> GetRackAll()
        {
            DataSet ds = RackDAL.getRackDatasetAll();
            if (ds != null)
            {
                return DataTableToRack(ds.Tables[0]);
            }
            return null;
        }

        public static List<Rack> DataTableToRack(DataTable dt)
        {
            List<Rack> modelList = new List<Rack>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Rack model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Rack();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["racktype"].ToString() != "")
                    {
                        model.Rack_type = int.Parse(dt.Rows[n]["racktype"].ToString());
                    }
                    if (dt.Rows[n]["row"].ToString() != "")
                    {
                        model.Rack_row = int.Parse(dt.Rows[n]["row"].ToString());
                    }
                    if (dt.Rows[n]["colum"].ToString() != "")
                    {
                        model.Rack_colum = int.Parse(dt.Rows[n]["colum"].ToString());
                    }
                    if (dt.Rows[n]["rack_z"].ToString() != "")
                    {
                        model.Rack_z = int.Parse(dt.Rows[n]["rack_z"].ToString());
                    }
                    if (dt.Rows[n]["rackid"].ToString() != "")
                    {
                        model.Rack_id = int.Parse(dt.Rows[n]["rackid"].ToString());
                    }
                    if (dt.Rows[n]["state"].ToString() != "")
                    {
                        model.Rack_state = int.Parse(dt.Rows[n]["state"].ToString());
                    }
                   
                    modelList.Add(model);
                }
            }
            return modelList;
        }

     
        #endregion

    }
}
