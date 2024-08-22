using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataConnect
{
    class Class1
    {
        public SqlConnection conn;
        public SqlConnection Connect()  //连接数据库
        {
            //Data Source指定本地数据库，Initial Catalog指定数据库名称
            //Integrated Security=True 表示使用集成安全性，也就是说，用户
            //的Windows帐户身份将被用来验证数据库连接，而不是使用账号和密码。
            string str = @"Data Source=.;Initial Catalog=StuMes;Integrated Security=True"; //数据库连接字符串
            //string constr = "server=localhost;database=数据库名;uid=账号;pwd=密码;";
            conn = new SqlConnection(str);  //创建SqlConnection对象
            conn.Open();  //打开数据库连接
            return conn;
            
        }

        public SqlCommand Command(string sql) //执行一条sql命令
        {
            SqlCommand cmd = new SqlCommand(sql, Connect());
            return cmd;
        }

        public int Execute(string sql) //获取执行sql命令后，数据库表中数据条数的更新数量，用来判断命令是否执行成功
        {
            return Command(sql).ExecuteNonQuery();
        }

        public SqlDataReader Read(string sql) //读取数据库中的数据
        {
            return Command(sql).ExecuteReader();
        }

        public void Close() //关闭数据库
        {
            conn.Close();
        }
        
    }
}
