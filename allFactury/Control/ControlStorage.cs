using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WZYB.Model;
using WZYB.BLL;

namespace WZYB.Control
{
    public class ControlStorage
    {
        public int sleepTime = int.Parse(System.Configuration.ConfigurationManager.AppSettings["car_interval"].ToString());
        public bool IsStart = false;

        public ControlStorage()
        {
            IsStart = true;
        }


        #region 托盘处理逻辑

        public void StorageThreadFunc(object o)
        {
            try
            {
                Storage.General g = o as Storage.General;
                while (true && g!=null)
                {
                    if (IsStart)
                    {
                        List<Rack> allRack = RackBll.GetRackAll(g.StorageType);
                        if (allRack != null)
                        {
                            foreach (Rack r in allRack)
                            {
                                g.Change(r.Rack_z, r.Rack_colum, r.Rack_row, r.Rack_state, r.Rack_id);
                                RackBll.deleteRack(r.id);
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
        /// <summary>
        /// 根据远程数据库初始化托盘
        /// </summary>
        /// <param name="list"></param>
        public void InitializeStoragePallet(object o)
        {
            try
            {
                List<Storage.General> list = o as List<Storage.General>;
                List<Rack> allRack = RackBll.GetRackAllStorage();
                if ( allRack!=null && allRack.Count > 0)
                {
                    foreach (Rack r in allRack)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (r.Rack_type == list[i].StorageType)
                            {
                                list[i].Change(r.Rack_z, r.Rack_colum, r.Rack_row, r.Rack_state, r.Rack_id);
                                Thread.Sleep(30);
                            }
                        }
                    }
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
