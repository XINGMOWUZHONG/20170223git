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


namespace PccNew
{
    public partial class LoadModel : Form
    {
        RemoteInterface remote;
        int handle = -1;
        ExternalAppDock iPhysicsDoc; 

        public LoadModel()
        {
            InitializeComponent();
        }

        public void Initialization(object obj)
        {
            System.Windows.Forms.Panel pp = (System.Windows.Forms.Panel)obj;
            remote = new RemoteInterface(true, true);

            iPhysicsDoc = new ExternalAppDock();
            pp.Controls.Add(iPhysicsDoc);
            iPhysicsDoc.Dock = DockStyle.Fill;
            if (!remote.IsStarted)
                remote.StartIPhysics(6001);
            int timeout = 30000;
            int sleepTime = 500;
            while (!remote.IsConnected && timeout > 0)
            {
                System.Threading.Thread.Sleep(sleepTime);
                timeout -= sleepTime;

                if (!remote.IsConnected)
                    remote.Connect("localhost", 6001);
            }

            iPhysicsDoc.DockExternalApp(remote.ExeProcess, iPhysicsDoc.Parent);
            //if (!(timeout > 0))
            //    throw new Exception("Error, cannot connect to industrialPhysics");
            //Default File Load
            //RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            //String Path = key.GetValue(
            //    "Software\\machineering\\industrialPhysics\\InstallDir(x64)"
            //    , "c:\\Program Files\\machineering\\industrialPhysics(x64)").ToString(); 
        }

        private void LoadModel_Shown(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            Initialization(this.panel1);
            Thread.Sleep(5000);
        }
    }
}
