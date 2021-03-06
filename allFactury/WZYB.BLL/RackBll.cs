﻿using System;
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

        public static bool deleteRack(uint id,int type)
        {
            try
            {
                return RackDAL.deleteRackByid((int)id, (int)type);
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
                        model.id = uint.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["rackid"].ToString() != "")
                    {
                        model.Rack_type = uint.Parse(dt.Rows[n]["rackid"].ToString());
                    }
                    if (dt.Rows[n]["location_y"].ToString() != "")
                    {
                        model.Rack_row = uint.Parse(dt.Rows[n]["location_y"].ToString());
                    }
                    if (dt.Rows[n]["location_x"].ToString() != "")
                    {
                        model.Rack_colum = uint.Parse(dt.Rows[n]["location_x"].ToString());
                    }
                    if (dt.Rows[n]["location_z"].ToString() != "")
                    {
                        model.Rack_z = uint.Parse(dt.Rows[n]["location_z"].ToString());
                    }
                    if (dt.Rows[n]["pallet_num"].ToString() != "")
                    {
                        model.Rack_id = uint.Parse(dt.Rows[n]["pallet_num"].ToString());
                    }
                    if (dt.Rows[n]["rack_state"].ToString() != "")
                    {
                        model.Rack_state = uint.Parse(dt.Rows[n]["rack_state"].ToString());
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }


        public int InsertRack(Rack model)
        {
            try
            {
                return RackDAL.InsertRack(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteRack(int rackid)
        {
            try
            {
                 RackDAL.deleteRackByid(rackid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
