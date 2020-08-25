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
    public partial class zw_report : Form
    {
        SqlConnect con = new SqlConnect();
        public DataSet ds = new DataSet();
        public DataSet da = new DataSet();
        private string sql;
        private string time;
        public zw_report()
        {
            InitializeComponent();
            cmbCBind();
            cmbTBind();
            cmbYBind();
            cmbTEBind();
            SetBind();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //sql = "select * from RC where 学院='" + cmbC.Text + "'and 课程类型='"+cmbT.Text+"'and 开课学年='"+cmbY.Text+"'and 开课学期='"+cmbTE.Text+"'";                
                string s = txt.Text;
                if ((s.Contains("或") || s.Equals("")) && cmbC.Text == "全部" && cmbT.Text == "全部" && cmbY.Text == "全部" && cmbTE.Text == "0") {
                    sql = "select * from RC";
                }
                else
                {
                    sql = "select * from RC where ";

                    if (s.Contains("Cl"))
                    {
                        sql = sql + "and 教学班号='" + s + "'";
                    }
                    else if (s.Contains("或") || s.Equals(""))
                    {

                    }
                    else
                    {
                        sql = sql + "and 教学班 like'%" + s + "%'";
                    }
                    ///*
                    if (cmbC.Text != "全部")
                        sql = sql + "and 学院 = '" + cmbC.Text + "'";
                    if (cmbT.Text != "全部")
                        sql = sql + "and 课程类型='" + cmbT.Text + "'";
                    if (cmbY.Text != "全部")
                        sql = sql + "and 开课学年='" + cmbY.Text + "'";
                    if (cmbTE.Text != "0")
                        sql = sql + "and 开课学期='" + cmbTE.Text + "'";
                    int a = sql.IndexOf("and");
                    sql = sql.Substring(0, a - 1) + sql.Substring(a + 3, sql.Length - a - 3);
                    //*/
                }
                con.OperateData(sql);
                con.BindDataGridView(dataGView, sql);
                dataGView.Columns[0].ReadOnly = false;
                dataGView.AllowUserToAddRows = false;

            }
            catch
            {
                MessageBox.Show("不能作该操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt.Clear();
        }

        protected void SetBind()
        {
            try
            {
                sql = "select * from RC ";
                con.BindDataGridView(dataGView, sql);
                dataGView.Columns[0].ReadOnly = false;
                dataGView.AllowUserToAddRows = true;
                

            }
            catch
            {
                MessageBox.Show("不能作该操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected void cmbCBind()
        {
            try
            {
                cmbC.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbC.Items.Clear();
                ds = con.Getds("select distinct 学院  from RC");
                DataRow dt = ds.Tables[0].NewRow();
                dt["学院"] = "全部";
                ds.Tables[0].Rows.InsertAt(dt, 0);
                cmbC.DisplayMember = "学院";
                cmbC.DataSource = ds.Tables[0];
                cmbC.SelectedIndex = 0;
                
                //cmbC.Items.Insert(0, "全部");

            }
            catch (Exception)
            {
                MessageBox.Show("不能作该操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        protected void cmbTBind()
        {
            try
            {
                cmbT.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbT.Items.Clear();
                ds = con.Getds("select distinct 课程类型  from RC");
                DataRow dt = ds.Tables[0].NewRow();//增加项
                dt["课程类型"] = "全部";
                ds.Tables[0].Rows.InsertAt(dt, 0);
                cmbT.DisplayMember = "课程类型";
                cmbT.DataSource = ds.Tables[0]; 
                cmbT.SelectedIndex = 0;
                //cmbT.Items.Insert(0, "全部");
            }
            catch (Exception)
            {
                MessageBox.Show("不能作该操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        protected void cmbYBind()
        {
            try
            {
                cmbY.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbY.Items.Clear();
                ds = con.Getds("select distinct 开课学年  from RC");
                DataRow dt = ds.Tables[0].NewRow();
                dt["开课学年"] = "全部";
                ds.Tables[0].Rows.InsertAt(dt, 0);
                cmbY.DisplayMember = "开课学年";
                cmbY.DataSource = ds.Tables[0];
                cmbY.SelectedIndex = 0;
                //cmbY.Items.Insert(0, "全部");
            }
            catch (Exception)
            {
                MessageBox.Show("不能作该操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        protected void cmbTEBind()
        {
            try
            {
                cmbTE.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbTE.Items.Clear();
                ds = con.Getds("select distinct 开课学期  from RC");
                DataRow dt = ds.Tables[0].NewRow();
                dt["开课学期"] = 0;
                ds.Tables[0].Rows.InsertAt(dt, 0);
                cmbTE.DisplayMember = "开课学期";
                cmbTE.DataSource = ds.Tables[0];
                cmbTE.SelectedIndex = 0;
                //cmbTE.Items.Insert(0, new ListViewItem("全部","00"));
            }
            catch (Exception)
            {
                MessageBox.Show("不能作该操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGView.CurrentRow.Index;
            pub.Rcl = dataGView.Rows[index].Cells[1].Value.ToString();//教学班编号
            //MessageBox.Show(pub.Rcl);
            pub.Ry = dataGView.Rows[index].Cells[8].Value.ToString();//学期
            pub.Rn = dataGView.Rows[index].Cells[5].Value.ToString();//节数
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                pub.REno = pub.Sno.Substring(2, 2) + pub.Rcl.Substring(3, 2) + pub.Ry.Substring(0, 2);
            }
            catch (NullReferenceException)
            {
                // MessageBox.Show("请选择一门课程！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            sql = "select * from RR where 上课时间='" + pub.Rn + "'and 学号='"+pub.Sno+"'";//是否有时间冲突
            ds = con.Getds(sql);
            //time = ds.Tables[0].Rows[0]["序号"].ToString();
            //MessageBox.Show(ds.Tables[0].Rows[0]["序号"].ToString());
            //da = con.Getds(time);
            if (ds == null || ds.Tables[0].Rows.Count == 0)//是否查询结果为空
            {
                try
                {
                    sql = "insert report2 values('" + pub.REno + "','" + pub.Sno + "',NULL,NULL,NULL,NULL,'" + pub.Rcl + "','" + pub.Ry + "')";
                    con.OperateData(sql);
                    MessageBox.Show("选课成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //SetBind()
                }
                catch (Exception)
                {
                    MessageBox.Show("已选择该课或与现选课程有时间冲突!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("已选择该课或与现选课程有时间冲突!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            /*
            else
            {
                if(time != pub.REno)
                MessageBox.Show("课程时间冲突！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
            
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            zw_reportR r = new zw_reportR();
            r.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
