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
        //用户登出
        [HttpGet]
        public IActionResult SignOut()
        {
            //清空Session
            HttpContext.Session.SetString("user_id", "");
            HttpContext.Session.SetString("is_admin", false.ToString());
            //跳转回首页
            return RedirectToAction("Index", "Home", new { errorMessage = "您已成功登出" });

        }

        //用户登录
        [HttpPost]
        public string VerifyToken(string token)
        {
            ResultResponse result = new ResultResponse();
            result.status = false;

            if (!string.IsNullOrEmpty(token))
            {
                //验证token
                if (GoogleOauth.GoogleTokenVerify(token))
                {
                    //从Google获取用户信息
                    var googleJwt = Tool.GoogleToken2Jwt(token);
                    var userInfo = Tool.GoogleJwt2User(googleJwt);
                    var userId = UserManage.GetUserId(userInfo.Google_ID);
                    if (string.IsNullOrEmpty(userId))
                    {
                        //用户不存在，根据google信息创建新用户
                        //默认非管理员
                        userInfo.Admin = false;
                        var status = UserManage.AddUser(userInfo);
                        if (status)
                        {
                            //创建成功
                            //重新读取创建的用户id
                            var newId = UserManage.GetUserId(userInfo.Google_ID);
                            //设置id到session
                            HttpContext.Session.SetString("user_id", newId);
                            HttpContext.Session.SetString("is_admin", false.ToString());

                            result.status = true;
                            result.message = "新用户 " + userInfo.User_Name + "，欢迎你！";
                        }
                        else
                        {
                            //创建失败
                            result.message = "创建用户失败";
                        }
                    }
                    else
                    {
                        //用户已存在,登录成功
                        //重新获取信息（权限）
                        userInfo = UserManage.GetUserInfo(userId);
                        //设置id到session
                        HttpContext.Session.SetString("user_id", userId);
                        HttpContext.Session.SetString("is_admin", userInfo.Admin.ToString());

                        result.status = true;
                        result.message = userInfo.User_Name + "，欢迎回来";
                    }

                }
                else
                {
                    //token验证失败
                    result.message = "登录失败";
                }
            }
            else
            {
                //token为空
                result.message = "登录失败";
            }
            return JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        //修改用户信息
        public string ChangeUserInfo(int User_ID = 0,  string Given_Name = "", string Family_Name = "", string Email="",string Address="", bool Admin = false)
        {
            //given name
            //family name
            //address
            //email
            //admin（管理员有权限修改）

            //判断是否已登录
            ResultResponse result = new ResultResponse();
            result.status = false;

            string userId = HttpContext.Session.GetString("user_id");
            bool isadmin = Convert.ToBoolean(HttpContext.Session.GetString("is_admin"));
            if (!string.IsNullOrEmpty(userId))
            {
                if ((User_ID.ToString() == userId) || (isadmin == true))
                {
                    User user = UserManage.GetUserInfo(User_ID.ToString());
                    user.Family_Name = Family_Name;
                    user.Given_Name = Given_Name;
                    user.Email = Email;
                    user.Address = Address;
                    if (isadmin)
                    {
                        //管理员才能修改用户的权限
                        user.Admin = Admin;
                    }
                    //修改资料
                    bool status = UserManage.AlterUserInfo(user);

                    if (status)
                    {
                        result.message = "修改成功";
                    }
                    else
                    {
                        result.message = "修改失败";
                    }
                }
                else
                {
                    result.message = "没有权限";
                }
            }
            else
            {
                result.message = "请先登录";
            }

            return JsonConvert.SerializeObject(result);
        }
    }
}