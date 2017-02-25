using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WZYB.Model;
using WZYB.BLL;

namespace PccNew
{
    public class ControlStorage
    {
        public int sleepTime = int.Parse(System.Configuration.ConfigurationManager.AppSettings["car_interval"].ToString());
        public bool IsStart = false;
        #region 托盘处理逻辑

        public void StorageThreadFunc(object o)
        {
            try
            {
                Storage.General g = o as Storage.General;
                while (true)
                {
                    if (IsStart)
                    {
                        List<Rack> allRack = RackBll.GetRackAll();
                        if (allRack != null)
                        {
                            foreach (Rack r in allRack)
                            {
                                g.Change(r.Rack_z, r.Rack_colum, r.Rack_row, r.Rack_state, r.Rack_id);
                            }
                        }
                    }
                    Thread.Sleep(sleepTime);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion
    }
}
