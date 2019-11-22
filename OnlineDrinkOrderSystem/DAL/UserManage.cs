using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using OnlineDrinkOrderSystem.Models;
using OnlineDrinkOrderSystem.Common;

namespace OnlineDrinkOrderSystem.DAL
{
    public class UserManage
    {
        //查找用户名是否已存在
        public static bool CheckNameExist(string name)
        {
            return (int)DbHelper.Read(string.Format("select count(*) from User where User_Name='{0}'", name)) != 0;
        }

        //判断账户密码是否匹配，成功则返回id，失败返回0
        public static int CheckPassword(string name,string password)
        {
            return Convert.ToInt32(DbHelper.Read(string.Format("select User_ID from User where User_Name='{0}' and User_Password='{1}'", name, password)));
        }

        //根据id获取用户信息
        public static User GetUserInfo(int id)
        {
            User user = new User();
            DataSet dataSet = DbHelper.ReadDataSet(string.Format("select * from User where User_ID='{0}'", id));
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                DataRow dataRow = dataSet.Tables[0].Rows[0];
                user = Tool.DataRow2Entity<User>(dataRow);
            }
            return user;
        }

        //添加用户
        public static bool AddUser(User user)
        {
            return DbHelper.Action(string.Format("insert into User values(null,'{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                user.User_Name,
                user.User_Password,
                user.First_Name,
                user.Last_Name,
                user.Email,
                user.Address,
                (user.Admin == true ? 1 : 0)//转换为tinyint
                )) == 1;
        }

        //修改用户信息
        public static bool AlterUserInfo(User user)
        {
            return DbHelper.Action(string.Format("update User set " +
                "User_Name='{0}',User_Password='{1}',First_Name='{2}',Last_Name='{3}',Email='{4}',Address='{5}',Admin='{6}' where User_ID='{7}'",
                user.User_Name,
                user.User_Password,
                user.First_Name,
                user.Last_Name,
                user.Email,
                user.Address,
                (user.Admin == true ? 1 : 0),//转换为tinyint
                user.User_ID
                )) == 1;
        }

        //删除用户
        //同时删除：用户订单、购物车、追踪列表
        //FK id更改为0：评论、订单
    }
}
