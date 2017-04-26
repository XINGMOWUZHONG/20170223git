using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WZYB.Model;
using WZYB.BLL;
using System.Threading;

namespace WZYB.Control
{
    public  class ControlPeiCan
    {
        #region agv
        /// <summary>
        /// agv小车数量
        /// </summary>
        private int agvCarCount = 1;
        /// <summary>
        /// agv小车速度
        /// </summary>
        private float agvSpeed = 0.05f;
        /// <summary>
        /// agv小车起始位置
        /// </summary>
        private float agvStartPos = 0.01f;
        /// <summary>
        /// agv小车起始位置
        /// </summary>
        private float agvEndPos = 0.001f;
        /// <summary>
        /// agv小车车身宽度
        /// </summary>
        private float agvCarWidth = 1.1f;
        /// <summary>
        /// agv小车线程
        /// </summary>
        private Thread[] agvThread;
        /// <summary>
        /// agv小车位置
        /// </summary>
        private float[] agvCarPos;
        /// <summary>
        /// agv小车缓存数据
        /// </summary>
        private List<AGVStatus> agvModelList = new List<AGVStatus>();
        /// <summary>
        /// agv小车线程刷新时间
        /// </summary>
        private int agvThreadTime = 300;
        /// <summary>
        /// 悬挂线体长度
        /// </summary>
        private float[] agvLineLength = { 0, 2.1f, 0.97f, 2.95f, 6.1f, 1.85f, 1.5f, 6.91f, 4.1f, 1.3f, 4.09f, 4.89f, 7.73f, 1.4f, 4.02f };

        /// <summary>
        /// 悬挂小车路线
        /// </summary>
        private string[] agvPath = { "",
                                "1,2,3,4,5,6,7,8",
                                "11,4,5,6,7,9,10",
                                "12,4,5,6,7,9,13,14"
                                };

        /// <summary>
        /// 悬挂小车临时数据
        /// </summary>
        private int[] agvTempLine;
        private int[] agvdirection;
        private int[] agvStopTime;

        #endregion
        private int ThreadTime = int.Parse( System.Configuration.ConfigurationManager.AppSettings["PCC_sleeptime"].ToString());
        public int handle = 1;
        public bool IsStart = false;

        public ControlPeiCan()
        {
            IsStart = true;
        }

        public void PCCThreadFunc(object obj)
        {
            try
            {
                PeiCan lastModel = null;
                int[] XmlIndex = getXmlIndex();
                while (true)
                {
                    if (IsStart)
                    {
                        PeiCan thisModel = PccBll.GetPccModel();
                        if (thisModel != null)
                        {
                            setCarData(lastModel, thisModel, XmlIndex);
                            lastModel = thisModel;
                        }
                    }
                    Thread.Sleep(ThreadTime);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private int[] getXmlIndex()
        {
            int[] index = new int[6];
            index[0] = GetIdex.getDicOutputIndex("PCC_ATTRI01_IN_TGT" );
            index[1] = GetIdex.getDicOutputIndex("PCC_ATTRI01_IN_ORI" );
            index[2] = GetIdex.getDicOutputIndex("PCC_ATTRI01_IN_L_OR_R" );
            index[3] = GetIdex.getDicOutputIndex("PCC_ATTRI01_IN_STATE" );
            index[4] = GetIdex.getDicOutputIndex("PCC_ATTRI01_IN_TASK_STATE" );
            index[5] = GetIdex.getDicOutputIndex("PCC_ATTRI01_IN_PALLET_STATE");
            return index;
        }

        private void setCarData(PeiCan lastData, PeiCan thisData, int[] xmlIndex)
        {
            int PCC_ATTRI01_IN_TGT = xmlIndex[0];
            int PCC_ATTRI01_IN_ORI = xmlIndex[1];
            int PCC_ATTRI01_IN_L_OR_R = xmlIndex[2];
            int PCC_ATTRI01_IN_STATE = xmlIndex[3];
            int PCC_ATTRI01_IN_TASK_STATE = xmlIndex[4];
            int PCC_ATTRI01_IN_PALLET_STATE = xmlIndex[5];

            if (lastData == null)
            {
                ComTCPLib.SetOutputAsREAL32(1, PCC_ATTRI01_IN_TGT, thisData.target * 1.40f + 0.37f);
                ComTCPLib.SetOutputAsREAL32(1, PCC_ATTRI01_IN_ORI, thisData.source * 1.40f + 0.37f);
                ComTCPLib.SetOutputAsUINT(1, PCC_ATTRI01_IN_L_OR_R, (UInt16)thisData.target_z);
                ComTCPLib.SetOutputAsUINT(1, PCC_ATTRI01_IN_TASK_STATE, (UInt16)thisData.TaskState);
                ComTCPLib.SetOutputAsUINT(1, PCC_ATTRI01_IN_PALLET_STATE, (UInt16)thisData.Palletstate);
                ComTCPLib.SetOutputAsUINT(1, PCC_ATTRI01_IN_STATE, (UInt16)thisData.Carstate);
               
                
            }
            else if (!thisData.Equals(lastData))
            {
                if (thisData.target != lastData.target)
                {
                    ComTCPLib.SetOutputAsREAL32(1, PCC_ATTRI01_IN_TGT, thisData.target * 1.40f + 0.37f);
                }
                if (thisData.source != lastData.source)
                {
                    ComTCPLib.SetOutputAsREAL32(1, PCC_ATTRI01_IN_ORI, thisData.source * 1.40f + 0.37f);
                }
                if (thisData.target_z != lastData.target_z)
                {
                    ComTCPLib.SetOutputAsUINT(1, PCC_ATTRI01_IN_L_OR_R, (UInt16)thisData.target_z);
                }
                if (thisData.TaskState != lastData.TaskState)
                {
                    ComTCPLib.SetOutputAsUINT(1, PCC_ATTRI01_IN_TASK_STATE, (UInt16)thisData.TaskState);
                }
                if (thisData.Palletstate != lastData.Palletstate)
                {
                    ComTCPLib.SetOutputAsUINT(1, PCC_ATTRI01_IN_PALLET_STATE, (UInt16)thisData.Palletstate);
                }
                if (thisData.Carstate != lastData.Carstate)
                {
                    ComTCPLib.SetOutputAsUINT(1, PCC_ATTRI01_IN_STATE, (UInt16)thisData.Carstate);
                }


            }

        }

    }
}
