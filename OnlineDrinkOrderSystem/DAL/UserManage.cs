using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using OnlineDrinkOrderSystem.Models;
using OnlineDrinkOrderSystem.Common;

namespace OnlineDrinkOrderSystem.DAL
{
    public class UserManager
    {
        //查找用户名是否已存在
        public static bool CheckNameExist(string name)
        {
            return Convert.ToInt32(DbHelper.Read(string.Format("select count(*) from User where User_Name='{0}'", name))) != 0;

        }

        //判断账户密码是否匹配，成功则返回id，失败返回0
        public static int CheckPassword(string name,string password)
        {
            return Convert.ToInt32(DbHelper.Read(string.Format("select User_ID from User where User_Name='{0}' and User_Password='{1}'", name, password)));
        }

        //判断账户是否为管理员
        public  static bool CheckAdmin(int id)
        {
            return Convert.ToInt32(DbHelper.Read(string.Format("select Admin from User where User_ID='{0}'", id))) == 1;
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

        //获取所有用户
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            DataSet dataSet = DbHelper.ReadDataSet("select * from User");
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                User user = new User();
                user = Tool.DataRow2Entity<User>(row);
                users.Add(user);

            }
            return users;
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

        //修改用户信息（不涉及管理员权限）
        public static bool AlterUserInfo(User user)
        {
            int result = 0;
            //密码不为空 则修改密码
            if (!string.IsNullOrEmpty(user.User_Password))
            {
                result = DbHelper.Action(string.Format("update User set " +
                    "First_Name='{0}',Last_Name='{1}',Email='{2}',Address='{3}',User_Password='{4}' where User_ID='{5}'",
                    user.First_Name,
                    user.Last_Name,
                    user.Email,
                    user.Address,
                    user.User_Password,
                    user.User_ID
                    ));
            }
            else
            {
                result = DbHelper.Action(string.Format("update User set " +
                    "First_Name='{0}',Last_Name='{1}',Email='{2}',Address='{3}' where User_ID='{4}'",
                    user.First_Name,
                    user.Last_Name,
                    user.Email,
                    user.Address,
                    user.User_ID
                    ));
            }

            return result == 1;
        }

        //修改用户权限
        public static bool ChangeUserPrivilege(int userId,bool isAdmin)
        {
            return DbHelper.Action(string.Format("update User set Admin={1} where User_ID='{0}'", userId, isAdmin)) == 1;
        }


        //删除用户
        //同时删除：购物车、追踪列表
        //FK id更改为0：评论、订单
        public static void DeleteUser(int userId)
        {
            /*
            -- delete from `User` where User_ID='1'
            -- delete from Cart where User_ID='1'
            -- delete from Trace_List where User_ID='1'
            -- update Review set User_ID='0' where User_ID='5'
             */
            //删除购物车
            DbHelper.Action(string.Format("delete from Cart where User_ID='{0}'", userId));
            //删除追踪列表
            DbHelper.Action(string.Format("delete from Trace_List where User_ID='{0}'", userId));
            //评论 id设置为null
            DbHelper.Action(string.Format("update Review set User_ID=null where User_ID='{0}'", userId));
            //订单 id设置为null
            DbHelper.Action(string.Format("update Order_Detail set User_ID=null where User_ID='{0}'", userId));
            //删除用户
            DbHelper.Action(string.Format("delete from User where User_ID='{0}'", userId));
        }
    }
}
