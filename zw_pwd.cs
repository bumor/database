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
    public partial class zw_pwd : Form
    {
        SqlConnect con = new SqlConnect();
        public DataSet ds = new DataSet();
        private string sql;
        public zw_pwd()
        {
            InitializeComponent();
            la.Text = pub.Sno;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txt1.Text==""&&txt2.Text=="")
                MessageBox.Show("情输入新密码，不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if(txt1.Text != txt2.Text)
                MessageBox.Show("两次输入不一致，重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if(txt1.Text == txt2.Text)
            {
                sql = "update login set psw='" + txt2.Text + "' where name='" + pub.Sno + "'";
                con.OperateData(sql);
                MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
