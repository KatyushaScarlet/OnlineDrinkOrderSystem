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
        //根据Google Id查找用户id（失败返回空）
        public static string GetUserId(string googleId)
        {
            return Convert.ToString(DbHelper.Read(string.Format("select User_ID from User where Google_ID='{0}'", googleId)));
        }

        //根据id获取用户信息
        public static User GetUserInfo(string userId)
        {
            DataSet dataSet = DbHelper.ReadDataSet(string.Format("select * from User where User_ID='{0}'", userId));
            DataRow dataRow = dataSet.Tables[0].Rows[0];
            User user = Tool.DataRow2Entity<User>(dataRow);
            return user;
        }

        //添加用户
        public static bool AddUser(User user)
        {
            return DbHelper.Action(string.Format("insert into User values(null,'{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                user.Google_ID,
                user.User_Name,
                user.User_Avater,
                user.Given_Name,
                user.Family_Name,
                user.Address,
                (user.Admin == true ? 1 : 0)//转换为tinyint
                )) == 1;
        }

        //获取用户信息

        //修改用户信息

        //删除用户
        //同时删除：用户订单、购物车、追踪列表
        //FK更改为null：评论、订单
    }
}
