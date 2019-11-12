using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDrinkOrderSystem.Common
{
    public class DbHelper
    {
        private static string ConnectionString = string.Format("Data Source={0};User={1};Password={2};Database={3}",
            Models.ConnectionStrings.Server,
            Models.ConnectionStrings.User,
            Models.ConnectionStrings.Password,
            Models.ConnectionStrings.Database);//连接字符串
        public static int Action(string Command)//增，删，改
        {
            using (MySqlConnection mysql = new MySqlConnection(ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand(Command, mysql);
                mysql.Open();
                int output = cmd.ExecuteNonQuery();
                return output;
            }
        }

        public static object Read(string Command)//查（返回首行首列）
        {
            using (MySqlConnection mysql = new MySqlConnection(ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand(Command, mysql);
                mysql.Open();
                object output = cmd.ExecuteScalar();
                return output;
            }
        }

        public static DataSet ReadDataSet(string Command)//查（返回表）
        {
            using (MySqlConnection mysql = new MySqlConnection(ConnectionString))
            {
                DataSet output = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(Command, mysql);
                mysql.Open();
                da.Fill(output);
                return output;
            }
        }
    }
}
