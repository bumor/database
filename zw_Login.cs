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
    public partial class zw_Login : Form
    {
        SqlConnect con = new SqlConnect();
        //public DataSet ds = new DataSet();
        public zw_Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string sql = "select * from login where name='" + txtName.Text  +"'and psw='" + txtPwd.Text + "'";

            if (txtName.Text == "" || txtPwd.Text == "")
                MessageBox.Show("用户名或密码不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else
            {
                if (con.aa(sql).Read())
                {
                    pub.Sno = txtName.Text;
                    if (pub.Sno.Contains("S"))
                    {
                        zw_Main main = new zw_Main();
                        main.Show();
                    }
                    else if (pub.Sno.Contains("T"))
                    {
                        zw_T t = new zw_T();
                        t.Show();
                    }
                    else if (pub.Sno.Contains("M"))
                    {
                        zw_M m = new zw_M();
                        m.Show();
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
