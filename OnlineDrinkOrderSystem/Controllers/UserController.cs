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
                    //获取用户信息
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
                            //Tool.setSessionObject(HttpContext.Session, "user_id", newId);
                            //Tool.setSessionObject(HttpContext.Session, "is_admin", userInfo.Admin);

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
                        //设置id到session
                        HttpContext.Session.SetString("user_id", userId);
                        HttpContext.Session.SetString("is_admin", userInfo.Admin.ToString());
                        //Tool.setSessionObject(HttpContext.Session, "user_id", userId);
                        //Tool.setSessionObject(HttpContext.Session, "is_admin", userInfo.Admin);

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
    }
}