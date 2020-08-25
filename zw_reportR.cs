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
    public partial class zw_reportR : Form
    {
        SqlConnect con = new SqlConnect();
        public DataSet ds = new DataSet();
        private string sql;
        public zw_reportR()
        {
            InitializeComponent();
            SetBind();
        }

        protected void SetBind()
        {
            try
            {
                sql = "select * from RR where 学号='"+pub.Sno+"'";
                con.BindDataGridView(dataGView, sql);
                dataGView.Columns[0].ReadOnly = false;
                dataGView.AllowUserToAddRows = true;

            }
            catch
            {
                MessageBox.Show("不能作该操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql = "delete from report2 where REno='" + pub.REno + "'";
            con.OperateData(sql);
            SetBind();
            MessageBox.Show("退选成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //con.BindDataGridView(dataGView, sql);

        }

        private void dataGView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGView.CurrentRow.Index;
            pub.REno = dataGView.Rows[index].Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
