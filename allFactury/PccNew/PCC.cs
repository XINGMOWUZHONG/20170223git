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

        public ControlThread CT;
        public PCC()
        {
            InitializeComponent();
            CT = new ControlThread();
        }
        private void PCC_Shown(object sender, EventArgs e)
        {
            Initialization();
            Thread.Sleep(2000);
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
            CT.threadStartAll();
        }

        //停止运行
        private void button2_Click(object sender, EventArgs e)
        {
            remote.sendReset();
            remote.sendReset();
            Disconnect();
            CT.threadStopAll();
        }

        //暂停
        private void button3_Click(object sender, EventArgs e)
        {
            remote.sendPause();
            CT.threadPauseAll();
        }

        //继续
        private void button4_Click(object sender, EventArgs e)
        {
            remote.sendPlay(); 
            CT.threadContinueAll();
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

      





        
        #region
        //
        //storage 货位的初始化和点击
        //
        public General Storage_PCC = null;
        public General Storage_NEW = null;
        public General Storage_NEW2 = null;

        //配餐车 货位的点击 触发事件
        private static void PCC_placeSelected(StorageArea.Model.Place selectedPlace)
        {
            var placeData = selectedPlace.GetData();
        }
        private static void NEW_placeSelected(StorageArea.Model.Place selectedPlace)
        {
            var placeData = selectedPlace.GetData();
        }

        private static void NEW2_placeSelected(StorageArea.Model.Place selectedPlace)
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
            //Storage_PCC.FullAll();

            //初始化 新库 托盘
            Storage_NEW = new General();
            Storage_NEW.Initialize("StorageArea_new");
            Storage_NEW.connection.PlaceSelected += NEW_placeSelected;
            //Storage_NEW.FullAll();

            Storage_NEW2 = new General();
            Storage_NEW2.Initialize("StorageArea_new_double");
            Storage_NEW2.connection.PlaceSelected += NEW2_placeSelected;
            //Storage_NEW2.FullAll();
        }

        //第一次默认加载数据库的货位信息
        private Thread ThreadStorageShowPallet;
        public void InitializStorageShowPallet()
        {
            List<General> lg = new List<General>();
            if (Storage_PCC != null)
            {
                lg.Add(Storage_PCC);
            }
            if (Storage_NEW != null)
            {
                lg.Add(Storage_NEW);
            }
            if (Storage_NEW2 != null)
            {
                lg.Add(Storage_NEW2);
            }
            ThreadStorageShowPallet = new Thread(new ParameterizedThreadStart(Storagecontrol.InitializeStoragePallet));
            ThreadStorageShowPallet.Start(lg);

        }
        #endregion

        //货位线程操作
        ControlStorage Storagecontrol = new ControlStorage();

        #region
        private Thread ThreaStoragePcc;
        private Thread ThreaStorageNew;
        private Thread ThreaStorageNewDouble;
        private void StartThreadStorage()
        {
            ThreaStoragePcc = new Thread(new ParameterizedThreadStart(Storagecontrol.StorageThreadFunc));
            ThreaStorageNew = new Thread(new ParameterizedThreadStart(Storagecontrol.StorageThreadFunc));
            ThreaStorageNewDouble = new Thread(new ParameterizedThreadStart(Storagecontrol.StorageThreadFunc));
            ThreaStoragePcc.Start(Storage_PCC);
            ThreaStorageNew.Start(Storage_NEW);
            ThreaStorageNewDouble.Start(Storage_NEW2);
        }
        #endregion

        
        #region
        //screen and light and machine and pallet
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
            Storage_NEW2.FullAll();

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
            Storage_NEW2.Change(int.Parse(this.textBox1.Text.Trim().Split(',')[0].ToString()), int.Parse(this.textBox1.Text.Trim().Split(',')[1].ToString()), int.Parse(this.textBox1.Text.Trim().Split(',')[2].ToString()), int.Parse(this.textBox1.Text.Trim().Split(',')[3].ToString()), int.Parse(this.textBox1.Text.Trim().Split(',')[4].ToString()));
        }
    }
}
