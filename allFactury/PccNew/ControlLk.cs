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
        //立库库前库后输送机坐标的单位长度
        public float unitLength = 1.44f;

        public float unitLengthDDJ_x = 1.198f;
        public float unitLengthDDJ_y = 0.677f;
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
                    ComTCPLib.SetOutputAsUINT(1, xmlIndex[pallert.CGKpellertid], uint.Parse( pallert.CGKpellertstate.ToString()));
                }
            }
        }

        //i （1-50）
        private int[] getPallertXmlIndex()
        {
            string str = "";
            int[] arr = new int[50];
            int m;
            for (int i = 1; i < 51; i++)
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
                else if (i < 51)
                {
                    str = "TCP_ATTRIBUTE01_IN_CK_INSTATE" + (i - 44).ToString() + "04";
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
            model.CGKddj_source = model.CGKddj_source * unitLengthDDJ_x+0.25f;
            model.CGKddj_tgt = model.CGKddj_tgt * unitLengthDDJ_x + 0.25f;
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
                model.CGKddj_forktgt = 0- 0.8f*2;
            }
                //right 2
            else if (model.CGKddj_forktgt == 3.0f)
            {
                model.CGKddj_forktgt = 0.8f*2;
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
                ComTCPLib.SetOutputAsUINT(1, DDJXmlIndex_state, UInt16.Parse(thisddj.CGKddj_state.ToString()));
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


        private Rack getRackIdByModel(CGKddj lastddj, CGKddj thisddj, int DdjId)
        {
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
            }
            else if (DdjId == 3)
            {
                if ((int)thisddj.CGKddj_forktgt == 1)
                {
                    r.Rack_z = 6;
                }
                else if ((int)thisddj.CGKddj_forktgt == 2)
                {
                    r.Rack_z = 5;
                }
                else if ((int)thisddj.CGKddj_forktgt == 3)
                {
                    r.Rack_z = 7;
                }
                else if ((int)thisddj.CGKddj_forktgt == 4)
                {
                    r.Rack_z = 2;
                }
            }
            r.Rack_type = 1;
            r.Rack_id = 1;
            r.Rack_state = 2;
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
            lastData = setOutModel(lastData);
            thisData = setOutModel(thisData);

            if (lastData == null)
            {
                if (thisData.CGKcar_current_out == thisData.CGKcar_tgt_out_x)
                {
                    ComTCPLib.SetOutputAsREAL32(1, CarXmlIndex_source, thisData.CGKcar_tgt_out_x);
                }
                else
                {
                    ComTCPLib.SetOutputAsREAL32(1, CarXmlIndex_source, thisData.CGKcar_source_out);
                }
                ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_state, UInt16.Parse(thisData.CGKcar_state.ToString()));
                ComTCPLib.SetOutputAsREAL32(1, CarXmlIndex_tgt, thisData.CGKcar_tgt_out_x);
                ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_pallertstate, UInt16.Parse(thisData.CGKcar_state_out.ToString()));
            }
            else if (!thisData.Equals(lastData))
            {
                if (thisData.CGKcar_current_out == thisData.CGKcar_tgt_out_x)
                {
                    ComTCPLib.SetOutputAsREAL32(1, CarXmlIndex_source, thisData.CGKcar_tgt_out_x);
                }
                else
                {
                    if (thisData.CGKcar_source != lastData.CGKcar_source)
                        ComTCPLib.SetOutputAsREAL32(1, CarXmlIndex_source, thisData.CGKcar_source_out);
                }
                if (thisData.CGKcar_state != lastData.CGKcar_state)
                    ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_state, UInt16.Parse(thisData.CGKcar_state.ToString()));
                if (thisData.CGKcar_tgt_out_x != lastData.CGKcar_tgt_out_x)
                    ComTCPLib.SetOutputAsREAL32(1, CarXmlIndex_tgt, thisData.CGKcar_tgt_out_x);
                //if (thisData.CGKcar_pallertstate != lastData.CGKcar_pallertstate)
                    ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_pallertstate, UInt16.Parse(thisData.CGKcar_state_out.ToString()));

            }

        }

        private CGKcar setOutModel(CGKcar model)
        {
            if(model == null)
            {
                return null;
            }
            model.CGKcar_tgt_out_x = (int.Parse(model.CGKcar_tgt.Split(',')[0].ToString()) -1)* unitLength;
            model.CGKcar_tgt_out_z = int.Parse(model.CGKcar_tgt.Split(',')[1].ToString()) % 2;
            model.CGKcar_source_out = (int.Parse(model.CGKcar_source.Split(',')[0].ToString()) -1) * unitLength;
            model.CGKcar_current_out = model.CGKcar_current * 0.001f;

            if (model.CGKcar_id == 2)
            {
                if (model.CGKcar_action < 1)
                {
                    model.CGKcar_state_out = model.CGKcar_pallertstate;
                }
                else
                {
                    if (model.CGKcar_tgt_out_z == 1)
                    {
                        if (model.CGKcar_pallertstate == 0)
                        {
                            model.CGKcar_state_out = 3;
                        }
                        else if (model.CGKcar_pallertstate == 1)
                        {
                            model.CGKcar_state_out = 2;
                        }
                    }
                    else if (model.CGKcar_tgt_out_z == 0)
                    {
                        if (model.CGKcar_pallertstate == 0)
                        {
                            model.CGKcar_state_out = 5;
                        }
                        else if (model.CGKcar_pallertstate == 1)
                        {
                            model.CGKcar_state_out = 4;
                        }
                    }
                    else
                    {
                        model.CGKcar_state_out = model.CGKcar_pallertstate;
                    }
                }
               
            }
            else
            {
                model.CGKcar_state_out = model.CGKcar_pallertstate;
            }
            return model;
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
