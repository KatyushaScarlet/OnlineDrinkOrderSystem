using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OnlineDrinkOrderSystem.Common;
using OnlineDrinkOrderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineDrinkOrderSystem.DAL;


namespace OnlineDrinkOrderSystem.Controllers
{
    public class UserController : Controller
    {
        //用户注册
        [HttpPost]
        public IActionResult SignUp(string name = "", string password = "", string firstName = "", string lastName = "",string email="", string address = "")
        {
            if (name != "" && password != "" && firstName != "" && email != "" && lastName != "" && address != "")
            {
                bool exist = UserManager.CheckNameExist(name);
                if (!exist)
                {
                    User user = new User();
                    user.User_Name = name;
                    user.User_Password = password;
                    user.First_Name = firstName;
                    user.Last_Name = lastName;
                    user.Email = email;
                    user.Address = address;
                    user.Admin = false;
                    bool result = UserManager.AddUser(user);
                    if (result)
                    {
                        //注册成功
                        //提示信息
                        HttpContext.Session.SetString("tip", "注册成功，请重新登录");
                        return RedirectToAction("Login", "Home");
                    }
                    else
                    {
                        //注册失败
                        HttpContext.Session.SetString("tip", "注册失败，请联系管理员");
                        return RedirectToAction("SignUp", "Home");
                    }
                }
                else
                {
                    //注册失败
                    HttpContext.Session.SetString("tip", "注册失败，用户名已被使用");
                    return RedirectToAction("SignUp", "Home");
                }
            }
            else
            {
                //注册失败
                HttpContext.Session.SetString("tip", "注册失败，请检查是否有资料未填写");
                return RedirectToAction("SignUp", "Home");
            }
        }

        //用户登录
        [HttpPost]
        public IActionResult LoginIn(string name="",string password="")
        {
            int userId = UserManager.CheckPassword(name, password);
            if (userId!=0)
            {
                //登录成功
                //设置id与权限
                HttpContext.Session.SetInt32("id", userId);
                if (UserManager.CheckAdmin(userId))
                {
                    HttpContext.Session.SetString("admin", true.ToString());
                }
                //提示信息
                HttpContext.Session.SetString("tip", "登录成功");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //登录失败
                HttpContext.Session.SetString("tip", "登录失败，请检查用户名或密码是否正确");
                return RedirectToAction("Login", "Home");
            }
        }

        //用户登出
        [HttpGet]
        public IActionResult SignOut()
        {
            //判断是否已登录
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            if (userId!=0)
            {
                HttpContext.Session.SetInt32("id", 0);
                HttpContext.Session.SetString("admin", false.ToString());
                //提示信息
                HttpContext.Session.SetString("tip", "已成功登出");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //未登录则重定向至登陆页面
                //提示信息
                HttpContext.Session.SetString("tip", "请先登录");
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        //修改用户信息
        public IActionResult AlterUserInfo(string password = "", string firstName = "", string lastName = "", string email = "", string address = "")
        {
            //判断是否已登录
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            if (userId != 0)
            {

                if (password != "" && firstName != "" && lastName != "" && email != "" &&  address != "")
                {
                    User user = new User();
                    user.User_ID = userId;
                    user.User_Password = password;
                    user.First_Name = firstName;
                    user.Last_Name = lastName;
                    user.Email = email;
                    user.Address = address;

                    bool result = UserManager.AlterUserInfo(user);
                    if (result)
                    {
                        //提示信息
                        HttpContext.Session.SetString("tip", "修改成功");
                        return RedirectToAction("Account", "Home");
                    }
                    else
                    {
                        //修改失败
                        //提示信息
                        HttpContext.Session.SetString("tip", "修改失败，请联系管理员");
                        return RedirectToAction("Account", "Home");
                    }
                }
                else
                {
                    //修改失败
                    HttpContext.Session.SetString("tip", "修改失败，请检查是否有资料未填写");
                    return RedirectToAction("Account", "Home");
                }
            }
            else
            {
                //未登录则重定向至登陆页面
                //提示信息
                HttpContext.Session.SetString("tip", "请先登录");
                return RedirectToAction("Login", "Home");
            }
        }

        //设置/取消管理员
        [HttpGet]
        public string ChangeUserPrivilege(int userId = 0, bool isAdmin = false)
        {
            Response response = new Response();
            response.status = false;
            int nowUserId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            bool nowIsadmin = Convert.ToBoolean(HttpContext.Session.GetString("admin"));

            if (nowUserId != 0 && nowIsadmin)
            {
                //修改状态
                bool result = UserManager.ChangeUserPrivilege(userId, isAdmin);
                if (result)
                {
                    response.status = true;
                    response.message = "操作成功";
                }
                else
                {
                    response.message = "操作失败";
                }
            }
            else
            {
                response.message = "没有权限";
            }
            return JsonConvert.SerializeObject(response);
        }

        //删除用户
        [HttpGet]
        public string DeleteUser(int userId)
        {
            Response response = new Response();
            response.status = false;
            int nowUserId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            bool nowIsadmin = Convert.ToBoolean(HttpContext.Session.GetString("admin"));

            if (nowUserId != 0 && nowIsadmin)
            {
                //删除用户
                UserManager.DeleteUser(userId);
                response.status = true;
                response.message = "操作成功";
            }
            else
            {
                response.message = "没有权限";
            }
            return JsonConvert.SerializeObject(response);
        }

        //[HttpPost]
        ////修改用户信息/添加用户信息
        //public IActionResult UserInfoManage()
    }
}