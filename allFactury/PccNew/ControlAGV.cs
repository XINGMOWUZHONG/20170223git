using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WZYB.Model;
using WZYB.BLL;
using System.Threading;

namespace PccNew
{
    public  class ControlAgv
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
        private int ThreadTime = 300;
        public int handle = 1;
        public int AgvCount = 5;
        public bool IsStart = false;
        public string[] PostiveLineArr = null;
        public Dictionary<string, string> platFormDic = null;
       
        public void AGVThreadFunc(object obj)
        {
            try
            {
                AGVStatus lastModel = null;
                int ID = Convert.ToInt16(obj);
                int[] XmlIndex = getXmlIndex(ID);
                PostiveLineArr = AGVStatusBLL.getPostiveLine();
                platFormDic = AGVStatusBLL.getPlatFormLine();
                while (true)
                {
                    if (IsStart)
                    {
                        AGVStatus thisModel = AGVStatusBLL.GetAgvModel(ID);
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
        private int[] getXmlIndex(int i)
        {
            int[] index = new int[6];
            index[0] = GetIdex.getDicOutputIndex("ATTRIBUTE01_DIR" + i.ToString());
            index[1] = GetIdex.getDicOutputIndex("ATTRIBUTE01_CAR_STATE" + i.ToString());
            index[2] = GetIdex.getDicOutputIndex("ATTRIBUTE01_ISLASTLINE" + i.ToString() );
            index[3] = GetIdex.getDicOutputIndex("ATTRIBUTE01_IN_Path" + i.ToString() );
            index[4] = GetIdex.getDicOutputIndex("ATTRIBUTE01_TASK_STATE" + i.ToString() );
            index[5] = GetIdex.getDicOutputIndex("ATTRIBUTE01_PALLERT_STATE" + i.ToString());
            return index;
        }

        private void setCarData(AGVStatus lastData, AGVStatus thisData, int[] xmlIndex)
        {
            int CarXmlIndex_line = xmlIndex[3];
            int CarXmlIndex_carstate = xmlIndex[1];
            int CarXmlIndex_palletstate = xmlIndex[5];
            int CarXmlIndex_taskstate = xmlIndex[4];
            int CarXmlIndex_dir = xmlIndex[0];
            int CarXmlIndex_islastline = xmlIndex[2];

            if (lastData == null)
            {
                ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_line, UInt32.Parse(thisData.line));
                ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_carstate, UInt32.Parse(thisData.carstate.ToString ()));
                ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_palletstate, UInt16.Parse(thisData.palletstate.ToString()));
                ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_taskstate, UInt16.Parse(thisData.taskstate.ToString()));
                if (PostiveLineArr.Contains(thisData.line.ToString()))
                {
                    ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_dir, UInt16.Parse("1"));
                }
                else
                {
                    ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_dir, UInt16.Parse("0"));
                }
                string Platlines = platFormDic[thisData.target];
                if (Platlines != null && Platlines.Split(',').Contains(thisData.line))
                {
                    ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_islastline, UInt16.Parse("1"));
                }
                else
                {
                    ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_islastline, UInt16.Parse("0"));
                }
                
            }
            else if (!thisData.Equals(lastData))
            {
                if (thisData.line != lastData.line)
                {
                    ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_line, UInt32.Parse(thisData.line));
                    if (PostiveLineArr.Contains(thisData.line.ToString()))
                    {
                        ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_dir, UInt16.Parse("1"));
                    }
                    else
                    {
                        ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_dir, UInt16.Parse("0"));
                    }
                }
                if (thisData.carstate != lastData.carstate)
                ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_carstate, UInt32.Parse(thisData.carstate.ToString()));
                if (thisData.palletstate != lastData.palletstate)
                ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_palletstate, UInt16.Parse(thisData.palletstate.ToString()));
                if (thisData.taskstate != lastData.taskstate)
                ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_taskstate, UInt16.Parse(thisData.taskstate.ToString()));
                if (thisData.target != lastData.target)
                {
                    string Platlines = platFormDic[thisData.target];
                    if (Platlines != null && Platlines.Split(',').Contains(thisData.line))
                    {
                        ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_islastline, UInt16.Parse("1"));
                    }
                    else
                    {
                        ComTCPLib.SetOutputAsUINT(1, CarXmlIndex_islastline, UInt16.Parse("0"));
                    }
                }

            }

        }

    }
}
