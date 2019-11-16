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
        public static string CheckGoogleIdExisit(string googleId)
        {
            return Convert.ToString(DbHelper.Read(string.Format("select User_ID from User where Google_ID={0}", googleId)));
        }

        //获取用户信息
        public static User GetUserInfo(string userId)
        {
            DataSet dataSet = DbHelper.ReadDataSet(string.Format("select * from User where User_ID={0}", userId));
            DataRow dataRow = dataSet.Tables[0].Rows[0];
            User user = Tool.DataRow2Entity<User>(dataRow);
            return user;
        }

        //新增用户

        //public static bool AddUser(UserInfo)
        //{

        //}

        //获取用户信息

        //修改用户信息
    }
}
