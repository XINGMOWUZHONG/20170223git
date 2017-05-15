using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WZYB.Control
{
   
    public class ControlClickLight
    {
        public bool IsStart = false;
        private int ThreadTimeClick = int.Parse(System.Configuration.ConfigurationManager.AppSettings["CLICK_sleeptime"].ToString());
        private int ThreadTimeLight = int.Parse(System.Configuration.ConfigurationManager.AppSettings["LIGHT_sleeptime"].ToString());
        public int handle = 1;
        public string LinkStr = "";
        public int TypeStr = 0;
        GetIdex gi;
        public int MachineCount = 5;
        private int Click_Type_index;
        private int Click_Num_index;
        private int Click_Reset_index;
        public string MachineCountStr = "ATTRIBUTE01_light**_LIGHT_STATE1";

        #region click
        public ControlClickLight()
        {
            IsStart = true;
            gi = new GetIdex();
            Click_Type_index = GetIdex.getDicInputIndex("ATTRIBUTE01_CLICK_TYPE");
            Click_Num_index = GetIdex.getDicInputIndex("ATTRIBUTE01_CLICK_NUM");
            Click_Reset_index = GetIdex.getDicOutputIndex("ATTRIBUTE01_CLICK_RETURN");
        }

        public void ClickThreadFunc(object obj)
        {
            try
            { 
                while (true)
                {
                    if (IsStart)
                    {
                        uint result_type ;
                        uint result_Num  ;
                        ComTCPLib.GetInputAsUINT(handle, Click_Type_index, out result_type);
                        Thread.Sleep(200);
                        if (result_type > 0)
                        {
                            ComTCPLib.GetInputAsUINT(handle, Click_Num_index, out result_Num);
                            LinkStr = ControlInterfaceMethod.getLinkByTypeAndNum((int)result_type, result_Num.ToString ());
                            TypeStr = (int)result_type;
                            IsStart = false;
                        }
                    }
                    Thread.Sleep(ThreadTimeClick);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ResetClick( )
        {
            try
            { 
                if (!IsStart)
                {
                    ComTCPLib.SetOutputAsUINT(handle, Click_Reset_index, 1);
                    Thread.Sleep(400);
                    ComTCPLib.SetOutputAsUINT(handle, Click_Reset_index, 0);
                    IsStart = true;
                }
                Thread.Sleep(ThreadTimeClick); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region  light 
        public void LightThreadFunc(object obj)
        {
            try
            {
                int num = Convert.ToInt32(obj);
                while (true)
                {
                    if (IsStart)
                    {
                        setLightState(num.ToString());
                    }
                    Thread.Sleep(ThreadTimeLight);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setLightState(string num)
        {
            //return;
            string indexstr = MachineCountStr.Replace("**", num);
            int index = GetIdex.getDicOutputIndex(indexstr);
            int state = ControlInterfaceMethod.getMachineLightState(num);
            //gi.updateValue(indexstr,state.ToString (),1,handle);
            ComTCPLib.SetOutputAsUINT(1, index, (uint)state);
        }

        #endregion

    }
}
