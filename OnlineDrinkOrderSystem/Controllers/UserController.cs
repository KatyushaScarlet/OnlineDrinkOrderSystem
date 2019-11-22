﻿using Microsoft.AspNetCore.Mvc;
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
                bool exist = UserManage.CheckNameExist(name);
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
                    bool result = UserManage.AddUser(user);
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
            int userId = UserManage.CheckPassword(name, password);
            if (userId!=0)
            {
                //登录成功
                //设置id与权限
                HttpContext.Session.SetInt32("id", userId);
                if (UserManage.CheckAdmin(userId))
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
            ////提示信息
            //HttpContext.Session.SetString("tip", "修改成功");
            //return RedirectToAction("Account", "Home");
            //判断是否已登录
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            if (userId != 0)
            {
                User user = new User();
                user.User_ID = userId;
                user.User_Password = password;
                user.First_Name = firstName;
                user.Last_Name = lastName;
                user.Email = email;
                user.Address = address;

                bool result = UserManage.AlterUserInfo(user);
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
                //未登录则重定向至登陆页面
                //提示信息
                HttpContext.Session.SetString("tip", "请先登录");
                return RedirectToAction("Login", "Home");
            }
        }
        //public IActionResult ChangeUserInfo(int User_ID = 0,  string Given_Name = "", string Family_Name = "", string Email="",string Address="", bool Admin = false)
        //{
        //    //given name
        //    //family name
        //    //address
        //    //email
        //    //admin（管理员有权限修改）

        //    //判断是否已登录
        //    //Response result = new Response();
        //    //result.status = false;
        //    string result;

        //    string userId = HttpContext.Session.GetString("user_id");
        //    bool isadmin = Convert.ToBoolean(HttpContext.Session.GetString("admin"));

        //    if (!string.IsNullOrEmpty(userId))
        //    {
        //        //如果当前用户id有效
        //        if ((User_ID.ToString() == userId) || (isadmin == true))
        //        {
        //            //如果要修改的用户id等于当前用户id，或有管理员权限
        //            User user = UserManage.GetUserInfo(User_ID.ToString());
        //            user.Family_Name = Family_Name;
        //            user.Given_Name = Given_Name;
        //            user.Email = Email;
        //            user.Address = Address;
        //            if (isadmin)
        //            {
        //                //管理员才能修改用户的权限
        //                user.Admin = Admin;
        //            }
        //            //修改资料
        //            bool status = UserManage.AlterUserInfo(user);

        //            if (status)
        //            {
        //                result = "修改成功";
        //            }
        //            else
        //            {
        //                result = "修改失败";
        //            }
        //        }
        //        else
        //        {
        //            result = "没有权限";
        //        }
        //    }
        //    else
        //    {
        //        result = "请先登录";
        //    }

        //    return RedirectToAction("Index", "Home", new { tipMessage = result });
        //}
    }
}