using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZYB.Model;
using WZYB.BLL;
using System.Threading;

namespace PccNew
{
    public class ControlLk
    {
        public int sleepTime = int.Parse(System.Configuration.ConfigurationManager.AppSettings["car_interval"].ToString());
        public bool IsStart = false;

        //数据库只记录变化数据
        #region 托盘处理逻辑

        public void PallertThreadFunc(object o)
        {
            int[] xmlIndex = getPallertXmlIndex();
            while (true)
            {
                if(IsStart )
                {
                    List<CGKpellert> listPallert = CGKBll.GetCGKpellertModelAll();
                    setPallertData(listPallert, xmlIndex);
                }
                Thread.Sleep(sleepTime);
            }

        }

        private void setPallertData( List<CGKpellert> o, int[] xmlIndex)
        {
            foreach (CGKpellert pallert in o)
            {
                ComTCPLib.SetOutputAsINT(1, xmlIndex[pallert.CGKpellertid], pallert.CGKpellertstate);
            }
        }

        //i （1-50）
        private int[] getPallertXmlIndex()
        {
            string str ="";
            int [] arr = new int [50];
            int m;
            for (int i = 1; i < 51;i++ )
            {
                if(i<11)
                {
                    str = "TCP_ATTRIBUTE01_IN_RK_INSTATE"+i.ToString ();
                }
                else if (i < 17)
                {
                    str = "TCP_ATTRIBUTE01_IN_RK_INSTATE" + i.ToString()+"02";
                }
                else if (i < 23)
                {
                    str = "TCP_ATTRIBUTE01_IN_RK_INSTATE" + i.ToString() + "03";
                }
                else if (i < 33)
                {
                    str = "TCP_ATTRIBUTE01_IN_CK_INSTATE" + i.ToString() ;
                }
                else if (i < 39)
                {
                    str = "TCP_ATTRIBUTE01_IN_CK_INSTATE" + i.ToString()+"02";
                }
                else if (i < 45)
                {
                    str = "TCP_ATTRIBUTE01_IN_CK_INSTATE" + i.ToString() + "03";
                }
                else if (i < 51)
                {
                    str = "TCP_ATTRIBUTE01_IN_CK_INSTATE" + i.ToString() + "04";
                }
                m = GetIdex.getDicOutputIndex(str);
                arr[i - 1] = m;
            }

            return arr;
        }
        #endregion


        #region 堆垛机处理逻辑

        public void DDJThreadFunc(object o)
        {
            CGKddj lastDdj = null;
            int DdjId = Convert.ToInt16(o);
            int[] DDJXmlIndex = getDdjXmlIndex(DdjId);
            while (true)
            {
                if (IsStart)
                {
                    CGKddj thisDdj = CGKBll.GetCGKddjModel(DdjId);
                    if (thisDdj!= null)
                    {
                        setDdjData(lastDdj, thisDdj, DDJXmlIndex);
                        lastDdj = thisDdj;
                    }
                }
                Thread.Sleep(sleepTime);
            }

        }

        private void setDdjData(CGKddj lastddj,CGKddj thisddj, int[] xmlIndex)
        {
            int DDJXmlIndex_state = xmlIndex[0];
            int DDJXmlIndex_tgt = xmlIndex[1];
            int DDJXmlIndex_source = xmlIndex[2];
            int DDJXmlIndex_forktgt = xmlIndex[3];
            int DDJXmlIndex_platformtgt = xmlIndex[4];
            int DDJXmlIndex_pallertstate = xmlIndex[5];

           

            if (lastddj == null)
            {
                if (thisddj.CGKddj_current == thisddj.CGKddj_tgt)
                {
                    ComTCPLib.SetOutputAsREAL32(1, DDJXmlIndex_source, thisddj.CGKddj_tgt);
                }
                else
                {
                    ComTCPLib.SetOutputAsREAL32(1, DDJXmlIndex_source, thisddj.CGKddj_source);
                }
                ComTCPLib.SetOutputAsUINT(1, DDJXmlIndex_state,UInt16.Parse ( thisddj.CGKddj_state.ToString ()));
                ComTCPLib.SetOutputAsREAL32(1, DDJXmlIndex_tgt, thisddj.CGKddj_tgt);
                ComTCPLib.SetOutputAsREAL32(1, DDJXmlIndex_forktgt, thisddj.CGKddj_forktgt);
                ComTCPLib.SetOutputAsREAL32(1, DDJXmlIndex_platformtgt, thisddj.CGKddj_platformtgt);
                ComTCPLib.SetOutputAsUINT(1, DDJXmlIndex_pallertstate, UInt16.Parse(thisddj.CGKddj_pallertstate.ToString()));
            }
            else if (!thisddj.Equals(lastddj))
            {
                if (thisddj.CGKddj_current == thisddj.CGKddj_tgt)
                {
                    ComTCPLib.SetOutputAsREAL32(1, DDJXmlIndex_source, thisddj.CGKddj_tgt);
                }
                else
                {
                    if (thisddj.CGKddj_source != lastddj.CGKddj_source)
                    ComTCPLib.SetOutputAsREAL32(1, DDJXmlIndex_source, thisddj.CGKddj_source);
                }
                if (thisddj.CGKddj_state != lastddj.CGKddj_state)
                    ComTCPLib.SetOutputAsUINT(1, DDJXmlIndex_state, UInt16.Parse(thisddj.CGKddj_state.ToString()));
                if (thisddj.CGKddj_tgt != lastddj.CGKddj_tgt)
                ComTCPLib.SetOutputAsREAL32(1, DDJXmlIndex_tgt, thisddj.CGKddj_tgt);
                if (thisddj.CGKddj_forktgt != lastddj.CGKddj_forktgt)
                ComTCPLib.SetOutputAsREAL32(1, DDJXmlIndex_forktgt, thisddj.CGKddj_forktgt);
                if (thisddj.CGKddj_platformtgt != lastddj.CGKddj_platformtgt)
                ComTCPLib.SetOutputAsREAL32(1, DDJXmlIndex_platformtgt, thisddj.CGKddj_platformtgt);
                if (thisddj.CGKddj_pallertstate != lastddj.CGKddj_pallertstate)
                    ComTCPLib.SetOutputAsUINT(1, DDJXmlIndex_pallertstate, UInt16.Parse(thisddj.CGKddj_pallertstate.ToString()));
            }
            
        }
        // i (1 - 3)
        private int[] getDdjXmlIndex(int i)
        {
            int[] index = new int[6];
            index[0] = GetIdex.getDicOutputIndex("TCP_ATTRIBUTE01_IN_DDJ"+i.ToString ()+"_DDJ_STATE");
            index[1] = GetIdex.getDicOutputIndex("TCP_ATTRIBUTE01_IN_DDJ" + i.ToString() + "_DDJ_CARTGT");
            index[2] = GetIdex.getDicOutputIndex("TCP_ATTRIBUTE01_IN_DDJ" + i.ToString() + "_DDJ_CARORI");
            index[3] = GetIdex.getDicOutputIndex("TCP_ATTRIBUTE01_IN_DDJ" + i.ToString() + "_DDJ_FORK_TGT");
            index[4] = GetIdex.getDicOutputIndex("TCP_ATTRIBUTE01_IN_DDJ" + i.ToString() + "_DDJ_LIFT_TGT");
            index[5] = GetIdex.getDicOutputIndex("TCP_ATTRIBUTE01_IN_DDJ" + i.ToString() + "_DDJ_PALLET");

            return index;
        }
        #endregion



        #region 穿梭车处理逻辑

        public void CarThreadFunc(object o)
        {
            CGKcar lastCar = null;
            int CarId = Convert.ToInt16(o);
            int[] CarXmlIndex = getCarXmlIndex(CarId);
            while (true)
            {
                if (IsStart)
                {
                    CGKcar thisCar = CGKBll.GetCGKcarModel(CarId);
                    if (thisCar != null)
                    {
                        setCarData(lastCar, thisCar, CarXmlIndex);
                        lastCar = thisCar;
                    }
                }
                Thread.Sleep(sleepTime);
            }

        }

        private void setCarData(CGKcar lastData, CGKcar thisData, int[] xmlIndex)
        {
            int CarXmlIndex_state = xmlIndex[0];
            int CarXmlIndex_tgt = xmlIndex[1];
            int CarXmlIndex_source = xmlIndex[2];
            int CarXmlIndex_pallertstate = xmlIndex[3];
            if (lastData == null)
            {
                if (thisData.CGKcar_current == thisData.CGKcar_tgt)
                {
                    ComTCPLib.SetOutputAsREAL32(1, CarXmlIndex_source, thisData.CGKcar_tgt);
                }
                else
                {
                    ComTCPLib.SetOutputAsREAL32(1, CarXmlIndex_source, thisData.CGKcar_source);
                }
                ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_state,UInt16.Parse ( thisData.CGKcar_state.ToString ()));
                ComTCPLib.SetOutputAsREAL32(1, CarXmlIndex_tgt, thisData.CGKcar_tgt);
                ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_pallertstate, UInt16.Parse (thisData.CGKcar_pallertstate.ToString ()));
            }
            else if (!thisData.Equals(lastData))
            {
                if (thisData.CGKcar_current == thisData.CGKcar_tgt)
                {
                    ComTCPLib.SetOutputAsREAL32(1, CarXmlIndex_source, thisData.CGKcar_tgt);
                }
                else
                {
                    if (thisData.CGKcar_source != lastData.CGKcar_source)
                    ComTCPLib.SetOutputAsREAL32(1, CarXmlIndex_source, thisData.CGKcar_source);
                }
                if (thisData.CGKcar_state != lastData.CGKcar_state)
                    ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_state, UInt16.Parse ( thisData.CGKcar_state.ToString ()));
                if (thisData.CGKcar_tgt != lastData.CGKcar_tgt)
                    ComTCPLib.SetOutputAsREAL32(1, CarXmlIndex_tgt, thisData.CGKcar_tgt);
                if (thisData.CGKcar_pallertstate != lastData.CGKcar_pallertstate)
                    ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_pallertstate, UInt16.Parse(thisData.CGKcar_pallertstate.ToString()));
               
            }

        }
        //i (1 2)
        private int[] getCarXmlIndex(int i)
        {
            string str="";
            if(i == 1)
            {
                str ="RUKU";
            }
            else if(i == 2)
            {
                str ="CHUKU";
            }
            int [] index = new int [4];
            index[0] = GetIdex.getDicOutputIndex("TCP_ATTRIBUTE01_IN_" + str + "_STATE");
            index[1] = GetIdex.getDicOutputIndex("TCP_ATTRIBUTE01_IN_" + str + "_TGT");
            index[2] = GetIdex.getDicOutputIndex("TCP_ATTRIBUTE01_IN_" + str + "_ORI");
            index[3] = GetIdex.getDicOutputIndex("TCP_ATTRIBUTE01_IN_" + str + "_PALLET_STATE");

            return index;
        }
        #endregion



    }
}
