using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZYB.Control;
using System.Threading;

namespace WZYB.Control
{
     public  class ControlClickAndLightThread
    {
        public bool IsStart = false;
        public string LinkStr = "";
        public int TypeStr = 0;
        private int ThreadTimeClick = 300;
        private int ThreadTimeLight = 300;
        public int handle = 1;


        public int AgvCount = 5;
        public int MachineCount = 5;
        public int OcsCount = 5;
        public int PccCount = 1;
        public int CscCount = 2;
        public int DdjCount = 3;

        public int AllCount = 21;

        public string AgvCountStr = "ATTRIBUTE01_light**_LIGHT_STATE1";
        public string MachineCountStr = "ATTRIBUTE01_light**_LIGHT_STATE1";
        public string OcsCountStr = "ATTRIBUTE01_light**_LIGHT_STATE1";
        public string PccCountStr = "ATTRIBUTE01_light**_LIGHT_STATE1";
        public string CscCountStr = "ATTRIBUTE01_light**_LIGHT_STATE1";
        public string DdjCountStr = "ATTRIBUTE01_light**_LIGHT_STATE1";

        GetIdex gi = new GetIdex();
        public ControlClickAndLightThread()
        {
            IsStart = true;
        }
        public void ClickThreadFunc(object obj)
        {
            try
            {
                string[] arr = (string[])obj;
                string num = arr[0];
                string type=arr[1];
                while (true)
                {
                    if (IsStart)
                    {
                        if(getisClick(num,int.Parse(type )))
                        {
                            LinkStr  = ControlInterfaceMethod.getLinkByTypeAndNum(int.Parse(type), num);
                            TypeStr = int.Parse(type);
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

        public void LightThreadFunc(object obj)
        {
            try
            {
                int num = Convert.ToInt32(obj);
                while (true)
                {
                    if (IsStart)
                    {
                        setLightState(num.ToString ());
                    }
                    Thread.Sleep(ThreadTimeLight);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         //type 1agv 2ddj  3pcc 4csc 5ocs 6 screen
        public bool getisClick(string num,int type)
        {
            string indexstr = "";
            switch (type)
            { 
                case 1:
                    indexstr = AgvCountStr;
                    break;
                case 2:
                    indexstr = DdjCountStr;
                    break;
                case 3:
                    indexstr = PccCountStr;
                    break;
                case 4:
                    indexstr = CscCountStr;
                    break;
                case 5:
                    indexstr = OcsCountStr;
                    break;
                case 6:
                    indexstr = MachineCountStr;
                    break;
                default:
                    break;
            }
            indexstr = indexstr.Replace("**",num);
            return bool.Parse(gi.readValue(indexstr, 3, 1).ToString());

        }

        public void setLightState(string num)
        {
            string indexstr = MachineCountStr.Replace("**", num);
            int  state = ControlInterfaceMethod.getMachineLightState( num);
            gi.updateValue(indexstr,state.ToString (),1,handle);
        }

    }
}
