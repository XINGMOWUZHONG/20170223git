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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            string name = this.Text.Trim();
            string pass = this.pass.Text.Trim();
            if(name.Length<5 || pass.Length < 5)
            {
                MessageBox.Show("账号或密码错误，请核对！");
                return;
            }
            if(!WZYB.Control.ControlInterfaceMethod .login (name,pass))
            {
                MessageBox.Show("账号或密码错误，请核对！");
                return;
            }
            MainForm mf = new MainForm();
            this.Hide();
            mf.ShowDialog();
            
        }
    }
}
