using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using IPhysics;
using Microsoft.Win32;
using System.Threading;
using System.Xml;


using Storage;
using StorageArea.Model;
namespace PccNew
{
    public partial class PCC : Form
    {
        RemoteInterface remote;
        int handle = -1;
        ExternalAppDock iPhysicsDoc;
        bool loading_done;

        //初始化
        public void Initialization()
        {
            remote = new RemoteInterface(true, true);

            iPhysicsDoc = new ExternalAppDock();
            this.panel1.Controls.Add(iPhysicsDoc);
            iPhysicsDoc.Dock = DockStyle.Fill;
            if (!remote.IsStarted)
                remote.StartIPhysics(6000);
            int timeout = 30000;
            int sleepTime = 500;
            while (!remote.IsConnected && timeout > 0)
            {
                System.Threading.Thread.Sleep(sleepTime);
                timeout -= sleepTime;

                if (!remote.IsConnected)
                    remote.Connect("localhost", 6000);
            }

            iPhysicsDoc.DockExternalApp(remote.ExeProcess, iPhysicsDoc.Parent);
            if (!(timeout > 0))
                throw new Exception("Error, cannot connect to industrialPhysics");
            //Default File Load
            RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            String Path = key.GetValue(
                "Software\\machineering\\industrialPhysics\\InstallDir(x64)"
                , "c:\\Program Files\\machineering\\industrialPhysics(x64)").ToString();
            //IPhysics_Command command = new LoadDocument(Environment.CurrentDirectory + "/light.iphz");
            //remote.execute(command);
            //remote.lookFromIsometry();
            //remote.switchModePresentation(true);
            //remote.zoomOut(0);
            //remote.sendPlay();
            //loading_done = true;
            //remote.sendReset();
            //remote.sendPlay();
        }

        public void loadDemo()
        {
            IPhysics_Command command = new LoadDocument(Environment.CurrentDirectory + System.Configuration.ConfigurationManager.AppSettings["modefile"].ToString());
            remote.execute(command);
            if (System.Configuration.ConfigurationManager.AppSettings["isDebug"].ToString() == "0")
            {
                remote.switchModePresentation(true);
            }
            loading_done = true;
        }

        //建立链接
        private int Connect()
        {
            if (handle >= 0)
                return -10;

            ComTCPLib.Init();

            // Create a new comtcp node
            int localhandle = ComTCPLib.CreateNode("Hello_industrialPhysics");
            if (localhandle < 0)
                return -1;

            // open the config file
            string filepath = Environment.CurrentDirectory + "/CodeGen.xml";
            //string filepath = Environment.CurrentDirectory + @"\CodeGen.xml";
            if (ComTCPLib.Result.Failed == ComTCPLib.LoadConfig(localhandle, filepath))
                return -2;

            // Start the internal thread system
            if (ComTCPLib.Result.Failed == ComTCPLib.Start(localhandle))
                return -3;

            // Connect to running industrialPhysics as specified in the file
            if (ComTCPLib.Result.Failed == ComTCPLib.Connect(localhandle))
                return -4;

            int numOutputs = ComTCPLib.GetNumOutputs(localhandle);
            //float[] outputValues = new float[numOutputs];

            //if (6 != numOutputs)
            //{
            //    return Disconnect();
            //}

            handle = localhandle;

            return 0;
        }

        //关闭连接
        private int Disconnect()
        {
            if (handle < 0)
                return -1;

            // Disconnect
            if (ComTCPLib.Result.Failed == ComTCPLib.Disconnect(handle))
                return -1000;

            // Stop the threading
            if (ComTCPLib.Result.Failed == ComTCPLib.Stop(handle))
                return -1001;

            // delete the node
            if (ComTCPLib.Result.Failed == ComTCPLib.DeleteNode(handle))
                return -1002;

            return 0;
        }


        public PCC()
        {
            InitializeComponent();
            Initialization();
            loadDemo();
            remote.setCustomView("V_PCC");
            Thread.Sleep(2000);
            //InitializStorage();
        }

        //启动运行 设置基础数据
        private void button1_Click(object sender, EventArgs e)
        {
            remote.sendReset();
            remote.sendPlay();
            Connect();

            setBaseData();
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;

            startAll();
        }

        //停止运行
        private void button2_Click(object sender, EventArgs e)
        {
            remote.sendReset();
            remote.sendReset();
            Disconnect();
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;

            //20170225 add ---------
            stopAll();
        }

        //暂停
        private void button3_Click(object sender, EventArgs e)
        {
            remote.sendPause();
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            //20170225 add ---------
            pauseAll();
        }

        //继续
        private void button4_Click(object sender, EventArgs e)
        {
            remote.sendPlay();
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;

            goonAll();
        }

        //timer 不停的刷新数据
        private void timer1_Tick(object sender, EventArgs e)
        {
            setModelData();
        }

        //调试
        private void button5_Click(object sender, EventArgs e)
        {
            
            setBaseData();
        }


        //-------------------------------------------------------------------------------
        //从新设置基础数据
        //public DBtest dd = new DBtest();
        public ControlPcc pcccontrol2 = new ControlPcc();
        public void setBaseData()
        {
            dd = new DBtest();
            this.timer1.Interval = int.Parse(System.Configuration.ConfigurationManager.AppSettings["car_interval"].ToString());

            pcccontrol2.setBaseData(this.handle);
        }

       
        //设置模型数据
        public void setModelData()
        {
            try
            { 
                if (pcccontrol2.flag == false)
                {
                    return;
                }
                if (pcccontrol2.flag == true)
                {
                    pcccontrol2.flag = false;
                }
                pcccontrol2.setModelData(this.handle);
                #region
                //货位的处理
                //if (pcccontrol2.storageAreaState != 0)
                //{
                //    switch (pcccontrol2.storageAreaState)
                //    {
                //        case 1:
                //            Storage_PCC.Change(0, int.Parse(pcccontrol2.lastDr["DestLocationCode"].ToString()), 0, 1, 1);
                //            break;
                //        case 2:
                //            Storage_PCC.Change(1, int.Parse(pcccontrol2.lastDr["DestLocationCode"].ToString()), 0, 1, 1);
                //            break;
                //        case 3:
                //            Storage_PCC.Change(0, int.Parse(pcccontrol2.lastDr["DestLocationCode"].ToString()), 0, 0, 1);
                //            break;
                //        case 4:
                //            Storage_PCC.Change(1, int.Parse(pcccontrol2.lastDr["DestLocationCode"].ToString()), 0, 0, 1);
                //            break;
                //    }
                //    pcccontrol2.storageAreaState = 0;
                //}
                #endregion
                pcccontrol2.flag = true;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        DBtest dd = new DBtest();
        private void timer2_Tick(object sender, EventArgs e)
        {
            dd.testdata2();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "<")
            {
                this.panel2.Width = 0;
                button6.Location = new Point(0, (panel2.Height - button6.Height) / 2);
                button6.Text = ">";
            }
            else
            {
                this.panel2.Width = 120;
                button6.Location = new Point(120, (panel2.Height - button6.Height) / 2);
                button6.Text = "<";
            }
        }

        private void PCC_Resize(object sender, EventArgs e)
        {
            if (button6.Text == "<")
            {
                button6.Location = new Point(120, (panel2.Height - button6.Height) / 2);
            }
            else
            {
                button6.Location = new Point(0, (panel2.Height - button6.Height) / 2);
            }
        }

        //点击button事件
        private void timer3_Tick(object sender, EventArgs e)
        {
            int index = pcccontrol2.getBtnClickIndex(this.handle);
            if(index == 0)
            {
            
            }
            else if(index == 1)
            {
                //小车点击
                //MessageBox.Show("小车");
            }
            else if(index == 2)
            {
                //托盘点击
                //MessageBox.Show("托盘");
            }
        }










        //----------------------------------------------------------
        //20170225 add ---------
        //----------------------------------------------------------
        #region 20170225 new jicheng
        public ControlLk LKcontrol = new ControlLk();
        public ControlStorage Storagecontrol = new ControlStorage();

       
        //storage 货位的初始化和点击
        #region 

        public General Storage_PCC = null;
        public General Storage_NEW = null;

        //配餐车 货位的点击 触发事件
        private static void PCC_placeSelected(StorageArea.Model.Place selectedPlace)
        {
            var placeData = selectedPlace.GetData();
        }
        private static void NEW_placeSelected(StorageArea.Model.Place selectedPlace)
        {
            var placeData = selectedPlace.GetData();
        }

        //初始化 托盘
        public void InitializStorage()
        {
          //初始化 配餐 托盘
            Storage_PCC = new General();
            Storage_PCC.Initialize("StorageArea_pcc");
            Storage_PCC.connection.PlaceSelected += PCC_placeSelected;
            Storage_PCC.FullAll();

            //初始化 新库 托盘
            Storage_NEW = new General();
            Storage_NEW.Initialize("StorageArea_new");
            Storage_NEW.connection.PlaceSelected += NEW_placeSelected;
            //Storage_NEW.FullAll();
        }

        //第一次默认加载数据库的货位信息
        private Thread ThreadStorageShowPallet;
        public void InitializStorageShowPallet()
        {
            List<General> lg = new List<General>();
            if (Storage_PCC!=null)
            {
                lg.Add(Storage_PCC);
            }
            if(Storage_NEW !=null )
            {
                lg.Add(Storage_NEW);
            }
            ThreadStorageShowPallet = new Thread(new ParameterizedThreadStart(Storagecontrol.InitializeStoragePallet));
            ThreadStorageShowPallet.Start(lg);

        }
        #endregion


        //新立库堆垛机数据刷新处理
        #region
        private Thread[] ThreadNewLikuDDJList;
        private void StartThreadNewLikuDDJ()
        {
            ThreadNewLikuDDJList = new Thread[3];
            for (int i = 0; i < 3;i++ )
            {
                ThreadNewLikuDDJList[i] = new Thread(new ParameterizedThreadStart(LKcontrol.DDJThreadFunc));
                ThreadNewLikuDDJList[i].Start(i+1);
            }
        }
        #endregion


        //托盘的线程操作
        #region
        private Thread ThreadNewLikuPallert;
        private void StartThreadNewLikuPallert()
        {
            ThreadNewLikuPallert = new Thread(new ParameterizedThreadStart(LKcontrol.PallertThreadFunc));
            ThreadNewLikuPallert.Start();
        }
        #endregion


        //穿梭车位处理
        #region
        private Thread[] ThreadNewLikuCscList;
        private void StartThreadNewLikuCsc()
        {
            ThreadNewLikuCscList = new Thread[2];
            for (int i = 0; i < 2; i++)
            {
                ThreadNewLikuCscList[i] = new Thread(new ParameterizedThreadStart(LKcontrol.CarThreadFunc));
                ThreadNewLikuCscList[i].Start(i + 1);
            }
        }
        #endregion


        //货位线程操作
        #region
        private Thread ThreaStoragePcc;
        private Thread ThreaStorageNew;
        private void StartThreadStorage()
        {
            ThreaStoragePcc = new Thread(new ParameterizedThreadStart(Storagecontrol.StorageThreadFunc));
            ThreaStorageNew = new Thread(new ParameterizedThreadStart(Storagecontrol.StorageThreadFunc));
            ThreaStoragePcc.Start(Storage_PCC);
            ThreaStorageNew.Start(Storage_NEW);
        }
        #endregion

       
        #endregion

        //----------------------------------------------------------
        //20170226  OCS add ---------
        //----------------------------------------------------------
        #region 20170226 new jicheng
        private ControlOcs OcsControl = new ControlOcs();
        private Thread[] ocsThread;
        private void StartThreadOcs()
        {
            ocsThread = new Thread[OcsControl.ocsCarCount];
            for (int i = 0; i < OcsControl.ocsCarCount; i++)
            {
                ocsThread[i] = new Thread(new ParameterizedThreadStart(OcsControl.OcsThreadFunc));
                ocsThread[i].Start(i + 1);
            }
        }

        private void StopThreadOcs()
        {
            for (int i = 0; i < ocsThread.Length; i++)
            {
                ocsThread[i].Abort();
            }
        }
        #endregion

        //悬挂升降机的线程操作
        #region
        private Thread ThreadOcsLift;
        public ControlOcsLift OcsLiftcontrol = new ControlOcsLift();
        private void StartThreadOcsLift()
        {
            ThreadOcsLift = new Thread(new ParameterizedThreadStart(OcsLiftcontrol.OcsLiftThreadFunc));
            ThreadOcsLift.Start();
        }
        #endregion


        /// <summary>
        /// 20170304 wge   屏幕点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public GetIdex gi = new GetIdex();
        bool flag = false;
        private void TimerScreen_Tick(object sender, EventArgs e)
        {
            if(!flag)
            {
                flag = true;
                for (int m = 0; m < 3; m++)
                {
                    if (bool.Parse(gi.readValue("SCREEN" + (m + 1).ToString() + "01_ButtonPress", 3, 1).ToString()))
                    {
                        Browser bb = new Browser();
                        string mesLink = "http://10.1.50.93:8080/mes/main.shtml";
                        bb.url = mesLink;
                        bb.ShowDialog();
                        if (bb.DialogResult == DialogResult.OK)
                        {
                            bb.Close();
                        }
                    }
                }
                flag = false;
            }
            
        }
        public ControlLightAndScreen clight = new ControlLightAndScreen();

        //立库 悬挂 悬挂升降机 货位方法初始化 货位第一次生成 货位监控变化  监控主灯 监控点击屏幕
        //开始
        public void startAll()
        {
            //20170225 add --------------
            LKcontrol.IsStart = true;
            Storagecontrol.IsStart = true;
            OcsControl.IsStart = true;
            OcsLiftcontrol.IsStart = true;

            InitializStorage();
            startThreadAll();
            
            TimerScreen.Enabled = true;
            clight.LightThreadFunc();
        }
        //停止
        public void stopAll()
        {
            
            StopThreadAll();
            TimerScreen.Enabled = false;
        }
        //暂停
        public void pauseAll()
        {
            LKcontrol.IsStart = false;
            Storagecontrol.IsStart = false;
            OcsControl.IsStart = false;
            OcsLiftcontrol.IsStart = false;
            TimerScreen.Enabled = false;
        }
        //继续
        public void goonAll()
        {
            LKcontrol.IsStart = true;
            Storagecontrol.IsStart = true;
            OcsControl.IsStart = true;
            OcsLiftcontrol.IsStart = true;
            TimerScreen.Enabled = true;
        }


        public void startThreadAll()
        {
            //立库
            StartThreadNewLikuDDJ();
            //穿梭车
            StartThreadNewLikuCsc();
            //立库货位
            StartThreadNewLikuPallert();
            //货架
            StartThreadStorage();
            //悬挂
            StartThreadOcs();
            //悬挂升降机
            StartThreadOcsLift();
            //第一次加载所有托盘信息
            InitializStorageShowPallet();
        }

        public void StopThreadAll()
        {
            //堆垛机结束线程
            for (int i = 0; i < ThreadNewLikuDDJList.Length; i++)
            {
                ThreadNewLikuDDJList[i].Abort();
            }
            //托盘结束线程
            ThreadNewLikuPallert.Abort();
            //穿梭车结束线程
            for (int i = 0; i < ThreadNewLikuCscList.Length; i++)
            {
                ThreadNewLikuCscList[i].Abort();
            }
            //货位结束线程
            ThreaStoragePcc.Abort();
            ThreaStorageNew.Abort();
            //悬挂线程结束
            StopThreadOcs();
            //悬挂升降机线程结束
            ThreadOcsLift.Abort();
            //默认托盘货位的结束
            ThreadStorageShowPallet.Abort();
        }
    }
}
