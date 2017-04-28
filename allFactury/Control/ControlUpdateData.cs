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
    public  class ControlUpdateData
    { 
        private int ThreadTime = int.Parse( System.Configuration.ConfigurationManager.AppSettings["DataUpdate_sleeptime"].ToString());
        public bool IsStart = false;
        public ControlUpdateData()
        {
            IsStart = true;
        }

        public void DataThreadFunc(object o)
        {
            try
            { 
                while (true)
                {
                    if (IsStart)
                    {
                        double time, timeStep;
                        ComTCPLib.UpdateData(1, out time, out timeStep);
                    }
                    Thread.Sleep(ThreadTime);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
