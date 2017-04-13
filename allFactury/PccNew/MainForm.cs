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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CT = new ControlThread();
            CT2 = new ControlThreadClickandLight();
            CST = new ControlStorageThread();
        }

        #region industri method
        public ControlThread CT;
        public ControlThreadClickandLight CT2;
        public ControlStorageThread CST;


        RemoteInterface remote;
        int handle = -1;
        ExternalAppDock iPhysicsDoc;
        bool loading_done;
        bool initializ_done;

        public void Initialization(object obj)
        {
            System.Windows.Forms.Panel pp = (System.Windows.Forms.Panel)obj;
            remote = new RemoteInterface(true, true);

            iPhysicsDoc = new ExternalAppDock();
            pp.Controls.Add(iPhysicsDoc);
            iPhysicsDoc.Dock = DockStyle.Fill;
            if (!remote.IsStarted)
                remote.StartIPhysics( decimal.Parse( System.Configuration.ConfigurationManager.AppSettings["modeport"].ToString()));
            int timeout = 30000;
            int sleepTime = 500;
            while (!remote.IsConnected && timeout > 0)
            {
                System.Threading.Thread.Sleep(sleepTime);
                timeout -= sleepTime;

                if (!remote.IsConnected)
                    remote.Connect("localhost", int.Parse(System.Configuration.ConfigurationManager.AppSettings["modeport"].ToString()));
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
            initializ_done = true;
        }

        public void loadDemo()
        {
            while (true)
            {
                if (initializ_done)
                {
                    IPhysics_Command command = new LoadDocument(Environment.CurrentDirectory + System.Configuration.ConfigurationManager.AppSettings["modefile"].ToString());
                    remote.execute(command);
                    if (System.Configuration.ConfigurationManager.AppSettings["isDebug"].ToString() == "0")
                    {
                        remote.switchModePresentation(true);
                    }
                    loading_done = true;
                    break;
                }
            }
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
        #endregion


        #region button click

        #region 启动停止timer
        //显示隐藏
        private void bt_hideshow_Click(object sender, EventArgs e)
        {
            if (bt_hideshow.Text == "<")
            {
                this.panel1.Width = 0;
                bt_hideshow.Location = new Point(0, (panel1.Height - bt_hideshow.Height) / 2);
                bt_hideshow.Text = ">";
            }
            else
            {
                this.panel1.Width = 217;
                bt_hideshow.Location = new Point(217, (panel1.Height - bt_hideshow.Height) / 2);
                bt_hideshow.Text = "<";
            }
        }
        //主窗体 resize
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (bt_hideshow.Text == "<")
            {
                bt_hideshow.Location = new Point(217, (panel1.Height - bt_hideshow.Height) / 2);
            }
            else
            {
                bt_hideshow.Location = new Point(0, (panel1.Height - bt_hideshow.Height) / 2);
            }
        }
        //启动
        private void bt_play_Click(object sender, EventArgs e)
        {
            remote.sendReset();
            remote.sendPlay();
            Connect();
            CT.threadStartAll();
            CT2.threadStartAll();
            CST.StartThreadStorage();
            this.timerClick.Enabled = true;
        }
        //停止
        private void bt_stop_Click(object sender, EventArgs e)
        {
            remote.sendReset();
            remote.sendReset();
            Disconnect();
            CT.threadStopAll();
            CT2.threadStopAll();
            CST.StopThreadStorage();
            this.timerClick.Enabled = false;
        }
        //暂停
        private void bt_pause_Click(object sender, EventArgs e)
        {
            remote.sendPause();
            CT.threadPauseAll();
            CT2.threadPauseAll();
            CST.PauseThreadStorage();
            this.timerClick.Enabled = false;
        }
        //继续
        private void bt_goon_Click(object sender, EventArgs e)
        {
            remote.sendPlay();
            CT.threadContinueAll();
            CT2.threadContinueAll();
            CST.ContinueThreadStorage();
            this.timerClick.Enabled = true;
        }
        //timer事件
        private void timerClick_Tick(object sender, EventArgs e)
        {
            string[] arr = CT2.getLinkAndType();
            if (arr != null)
            {
                showNewWindow(arr[1], int.Parse(arr[0]));
            }
        }

        public void showNewWindow(string linkStr, int type)
        {
            this.timerClick.Enabled = false;
            Browser bb = new Browser();
            bb.url = linkStr;
            bb.ShowDialog();
            if (bb.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                bb.Close();
                this.timerClick.Enabled = true;
                CT2.threadContinueAll();
            }
        }
        #endregion

        #region 辅助方法
        private void bt_view_up_Click(object sender, EventArgs e)
        {

        }

        private void bt_view_down_Click(object sender, EventArgs e)
        {

        }

        private void bt_view_before_Click(object sender, EventArgs e)
        {

        }

        private void bt_view_after_Click(object sender, EventArgs e)
        {

        }

        private void bt_view_left_Click(object sender, EventArgs e)
        {

        }

        private void bt_view_right_Click(object sender, EventArgs e)
        {

        }

        private void bt_view_reset_Click(object sender, EventArgs e)
        {

        }

        private void bt_pos_up_Click(object sender, EventArgs e)
        {

        }

        private void bt_pos_down_Click(object sender, EventArgs e)
        {

        }

        private void bt_pos_left_Click(object sender, EventArgs e)
        {

        }

        private void bt_pos_right_Click(object sender, EventArgs e)
        {

        }

        private void bt_scene_small_Click(object sender, EventArgs e)
        {

        }

        private void bt_scene_big_Click(object sender, EventArgs e)
        {

        }

        private void bt_scene_reset_Click(object sender, EventArgs e)
        {

        }

        private void bt_search_Click(object sender, EventArgs e)
        {

        }
        //摄像头点击
        private void bt_video_1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #endregion


        #region 主窗体事件
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            remote.sendReset();
            Disconnect();
            CT.threadStopAll();
            CT2.threadStopAll();
            CST.StopThreadStorage();
            this.timerClick.Stop();
            Application.Exit();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            Initialization(this.panel2);
            Thread.Sleep(5000);
            //return;
            Thread.Sleep(2000);
            Thread t2 = new Thread(loadDemo);
            t2.Start();
            while (true)
            {
                if (loading_done)
                {
                    //t.Abort();
                    t2.Abort();
                    Thread.Sleep(10000);
                    remote.setCustomView("V_PCC");
                    Thread.Sleep(2000);
                    //初始化 货位
                    CST.InitializStorage();
                    Thread.Sleep(2000);
                    //初始化托盘
                    CST.InitializStorageShowPallet();
                    break;
                }
                Thread.Sleep(1000);
            }
        }
        #endregion

       


    }
}
