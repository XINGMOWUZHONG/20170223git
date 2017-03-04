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
    public partial class Browser : Form
    {
        public string url;
        public Browser()
        {
            InitializeComponent();
        }

        private void browser_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(url);
        }
    }
}
