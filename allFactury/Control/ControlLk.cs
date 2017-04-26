using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZYB.Model;
using WZYB.BLL;
using System.Threading;

namespace WZYB.Control
{
    public class ControlLk
    {
        public int sleepTime = int.Parse(System.Configuration.ConfigurationManager.AppSettings["DDJ_sleeptime"].ToString());
        public bool IsStart = false;
        //立库库前库后输送机坐标的单位长度
        public float unitLength = 1.44f;

        public float unitLengthDDJ_x = 1.198f;
        public float unitLengthDDJ_y = 0.677f;

        public ControlLk()
        {
            IsStart = true;
        }


        //public int DdjId;
        //数据库只记录变化数据
        #region 托盘处理逻辑

        public void PallertThreadFunc(object o)
        {
            try
            {
                int[] xmlIndex = getPallertXmlIndex();
                while (true)
                {
                    if (IsStart)
                    {
                        List<CGKpellert> listPallert = CGKBll.GetCGKpellertModelAll();
                        setPallertData(listPallert, xmlIndex);
                    }
                    Thread.Sleep(sleepTime);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void setPallertData(List<CGKpellert> o, int[] xmlIndex)
        {
            if (o != null)
            {
                foreach (CGKpellert pallert in o)
                {
                    CGKBll.DelCGKpellert(pallert.CGKpellertid);
                    ComTCPLib.SetOutputAsUINT(1, xmlIndex[pallert.CGKpellertid-1], (UInt16) pallert.CGKpellertstate );
                }
            }
        }

        //i （1-50）
        private int[] getPallertXmlIndex()
        {
            string str = "";
            int[] arr = new int[44];
            int m;
            for (int i = 1; i < 45; i++)
            {
                if (i < 11)
                {
                    str = "TCP_ATTRIBUTE01_IN_RK_INSTATE" + i.ToString();
                }
                else if (i < 17)
                {
                    str = "TCP_ATTRIBUTE01_IN_RK_INSTATE" + (i-10).ToString() + "02";
                }
                else if (i < 23)
                {
                    str = "TCP_ATTRIBUTE01_IN_RK_INSTATE" + (i - 16).ToString() + "03";
                }
                else if (i < 33)
                {
                    str = "TCP_ATTRIBUTE01_IN_CK_INSTATE" + (i - 22).ToString();
                }
                else if (i < 39)
                {
                    str = "TCP_ATTRIBUTE01_IN_CK_INSTATE" + (i - 32).ToString() + "02";
                }
                else if (i < 45)
                {
                    str = "TCP_ATTRIBUTE01_IN_CK_INSTATE" + (i - 38).ToString() + "03";
                }
                //else if (i < 51)
                //{
                //    str = "TCP_ATTRIBUTE01_IN_CK_INSTATE" + (i - 44).ToString() + "04";
                //}
                m = GetIdex.getDicOutputIndex(str);
                arr[i - 1] = m;
            }

            return arr;
        }
        #endregion


        #region 堆垛机处理逻辑

        public void DDJThreadFunc(object o)
        {
            try
            {
                CGKddj lastDdj = null;
                int DdjId = Convert.ToInt16(o);
                int[] DDJXmlIndex = getDdjXmlIndex(DdjId);
                while (true)
                {
                    if (IsStart)
                    {
                        CGKddj thisDdj = CGKBll.GetCGKddjModel(DdjId);
                        if (thisDdj != null)
                        {
                            setDdjData(lastDdj, thisDdj, DDJXmlIndex,DdjId);
                            lastDdj = thisDdj;
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


        private CGKddj setOutModelDdj(CGKddj model)
        {
            if (model ==null)
            return null;
            if (model.CGKddj_source <0.1f)
            {
                model.CGKddj_source = 0.0f;
            }
            else
            {
                model.CGKddj_source = model.CGKddj_source * unitLengthDDJ_x + 0.25f;
            }
            if (model.CGKddj_tgt < 0.1f)
            {
                model.CGKddj_tgt = 0.0f;
            }
            else
            {
                model.CGKddj_tgt = model.CGKddj_tgt * unitLengthDDJ_x + 0.25f;
            }
            
            
            if (model.CGKddj_platformtgt <0.01f)
            {
                model.CGKddj_platformtgt = 0.01f;
            }
            else
            {
                model.CGKddj_platformtgt = (model.CGKddj_platformtgt - 1) * unitLengthDDJ_y + 0.005f;
            }
            
            if (model.CGKddj_forktgt ==0.0f)
            {
                model.CGKddj_forktgt = 0.0f;
            }
                //left
            else if (model.CGKddj_forktgt == 2.0f)
            {
                model.CGKddj_forktgt =0- 0.68f;
            }
                //right
            else if (model.CGKddj_forktgt == 1.0f)
            {
                model.CGKddj_forktgt = 0.68f;
            }
                //left 2
            else if (model.CGKddj_forktgt == 4.0f)
            {
                model.CGKddj_forktgt = 0- 0.68f*2;
            }
                //right 2
            else if (model.CGKddj_forktgt == 3.0f)
            {
                model.CGKddj_forktgt = 0.68f*2;
            }
            return model;

        }


        private void setDdjData(CGKddj lastddj, CGKddj thisddj, int[] xmlIndex, int DdjId)
        {
            int DDJXmlIndex_state = xmlIndex[0];
            int DDJXmlIndex_tgt = xmlIndex[1];
            int DDJXmlIndex_source = xmlIndex[2];
            int DDJXmlIndex_forktgt = xmlIndex[3];
            int DDJXmlIndex_platformtgt = xmlIndex[4];
            int DDJXmlIndex_pallertstate = xmlIndex[5];

            //堆垛机去取托盘的时候高亮显示目标托盘
            Rack r = getRackIdByModel(lastddj, thisddj, DdjId);
            if(r != null)
            {
                RackBll rb = new RackBll();
                rb.InsertRack(r);
            }
            lastddj = setOutModelDdj(lastddj);
            thisddj = setOutModelDdj(thisddj);
            

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
                ComTCPLib.SetOutputAsUINT(1, DDJXmlIndex_state, (UInt16)thisddj.CGKddj_state);
                ComTCPLib.SetOutputAsREAL32(1, DDJXmlIndex_tgt, thisddj.CGKddj_tgt);
                ComTCPLib.SetOutputAsREAL32(1, DDJXmlIndex_forktgt, thisddj.CGKddj_forktgt);
                ComTCPLib.SetOutputAsREAL32(1, DDJXmlIndex_platformtgt, thisddj.CGKddj_platformtgt);
                ComTCPLib.SetOutputAsUINT(1, DDJXmlIndex_pallertstate, (UInt16)thisddj.CGKddj_pallertstate);
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
                    ComTCPLib.SetOutputAsUINT(1, DDJXmlIndex_state,(UInt16)thisddj.CGKddj_state);
                if (thisddj.CGKddj_tgt != lastddj.CGKddj_tgt)
                    ComTCPLib.SetOutputAsREAL32(1, DDJXmlIndex_tgt, thisddj.CGKddj_tgt);
                if (thisddj.CGKddj_forktgt != lastddj.CGKddj_forktgt)
                    ComTCPLib.SetOutputAsREAL32(1, DDJXmlIndex_forktgt, thisddj.CGKddj_forktgt);
                if (thisddj.CGKddj_platformtgt != lastddj.CGKddj_platformtgt)
                    ComTCPLib.SetOutputAsREAL32(1, DDJXmlIndex_platformtgt, thisddj.CGKddj_platformtgt);
                if (thisddj.CGKddj_pallertstate != lastddj.CGKddj_pallertstate)
                    ComTCPLib.SetOutputAsUINT(1, DDJXmlIndex_pallertstate, (UInt16)thisddj.CGKddj_pallertstate);
            }

        }


        private Rack getRackIdByModel(CGKddj lastddj, CGKddj thisddj, int DdjId)
        {
            //当托盘无货 且 当前叉子和载货台目标不和上次相同时
            if ((lastddj == null || (thisddj.CGKddj_tgt != lastddj.CGKddj_tgt || thisddj.CGKddj_forktgt != lastddj.CGKddj_forktgt || thisddj.CGKddj_platformtgt != lastddj.CGKddj_platformtgt)) && (int)thisddj.CGKddj_forktgt != 0 && thisddj.CGKddj_pallertstate == 0)
            {

            }
            else
            {
                return null;
            }
            WZYB.Model.Rack r = new Rack();
            //堆垛机的坐标和货位生成的坐标是反的
            r.Rack_colum =38- (int)thisddj.CGKddj_tgt;
            r.Rack_row = 13-(int)thisddj.CGKddj_platformtgt;
            if (DdjId == 1)
            {
                if ((int)thisddj.CGKddj_forktgt == 1)
                {
                    r.Rack_z = 1;
                }
                else if ((int)thisddj.CGKddj_forktgt == 2)
                {
                    r.Rack_z = 0;
                }
                r.Rack_type = 1;
            }
            else if (DdjId == 2)
            {
                if ((int)thisddj.CGKddj_forktgt == 1)
                {
                    r.Rack_z = 3;
                }
                else if ((int)thisddj.CGKddj_forktgt == 2)
                {
                    r.Rack_z = 2;
                }
                r.Rack_type = 1;
            }
            else if (DdjId == 3)
            {
                if ((int)thisddj.CGKddj_forktgt == 1)
                {
                    r.Rack_z = 0;
                }
                else if ((int)thisddj.CGKddj_forktgt == 2)
                {
                    r.Rack_z = 1;
                }
                else if ((int)thisddj.CGKddj_forktgt == 3)
                {
                    r.Rack_z = 2;
                }
                else if ((int)thisddj.CGKddj_forktgt == 4)
                {
                    r.Rack_z = 3;
                }
                r.Rack_type = 2;
            }
            r.Rack_id = 1;
            r.Rack_state = r.Rack_type*10+ 2;
            return r;

        }
        // i (1 - 3)
        private int[] getDdjXmlIndex(int i)
        {
            int[] index = new int[6];
            index[0] = GetIdex.getDicOutputIndex("TCP_ATTRIBUTE01_IN_DDJ" + i.ToString() + "_DDJ_STATE");
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
            try
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
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void setCarData(CGKcar lastData, CGKcar thisData, int[] xmlIndex)
        {
            int CarXmlIndex_state = xmlIndex[0];
            int CarXmlIndex_tgt = xmlIndex[1];
            int CarXmlIndex_source = xmlIndex[2];
            int CarXmlIndex_pallertstate = xmlIndex[3];
            //0 HIDE 1 SHOW 左出 2左入 3右出 4右入 5
            //0空 1 取货 2 放货
            if (lastData == null)
            {
                
                ComTCPLib.SetOutputAsREAL32(1, CarXmlIndex_source, ( thisData.CGKcar_source -1)* unitLength);
                ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_state, (UInt16)thisData.CGKcar_state);
                ComTCPLib.SetOutputAsREAL32(1, CarXmlIndex_tgt, (thisData.CGKcar_tgt - 1) * unitLength);
                UInt16 outPalletState = getOutPalletState(thisData);
               
                ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_pallertstate, outPalletState);
            }
            else if (!thisData.Equals(lastData))
            {
               
                if (thisData.CGKcar_source != lastData.CGKcar_source)
                    ComTCPLib.SetOutputAsREAL32(1, CarXmlIndex_source, (thisData.CGKcar_source - 1) * unitLength);
                if (thisData.CGKcar_state != lastData.CGKcar_state)
                    ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_state, (UInt16)thisData.CGKcar_state);
                if (thisData.CGKcar_tgt != lastData.CGKcar_tgt)
                    ComTCPLib.SetOutputAsREAL32(1, CarXmlIndex_tgt, (thisData.CGKcar_tgt - 1) * unitLength);
                
                if (thisData.CGKcar_action != lastData.CGKcar_action)
                {
                    UInt16 outPalletState = getOutPalletState(thisData);
                    ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_pallertstate, outPalletState);
                }
            }
        }

        private UInt16 getOutPalletState(CGKcar thisData)
        {
            UInt16 outPalletState = 0;
            if (thisData.CGKcar_id == 1 )
            {
                return (UInt16)thisData.CGKcar_pallertstate;
            }
            if (thisData.CGKcar_action == 0)
            {
                outPalletState = (UInt16)thisData.CGKcar_pallertstate;
            }
            else if (thisData.CGKcar_action == 1)
            {
                if (thisData.target_z == 1)
                {
                    outPalletState = 3;
                }
                else if (thisData.target_z == 2)
                {
                    outPalletState = 5;
                }
            }
            else if (thisData.CGKcar_action == 2)
            {
                if (thisData.target_z == 1)
                {
                    outPalletState = 2;
                }
                else if (thisData.target_z == 2)
                {
                    outPalletState = 4;
                }
            }
            return outPalletState;
        }
        //i (1 2)
        private int[] getCarXmlIndex(int i)
        {
            string str = "";
            if (i == 1)
            {
                str = "RUKU";
            }
            else if (i == 2)
            {
                str = "CHUKU";
            }
            int[] index = new int[4];
            index[0] = GetIdex.getDicOutputIndex("TCP_ATTRIBUTE01_IN_" + str + "_STATE");
            index[1] = GetIdex.getDicOutputIndex("TCP_ATTRIBUTE01_IN_" + str + "_TGT");
            index[2] = GetIdex.getDicOutputIndex("TCP_ATTRIBUTE01_IN_" + str + "_ORI");
            index[3] = GetIdex.getDicOutputIndex("TCP_ATTRIBUTE01_IN_" + str + "_PALLET_STATE");

            return index;
        }
        #endregion



    }
}
