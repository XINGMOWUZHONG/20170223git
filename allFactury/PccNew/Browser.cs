﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using IPhysics;
using Microsoft.Win32;


namespace PccNew
{
    public partial class Browser : Form
    {
         
        public RemoteInterface remote;
        public ExternalAppDock iPhysicsDoc;
        public Browser()
        {
            InitializeComponent();
        }
        public string linkStr = "";
        public string modelName = "";
        public int modelType = 0;
        int handle = -1;
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


        public void Initialization(object obj)
        {
            System.Windows.Forms.Panel pp = (System.Windows.Forms.Panel)obj;
            remote = new RemoteInterface(false, false);

            iPhysicsDoc = new ExternalAppDock();
            pp.Controls.Add(iPhysicsDoc);
            iPhysicsDoc.Dock = DockStyle.Fill;
            if (!remote.IsStarted)
                remote.StartIPhysics(decimal.Parse(System.Configuration.ConfigurationManager.AppSettings["modeport_browser"].ToString()));
            int timeout = 30000;
            int sleepTime = 500;
            while (!remote.IsConnected && timeout > 0)
            {
                System.Threading.Thread.Sleep(sleepTime);
                timeout -= sleepTime;

                if (!remote.IsConnected)
                    remote.Connect("localhost", int.Parse(System.Configuration.ConfigurationManager.AppSettings["modeport_browser"].ToString()));
            }

            iPhysicsDoc.DockExternalApp(remote.ExeProcess, iPhysicsDoc.Parent);
            if (!(timeout > 0))
                throw new Exception("Error, cannot connect to industrialPhysics");
            //Default File Load
            RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            String Path = key.GetValue(
                "Software\\machineering\\industrialPhysics\\InstallDir(x64)"
                , "c:\\Program Files\\machineering\\industrialPhysics(x64)").ToString();  
        }
        private void browser_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopProcess();
            //remote.ShutDownIPhysics();  
            this.DialogResult = DialogResult.OK;
        }

        private void Browser_Load(object sender, EventArgs e)
        { 
            
        }

        private void Browser_Shown(object sender, EventArgs e)
        {
            //某些模型不展示
            if (modelType > 0 && modelType < 6)
            {
                Initialization(this.splitContainer1.Panel1);
                System.Threading.Thread.Sleep(500);
                loadModel(modelType);
                remote.setCustomView("v_pcc_car");
            }
            else
            {
                this.splitContainer1.SplitterDistance = 1;
                this.splitContainer1.Panel1.Hide();
                //return;
            }
            loadLink(linkStr);
            
        }

        private void loadLink(string link)
        {
            if(link.Length > 0)
            {
                this.webBrowser2.Navigate(link);
            }
        }

        private void loadModel(int type)
        {
            string name = "";
            if(type >0 && type<6)
            {
                switch (type)
                { 
                    case 1:
                        name = "/pcc_car.iphz";
                        break;
                    case 2:
                        name = "/pcc_car.iphz";
                        break;
                    case 3:
                        name = "/pcc_car.iphz";
                        break;
                    case 4:
                        name = "/pcc_car.iphz";
                        break;
                    case 5:
                        name = "/pcc_car.iphz";
                        break;
                    case 6:
                        name = "/pcc_car.iphz";
                        break;
                    case 7:
                        name = "/pcc_car.iphz";
                        break;

                }
            }
            else
            {
                //int origionWidth = splitContainer1.Panel1.Width;
                //splitContainer1.SplitterDistance = splitContainer1.Width;  
                this.splitContainer1.SplitterDistance = 1;
                this.splitContainer1.Panel1.Hide();
                return;
            }
             
            if (!remote.IsStarted)
            {
                return;
            }  
            System.Threading.Thread.Sleep(400);
            IPhysics_Command command = new LoadDocument(Environment.CurrentDirectory +name);
            remote.execute(command);
            if (System.Configuration.ConfigurationManager.AppSettings["isDebug"].ToString() == "0")
            {
                remote.switchModePresentation(true);
            }


        }

        public static void StopProcess()
        {
            try
            {
                System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName("industrialPhysics");
                foreach (System.Diagnostics.Process p in ps)
                {
                    if (p.Id.ToString() != MainForm.PID)
                    {
                        p.Kill();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
