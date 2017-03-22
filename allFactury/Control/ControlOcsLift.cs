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
    public class ControlOcsLift
    {
        public int sleepTime = int.Parse(System.Configuration.ConfigurationManager.AppSettings["car_interval"].ToString());
        public bool IsStart = false;
        public int handle = 1;

        public void OcsLiftThreadFunc(object obj)
        {
            try
            {
                int[] xmlIndex = getOcsLiftXmlIndex();
                List<OCSLift> Last_modelList = null;
                while (true)
                {
                    if (IsStart)
                    {
                        List<OCSLift> modelList = OcsLiftBll.GetOcsLiftAll();
                        if (Last_modelList == null)
                        {
                            Last_modelList = modelList;
                            setOcsLiftData(modelList, xmlIndex);

                        }
                        else
                        {
                            setOcsLiftData(modelList,Last_modelList, xmlIndex);
                            Last_modelList = modelList;
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

        private void setOcsLiftData(List<OCSLift> o, int[] xmlIndex)
        {
            if (o != null)
            {
                foreach (OCSLift Lift in o)
                {
                    int value=0;
                    if(Lift.LiftTopstate == 0 && Lift .LiftDownstate == 0)
                    {
                         value=2;
                    }
                    else if(Lift.LiftTopstate == 1)
                    {
                         value=1;
                    }
                    else if( Lift .LiftDownstate == 1)
                    {
                        value=0;
                    }
                    ComTCPLib.SetOutputAsUINT(1, xmlIndex[Lift.LiftId -1], uint.Parse(value.ToString ()));
                }
            }
        }

         private void setOcsLiftData(List<OCSLift> o,List<OCSLift> last, int[] xmlIndex)
        {
            if (o != null && last !=null && o.Count >0 && last .Count >0)
            {
                foreach (OCSLift Lift in o)
                {
                    if(Lift.LiftDownstate == last [Lift .LiftId-1 ].LiftDownstate  && Lift.LiftTopstate  == last [Lift .LiftId-1 ].LiftTopstate)
                    {
                        continue ; 
                    }
                    else if(Lift.LiftDownstate == 1 )
                    {
                        ComTCPLib.SetOutputAsUINT(1, xmlIndex[Lift.LiftId-1], uint.Parse("0"));
                    }
                    else if (Lift.LiftTopstate == 1)
                    {
                        ComTCPLib.SetOutputAsUINT(1, xmlIndex[Lift.LiftId-1], uint.Parse("1"));
                    }
                    else
                    {
                        ComTCPLib.SetOutputAsUINT(1, xmlIndex[Lift.LiftId-1], uint.Parse("2"));
                    }
                    
                }
            }
        }

       
        //i （1-9）
        private int[] getOcsLiftXmlIndex()
        {
            string str = "";
            int[] arr = new int[9];
            int m;
            for (int i = 1; i < 10; i++)
            {
                if (i ==1)
                {
                    str = "TCP_ATTRIBUTE01_IN_OcsLiftState_B1" ;
                }
                else if (i ==2)
                {
                    str = "TCP_ATTRIBUTE01_IN_OcsLiftState_B2";
                }
                else if (i == 3)
                {
                    str = "TCP_ATTRIBUTE01_IN_OcsLiftState_B3";
                }
                else if (i == 4)
                {
                    str = "TCP_ATTRIBUTE01_IN_OcsLiftState_A1";
                }
                else if (i == 5)
                {
                    str = "TCP_ATTRIBUTE01_IN_OcsLiftState_A2";
                }
                else if (i == 6)
                {
                    str = "TCP_ATTRIBUTE01_IN_OcsLiftState_C1";
                }
                else if (i == 7)
                {
                    str = "TCP_ATTRIBUTE01_IN_OcsLiftState_C2";
                }
                else if (i == 8)
                {
                    str = "TCP_ATTRIBUTE01_IN_OcsLiftState_C3";
                }
                else if (i == 9)
                {
                    str = "TCP_ATTRIBUTE01_IN_OcsLiftState_C4";
                }
                m = GetIdex.getDicOutputIndex(str);
                arr[i - 1] = m;
            }

            return arr;
        }


    }
}
