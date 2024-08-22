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


namespace DataConnect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            FormChange fc = new FormChange();
            fc.ShowDialog();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            FormFind ff = new FormFind(); //创建跳转界面对象
            ff.ShowDialog();        //显示界面  

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            Class1 c1 = new Class1(); //创建类对象
            c1.Connect(); //连接并打开数据库

            string sql = "SELECT * FROM Table_Stu"; //选择表中所有数据
            SqlCommand co = c1.Command(sql);  //执行命令
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = co;
            DataSet ds = new DataSet();
            adapt.Fill(ds, "t");    //第二个参数:表名，随便取
            dataGridView1.DataSource = ds.Tables["t"];

            c1.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAdd fa = new FormAdd();
            fa.ShowDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            FormDel fd = new FormDel();
            fd.ShowDialog();
        }
    }
}
