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
        bool initializ_done;
        #region
        //初始化
        public void Initialization(object obj)
        {
            System.Windows.Forms.Panel pp = (System.Windows.Forms.Panel)obj;
            remote = new RemoteInterface(true, true);

            iPhysicsDoc = new ExternalAppDock();
            pp.Controls.Add(iPhysicsDoc);
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
            initializ_done = true;
        }

        public void loadDemo()
        {
            while(true)
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

       
        public PCC()
        {
            InitializeComponent();
            CT = new ControlThread();
            CT2 = new ControlThreadClickandLight();
            CST = new ControlStorageThread();
        }
        private void PCC_Shown(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            //Thread t = new Thread(Initialization);
            //t.Start(this.panel1);   
            Initialization(this.panel1);
            Thread.Sleep(1000);
            Thread t2 = new Thread(loadDemo);
            t2.Start(); 
            while(true)
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
            }
        }
        #endregion

        #region
        public ControlThread CT;
        public ControlThreadClickandLight CT2;
        public ControlStorageThread CST;
        //按钮点击
        //启动运行 设置基础数据
        private void button1_Click(object sender, EventArgs e)
        {
            remote.sendReset();
            remote.sendPlay();
            Connect();
            CT.threadStartAll();
            CT2.threadStartAll();
            CST.StartThreadStorage();
            this.timerClick.Enabled = true;
        }

        //停止运行
        private void button2_Click(object sender, EventArgs e)
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
        private void button3_Click(object sender, EventArgs e)
        {
            remote.sendPause();
            CT.threadPauseAll();
            CT2.threadPauseAll();
            CST.PauseThreadStorage();
            this.timerClick.Enabled = false;
        }

        //继续
        private void button4_Click(object sender, EventArgs e)
        {
            remote.sendPlay(); 
            CT.threadContinueAll();
            CT2.threadContinueAll();
            CST.ContinueThreadStorage();
            this.timerClick.Enabled = true;
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

        #endregion

        #region
        //timer 监控点击事件 然后打开窗体
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

        #region
        //货位操作
        


        #endregion


        /// <summary>
        /// test-------------------------------------------------
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            //Storage_PCC.FullAll();
            //Storage_NEW.FullAll();
            //Storage_NEW2.FullAll();

            //Storage_PCC.Change(0, 0, 0, 2, 1);
            //Storage_PCC.Change(1, 0, 0, 2, 1);
            //Storage_NEW.Change(0, 0, 0, 2, 1);
            //Storage_NEW.Change(1, 0, 0, 2, 1);
            //Storage_NEW2.Change(0, 0, 0, 2, 1);
            //Storage_NEW2.Change(1, 0, 0, 2, 1);
            //Storage_NEW2.Change(1, 1, 0, 2, 1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
        //    Storage_NEW2.Change(int.Parse(this.textBox1.Text.Trim().Split(',')[0].ToString()), int.Parse(this.textBox1.Text.Trim().Split(',')[1].ToString()), int.Parse(this.textBox1.Text.Trim().Split(',')[2].ToString()), int.Parse(this.textBox1.Text.Trim().Split(',')[3].ToString()), int.Parse(this.textBox1.Text.Trim().Split(',')[4].ToString()));
        }

        private void PCC_FormClosing(object sender, FormClosingEventArgs e)
        {
            remote.sendReset();
            Disconnect();
            CT.threadStopAll();
            CT2.threadStopAll();
            CST.StopThreadStorage();
            this.timerClick.Stop();
        }

      
       

      
    }
}
