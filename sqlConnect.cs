using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace database
{
    class SqlConnect
    {
        public SqlConnection conn = null;
        public SqlConnect()//构造函数，连接数据库
        {
            if (conn == null)
            {
                conn = new SqlConnection("Data Source=(local);database=University_CourseSystem_Mis;uid=admin;password=123456;");
                if (conn.State == ConnectionState.Closed) conn.Open();
            }
        }
        public void CloseConnect()//关闭连接函数
        {
            if (conn.State == ConnectionState.Open) conn.Close();
        }
        public SqlDataReader aa(string sql)//判断是否有该元组
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            return sdr;
        }
        public DataSet Getds(string sql)//获取DATESET类型的数据库查询结果
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            DataSet ds = new DataSet();//表集合
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);//查询
            da.Fill(ds);//填充
            conn.Close();//关闭连接
            return ds;//返回结果
        }
        public int OperateData(string sql)//修改数据库结果
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.CommandText = sql;//文本
            sqlcom.CommandType = CommandType.Text;//类型
            sqlcom.Connection = conn;//连接
            int x = sqlcom.ExecuteNonQuery();//执行
            conn.Close();//关闭
            return x;//返回一个影响行数
        }
        public void Tos(string s){//将查询结果的某个具体值绑定到公共参数上
            SqlCommand sc = conn.CreateCommand();
            sc.CommandText = s;
            SqlDataReader r = sc.ExecuteReader();
            r.Read();
            pub.Sname = Convert.ToString(r["Sname"]);
            pub.SC= Convert.ToString(r["SC"]);
            pub.SG = Convert.ToString(r["SG"]);
            pub.B= Convert.ToString(r["B"]);
            pub.S = Convert.ToString(r["S"]);
            pub.T = Convert.ToString(r["T"]);
            pub.A = Convert.ToString(r["A"]);
        }

        public DataSet BindDataGridView(DataGridView dgv, string sql)//数据视图
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgv.DataSource = ds.Tables[0];
            return ds;

        }
    }
}
