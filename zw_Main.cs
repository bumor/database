using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database
{
    public partial class zw_Main : Form
    {
        SqlConnect con = new SqlConnect();
        public DataSet ds = new DataSet();
        private string sql;
        public zw_Main()
        {
            sql = "select * from S where Sno='" + pub.Sno + "'";
            con.Tos(sql);
            InitializeComponent();
            gb.Text = pub.Sname;
            la.Text = pub.SC;
            lb.Text = pub.SG;
        }

        private void 限选课报名ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 选课ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            zw_report report = new zw_report();
            report.Show();
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

        private void 选课结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zw_reportR r = new zw_reportR();
            r.Show();
        }

        private void 个人信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zw_P p = new zw_P();
            p.Show();
        }
    }
}
