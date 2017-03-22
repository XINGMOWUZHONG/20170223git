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

    public  class PccBll
    {
        public static string T_PeiCan = System.Configuration.ConfigurationManager.AppSettings["T_PeiCan"].ToString();
        public static PeiCan GetPccModel()
        {
            try
            {
                DataSet ds = PccDal.getDatasetByTable(T_PeiCan);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return DataRowToModel(ds.Tables[0].Rows[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static PeiCan DataRowToModel(DataRow row)
        {
            PeiCan model = new PeiCan();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["source"] != null && row["source"].ToString() != "")
                {
                    model.source = int.Parse(row["source"].ToString());
                }
                if (row["target"] != null && row["target"].ToString() != "")
                {
                    model.target = int.Parse(row["target"].ToString());
                }
                if (row["target_z"] != null && row["target_z"].ToString() != "")
                {
                    model.target_z = int.Parse(row["target_z"].ToString());
                }
                if (row["currentlocation"] != null && row["currentlocation"].ToString() != "")
                {
                    model.currentlocation = long.Parse(row["currentlocation"].ToString());
                }
                if (row["Carstate"] != null && row["Carstate"].ToString() != "")
                {
                    model.Carstate = int.Parse(row["Carstate"].ToString());
                }
                if (row["Palletstate"] != null && row["Palletstate"].ToString() != "")
                {
                    model.Palletstate = int.Parse(row["Palletstate"].ToString());
                }
                if (row["TaskState"] != null && row["TaskState"].ToString() != "")
                {
                    model.TaskState = int.Parse(row["TaskState"].ToString());
                }
                if (row["ComplateState"] != null && row["ComplateState"].ToString() != "")
                {
                    model.ComplateState = int.Parse(row["ComplateState"].ToString());
                }
                if (row["Time"] != null && row["Time"].ToString() != "")
                {
                    model.Time = DateTime.Parse(row["Time"].ToString());
                }
                if (row["Additional"] != null)
                {
                    model.Additional = row["Additional"].ToString();
                }
            }
            return model;
        }
    }
}
