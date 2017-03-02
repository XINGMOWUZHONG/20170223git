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
            try
            {
                DataSet ds = RackDAL.getRackDatasetById(id);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return DataTableToRack(ds.Tables[0])[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Rack GetRackModelByCoordinate(int x, int y, int z, int type)
        {
            try
            {
                DataSet ds = RackDAL.getRackDatasetByCoordinate(x, y, z, type);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return DataTableToRack(ds.Tables[0])[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<Rack> GetRackAll(int type)
        {
            try
            {
                DataSet ds = RackDAL.getRackDatasetAll(type);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return DataTableToRack(ds.Tables[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<Rack> GetRackAllStorage()
        {
            try
            {
                DataSet ds = RackDAL.getRackDatasetAllStorage();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return DataTableToRack(ds.Tables[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool deleteRack(int id)
        {
            try
            {
                return RackDAL.deleteRackByid(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                    if (dt.Rows[n]["rackid"].ToString() != "")
                    {
                        model.Rack_type = int.Parse(dt.Rows[n]["rackid"].ToString());
                    }
                    if (dt.Rows[n]["location_y"].ToString() != "")
                    {
                        model.Rack_row = int.Parse(dt.Rows[n]["location_y"].ToString());
                    }
                    if (dt.Rows[n]["location_x"].ToString() != "")
                    {
                        model.Rack_colum = int.Parse(dt.Rows[n]["location_x"].ToString());
                    }
                    if (dt.Rows[n]["location_z"].ToString() != "")
                    {
                        model.Rack_z = int.Parse(dt.Rows[n]["location_z"].ToString());
                    }
                    if (dt.Rows[n]["pallet_num"].ToString() != "")
                    {
                        model.Rack_id = int.Parse(dt.Rows[n]["pallet_num"].ToString());
                    }
                    if (dt.Rows[n]["rack_state"].ToString() != "")
                    {
                        model.Rack_state = int.Parse(dt.Rows[n]["rack_state"].ToString());
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion

    }
}
