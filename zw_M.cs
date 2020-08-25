using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database
{
    public partial class zw_M : Form
    {
        public zw_M()
        {
            InitializeComponent();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zw_pwd p = new zw_pwd();
            p.Show();
        }

        private void 切换用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            zw_Login l = new zw_Login();
            l.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
