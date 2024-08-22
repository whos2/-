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
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string age = txtAge.Text;
            string sex = comSex.Text;
            string num = txtNum.Text;

            Class1 c1 = new Class1();
            c1.Connect();

            string sql = "select * from Table_Stu";

            SqlDataReader reader = c1.Read(sql);
            reader.Read();
            string tmp = reader[3].ToString();

            if (name == "" || age == "" || sex == "" || num == "")
            {
                MessageBox.Show("请输入完整信息");
            }
            else
            {
                if(tmp==num)
                {
                    MessageBox.Show("您输入的学号已存在，请重新输入");
                    return;
                }
                else
                {
                    sql = $"insert into Table_Stu values('{name}','{age}','{sex}','{num}')";
                    c1.Execute(sql);
                    MessageBox.Show("添加信息成功");
                }
            }
            c1.Close();
        }
    }
}
