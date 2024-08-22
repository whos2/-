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
    public partial class FormChange : Form
    {
        public FormChange()
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
            if (num != "")
            {
                Class1 c1 = new Class1();
                c1.Connect();

                string sql = $"select * from Table_Stu where StuNum={int.Parse(num)}";
                SqlDataReader reader = c1.Read(sql);
                bool flag = reader.Read();
                if (flag == true)
                {
                    //MessageBox.Show("查询成功");
                    if (name == "" || age == "" || sex == "")
                    {
                        MessageBox.Show("请将信息填写完整");
                    }
                    else
                    {
                        sql = $"delete from Table_Stu where StuNum={int.Parse(num)}";
                        c1.Execute(sql); //执行命令
                        sql = $"insert into Table_Stu values('{name}','{age}','{sex}','{num}')";
                        c1.Execute(sql);
                        MessageBox.Show("修改信息成功");
                    }
                }
                else
                {
                    MessageBox.Show("不存在输入的学号信息");
                    return;
                }
                c1.Close();
            }
            else
            {
                MessageBox.Show("请输入学号");
            }
            
            }
        }
    }

