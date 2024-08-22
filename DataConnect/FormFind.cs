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
    public partial class FormFind : Form
    {
        public FormFind()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string num = txtNum.Text;
            if(num!="")
            {
                Class1 c1 = new Class1();
                c1.Connect();
                
                string sql = $"select * from Table_Stu where StuNum={int.Parse(num)}";
                SqlDataReader reader = c1.Read(sql);
                bool flag = reader.Read();
                if (flag==true)
                {
                    MessageBox.Show("查询成功");
                    SqlCommand co = c1.Command(sql);  //执行命令
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = co;
                    DataSet ds = new DataSet();
                    adapt.Fill(ds, "t");    //第二个参数:表名，随便取
                    dataGridView1.DataSource = ds.Tables["t"];
                }
                else
                {
                    MessageBox.Show("不存在输入的学号信息");
                    dataGridView1.DataSource = null;
                    return;
                }


                c1.Close();
            }
            else
            {
                MessageBox.Show("请输入学号");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
