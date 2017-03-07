using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WZYB.Model;
using WZYB.BLL;

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
        private int ocsThreadTime = 300;
        public int handle = 1;

        public ControlAgv()
        {
            //agv数据初始化
            agvCarPos = new float[agvCarCount + 1];
            agvThread = new Thread[agvCarCount];
            agvTempLine = new int[agvCarCount + 1];
            agvdirection = new int[agvCarCount + 1];
            agvStopTime = new int[agvCarCount + 1];

            int[] agvTmpSequence = new int[10000];

            for (int i = 1; i <= agvCarCount; i++)
            {
                agvTempLine[i] = 0;
                agvdirection[i] = 0;
                agvStopTime[i] = 0;
                AGVStatus model = AGVStatusBLL.GetModel(i);

                if (model != null)
                {
                    model.line = agvPath[i].Split(',')[0];
                    model.direction = 1;
                    model.sequence = agvTmpSequence[int.Parse(model.line)] + 1;
                    agvTmpSequence[int.Parse(model.line)]++;
                    AGVStatusBLL.Update(model);
                }
                else
                {
                    model = new AGVStatus();
                    model.carId = i;
                    model.line = agvPath[i].Split(',')[0];
                    model.direction = 1;
                    model.sequence = agvTmpSequence[int.Parse(model.line)] + 1;
                    model.backLine = "1";
                    model.position = -1;
                    agvTmpSequence[int.Parse(model.line)]++;
                    AGVStatusBLL.Add(model);
                }
            }
        }

        public void start()
        {
            Thread ThreadAGVLift = new Thread(new ParameterizedThreadStart(CheckStatus));
            ThreadAGVLift.Start(1);
        }

        public void CheckStatus(Object stateInfo)  // 被调用的，被TimerCallback委托的函数，必须是具有object 形参且必须为void的返回值的
        {
            while (true)
            {
                //agv数据模拟
                for (int i = 1; i < agvCarPos.Length; i++)
                {
                    AGVStatus model = AGVStatusBLL.GetModel(i);

                    if (agvCarPos[i] > 0)
                    {
                        if (agvCarPos[i] >= agvLineLength[int.Parse(agvPath[i].Split(',')[agvTempLine[i]])] || agvCarPos[i] == agvEndPos)
                        {
                            if (agvdirection[i] == 0)
                            {
                                if (agvTempLine[i] + 1 < agvPath[i].Split(',').Length)
                                {
                                    agvTempLine[i]++;
                                }
                                else
                                {
                                    if (agvStopTime[i] > 3000)
                                    {
                                        if (agvdirection[i] == 0)
                                            agvdirection[i] = 1;
                                        else
                                            agvdirection[i] = 0;

                                        agvStopTime[i] += 0;
                                    }
                                    else
                                    {
                                        agvStopTime[i] += 500;
                                    }
                                }
                            }
                            else
                            {
                                if (agvTempLine[i] - 1 > 0)
                                {
                                    agvTempLine[i]--;
                                }
                                else
                                {
                                    if (agvStopTime[i] > 3000)
                                    {
                                        if (agvdirection[i] == 0)
                                            agvdirection[i] = 1;
                                        else
                                            agvdirection[i] = 0;

                                        agvStopTime[i] += 0;
                                    }
                                    else
                                    {
                                        agvStopTime[i] += 500;
                                    }
                                }
                            }

                            model.line = agvPath[i].Split(',')[agvTempLine[i]];
                            int count = AGVStatusBLL.getCountByLine(model.line);

                            if (model.line == "6" || model.line == "8" || model.line == "10" || model.line == "14")
                            {
                                if (agvdirection[i] == 0)
                                    model.direction = 2;
                                else
                                    model.direction = 1;
                            }
                            else
                            {
                                if (agvdirection[i] == 0)
                                    model.direction = 1;
                                else
                                    model.direction = 2;
                            }

                            model.sequence = count + 1;
                            AGVStatusBLL.Update(model);
                        }
                    }
                }

                Thread.Sleep(500);
            }
        }

        public void AGVThreadFunc(object obj)
        {
            int index = Convert.ToInt32(obj);
            bool tmp = true;

            while (true)
            {
                //#region 临时使用，正式使用时去掉

                //if (tmp == false)
                //{
                //    if (index == 2)
                //    {
                //        if (agvTempLine[3] > 0)
                //            tmp = true;
                //    }
                //    else if (index == 1)
                //    {
                //        if (agvTempLine[2] > 0)
                //            tmp = true;
                //    }
                //    else
                //        tmp = true;
                //}

                //#endregion

                if (tmp)
                {
                    //数据库最新数据
                    AGVStatus model = AGVStatusBLL.GetModel(index);

                    if (model.position == -1)
                    {
                        //内存数据
                        //OCSStatus oldModel = ocsModelList.Find(s => s.carId == index);
                        int i = agvModelList.FindIndex(s => s.carId == index);

                        //初始
                        if (i == -1)
                        {
                            int count = AGVStatusBLL.getCountByLine(model.line);

                            agvCarPos[index] = (count - model.sequence) * agvCarWidth + agvStartPos;
                            agvModelList.Add(model);
                        }
                        else
                        {
                            //驱动段改变
                            if (agvModelList[i].line != model.line)
                            {
                                if (model.direction == 1)
                                    agvCarPos[index] = agvStartPos;
                                else
                                    agvCarPos[index] = agvLineLength[int.Parse(model.line)] - agvStartPos;
                            }
                            else
                            {
                                if (model.direction == 1)
                                {
                                    if (agvCarPos[index] < agvLineLength[int.Parse(model.line)])
                                        agvCarPos[index] += agvSpeed;
                                }
                                else if (model.direction == 2)
                                {
                                    if (agvCarPos[index] - agvSpeed < agvEndPos)
                                        agvCarPos[index] = agvEndPos;
                                    else
                                        agvCarPos[index] -= agvSpeed;
                                }
                            }

                            agvModelList[i] = model;
                        }
                    }
                    else
                    {
                        agvCarPos[index] = float.Parse(model.position.ToString());
                    }

                    int index1 = GetIdex.getDicOutputIndex("agvCar" + index + "01_input_pos");
                    ComTCPLib.SetOutputAsREAL32(handle, index1, float.Parse(agvCarPos[index].ToString()));
                    index1 = GetIdex.getDicOutputIndex("agvCar" + index + "01_input_Path");
                    ComTCPLib.SetOutputAsINT(handle, index1, int.Parse(model.line.ToString()));
                }

                Thread.Sleep(ocsThreadTime);
            }
        }


    }
}
