using System;
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

namespace PccNew
{
    public partial class Browser : Form
    {
        public string url;
        public RemoteInterface remote;
        public ExternalAppDock iPhysicsDoc;
        public Browser()
        {
            InitializeComponent();
        }
        public string linkStr = "";
        public string modelName = "";
        
        private void browser_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Browser_Load(object sender, EventArgs e)
        {
             
        }

        private void Browser_Shown(object sender, EventArgs e)
        {
            loadLink(linkStr);
            System.Threading.Thread.Sleep(500);
            loadModel(modelName);
            remote.setCustomView("v_pcc_car");
        }

        private void loadLink(string link)
        {
            if(link.Length > 0)
            {
                this.webBrowser2.Navigate(link);
            }
        }

        private void loadModel(string name)
        {
            if (name.Length < 1)
                return;
            //this.splitContainer1.Panel1.Controls.Add(iPhysicsDoc);
            //iPhysicsDoc.Dock = DockStyle.Fill;
            if (remote.IsStarted)
            {
                return;
            }
            int timeout = 30000;
            int sleepTime = 500;

            if (!remote.IsStarted)
                remote.StartIPhysics(6003);

            while (!remote.IsConnected && timeout > 0)
            {
                System.Threading.Thread.Sleep(sleepTime);
                timeout -= sleepTime;

                if (!remote.IsConnected)
                    remote.Connect("localhost", 6003);
            }

            iPhysicsDoc.DockExternalApp(remote.ExeProcess, iPhysicsDoc.Parent);
            System.Threading.Thread.Sleep(400);
            IPhysics_Command command = new LoadDocument(Environment.CurrentDirectory + "/pcc_car.iphz");
            remote.execute(command);
            if (System.Configuration.ConfigurationManager.AppSettings["isDebug"].ToString() == "0")
            {
                remote.switchModePresentation(true);
            }


        }
    }
}
