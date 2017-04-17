using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PccNew
{
    public partial class BrowserVideo : Form
    {
        public BrowserVideo()
        {
            InitializeComponent();
        }
        public string videoStr = "";
        private void BrowserVideo_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(videoStr);
        }
    }
}
