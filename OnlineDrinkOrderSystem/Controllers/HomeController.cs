using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OnlineDrinkOrderSystem.Common;
using OnlineDrinkOrderSystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDrinkOrderSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string errorMessage="")
        {
            //商店首页
            //如果存在错误信息
            if (errorMessage != null)
            {
                ViewBag.errorMessage = errorMessage;
            }

            //输出首页分类菜单
            List<Category> categories = DAL.ItemManager.GetCategories();
            ViewData["categories"] = categories;

            //测试
            var temp1 = Tool.getSessionObject<int>(HttpContext.Session,"userid");
            var temp2 = Tool.getSessionObject<bool>(HttpContext.Session, "isadmin");

            return View();
        }
        public IActionResult Item()
        {
            //商品浏览
            return View();
        }

        public IActionResult Cart()
        {
            //购物车
            //判断是否已登录
            int userId = Tool.getSessionObject<int>(HttpContext.Session, "userid");
            if (userId > 0)
            {
                return View();
            }
            else
            {
                //未登录则重定向至登陆页面
                return RedirectToAction("Login", "Home", new { errorMessage = "请先登录！" });
            }
        }

        public IActionResult Login()
        {
            //用户登录
            //判断是否已登录
            int userId = Tool.getSessionObject<int>(HttpContext.Session, "userid");
            if (userId > 0)
            {
                //已登录则重定向至首页
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Trace()
        {
            //追踪清单
            //判断是否已登录
            int userId = Tool.getSessionObject<int>(HttpContext.Session, "userid");
            if (userId > 0)
            {
                return View();
            }
            else
            {
                //未登录则重定向至登陆页面
                return RedirectToAction("Login", "Home", new { errorMessage = "请先登录！" });
            }
        }

        public IActionResult Account()
        {
            //我的账户
            //判断是否已登录
            int userId = Tool.getSessionObject<int>(HttpContext.Session, "userid");
            if (userId > 0)
            {
                return View();
            }
            else
            {
                //未登录则重定向至登陆页面
                return RedirectToAction("Login", "Home", new { errorMessage = "请先登录！" });
            }
        }

        public IActionResult Order()
        {
            //历史订单
            //判断是否已登录
            int userId = Tool.getSessionObject<int>(HttpContext.Session, "userid");
            if (userId > 0)
            {
                return View();
            }
            else
            {
                //未登录则重定向至登陆页面
                return RedirectToAction("Login", "Home", new { errorMessage = "请先登录！" });
            }
        }

        public IActionResult Manage()
        {
            //后台管理
            //判断是否已登录
            int userId = Tool.getSessionObject<int>(HttpContext.Session, "userid");
            if (userId > 0)
            {
                return View();
            }
            else
            {
                //未登录则重定向至登陆页面
                return RedirectToAction("Login", "Home", new { errorMessage = "请先登录！" });
            }
        }

        public IActionResult Contact()
        {
            //联系我们
            return View();
        }

        public string Get()
        {
            var result = Tool.getSessionObject<string>(HttpContext.Session, "userid");
            return result;
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
