﻿using System;
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
                return getdataset(strSql.ToString(),type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool deleteRackByid(int id,int type)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete  from " + System.Configuration.ConfigurationManager.AppSettings["StorageTable"].ToString() + " where id =" + id.ToString());
                int i = delRack(strSql.ToString(), type);
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

        public static bool deleteRackByid(int id )
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete  from " + System.Configuration.ConfigurationManager.AppSettings["StorageTable"].ToString() + " where id =" + id.ToString());
                int i = DbHelperSQL.ExecuteSql(strSql.ToString() );
                if (i > 0)
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

        public static int InsertRack(WZYB.Model.Rack model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into  " + System.Configuration.ConfigurationManager.AppSettings["StorageTable"].ToString() + "([rackid],[location_x] ,[location_y]  ,[location_z] ,[pallet_num] ,[rack_state]) values(" + model.Rack_type + "," + model.Rack_colum + "," + model.Rack_row + "," + model.Rack_z + "," + model.Rack_id + "," + model.Rack_state + ");select @@identity; ");
                int x = int.Parse(DbHelperSQL.GetSingle(strSql.ToString()).ToString());
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int deleteRack(int rackid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from "+ System.Configuration.ConfigurationManager.AppSettings["StorageTable"].ToString() + " where id = "+rackid .ToString ());
                int x = DbHelperSQL.ExecuteSql(strSql.ToString());
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getdataset(string sql, int type)
        {
            System.Web.Caching.Cache objCache = System.Web.HttpRuntime.Cache;
            SqlConnection conn = null;
            if (objCache["rack_conn" + type.ToString()] == null)
            {
                conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["conn"]);
                conn.Open();
                objCache.Insert("rack_conn" + type.ToString(), conn);
            }
            else
            {
                conn = (SqlConnection)objCache["rack_conn" + type.ToString()];
            }
            return DbHelperSQL.Query(sql.ToString(), conn);
        }


        public static int  delRack(string sql, int type )
        {
            System.Web.Caching.Cache objCache = System.Web.HttpRuntime.Cache;
            SqlConnection conn = null;
            if (objCache["rack_conn" + type.ToString()] == null)
            {
                conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["conn"]);
                conn.Open();
                objCache.Insert("rack_conn" + type.ToString(), conn);
            }
            else
            {
                conn = (SqlConnection)objCache["rack_conn" + type.ToString()];
            }
            return DbHelperSQL.ExecuteSql(sql.ToString(), conn);
        }




    }
}
