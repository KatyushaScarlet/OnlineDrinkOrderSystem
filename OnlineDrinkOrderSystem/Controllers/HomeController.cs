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

            List<Category> categories = DAL.ItemManager.GetCategories();
            ViewData["categories"] = categories;
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
            return View();
        }

        public IActionResult Login()
        {
            //用户登录
            return View();
        }

        public IActionResult Trace()
        {
            //追踪清单
            return View();
        }

        public IActionResult Account()
        {
            //我的账户
            //return View();
            return RedirectToAction("Index", "Home", new { errorMessage = "请先登录！" });
        }

        public IActionResult Order()
        {
            //历史订单
            return View();
        }

        public IActionResult Manage()
        {
            //后台管理
            return View();
        }

        public IActionResult Contact()
        {
            //联系我们
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
