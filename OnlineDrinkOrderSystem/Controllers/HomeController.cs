using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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
using OnlineDrinkOrderSystem.DAL;

namespace OnlineDrinkOrderSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string errorMessage = "")
        {
            //商店首页
            //如果存在错误信息
            if (errorMessage != null)
            {
                ViewBag.errorMessage = errorMessage;
            }

            //获取商品类别
            List<Category> categories = ItemManager.GetCategoryList();
            ViewData["categories"] = categories;
            //获取首页展示（最新上架）
            int totalPages = 0;
            //获取最新的X个商品
            List<Item> items = ItemManager.GetItemList(out totalPages, 0, 10, "", 0, ItemOrder.lastest);
            ViewData["items"] = items;

            return View();
        }
        public IActionResult Item(int page = 1, int pageSize = 16, string keyWord = "", int category_ID = 0, ItemOrder itemOrder = ItemOrder.none)
        {
            //商品浏览
            //页数必须大于0
            page = (page < 1) ? 1 : page;
            //获取商品类别
            List<Category> categories = ItemManager.GetCategoryList();
            ViewData["categories"] = categories;
            //获取商品
            int totalPages = 0;
            List<Item> items = ItemManager.GetItemList(out totalPages, page - 1, pageSize, keyWord, category_ID, itemOrder);
            ViewData["items"] = items;
            ViewData["pages"] = totalPages;
            //url参数
            ViewData["page"] = page;
            ViewData["pageSize"] = pageSize;
            ViewData["keyWord"] = keyWord;
            ViewData["category_ID"] = category_ID;
            ViewData["itemOrder"] = itemOrder;

            return View();
        }

        public IActionResult Cart()
        {
            //购物车
            //判断是否已登录
            string userId = HttpContext.Session.GetString("user_id");
            if (!string.IsNullOrEmpty(userId))
            {
                return View();
            }
            else
            {
                //未登录则重定向至登陆页面
                return RedirectToAction("Login", "Home", new { errorMessage = "请先登录" });
            }
        }

        public IActionResult Login()
        {
            //用户登录
            //判断是否已登录
            string userId = HttpContext.Session.GetString("user_id");
            if (!string.IsNullOrEmpty(userId))
            {
                //已登录则重定向至首页
                return RedirectToAction("Index", "Home", new { errorMessage = "您已登录" });
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
            string userId = HttpContext.Session.GetString("user_id");
            if (!string.IsNullOrEmpty(userId))
            {
                return View();
            }
            else
            {
                //未登录则重定向至登陆页面
                return RedirectToAction("Login", "Home", new { errorMessage = "请先登录" });
            }
        }

        public IActionResult Account()
        {
            //我的账户
            //判断是否已登录
            string userId = HttpContext.Session.GetString("user_id");
            if (!string.IsNullOrEmpty(userId))
            {
                User user = UserManage.GetUserInfo(userId);
                ViewData["user"] = user;

                return View();
            }
            else
            {
                //未登录则重定向至登陆页面
                return RedirectToAction("Login", "Home", new { errorMessage = "请先登录" });
            }
        }

        public IActionResult Order()
        {
            //历史订单
            //判断是否已登录
            string userId = HttpContext.Session.GetString("user_id");
            if (!string.IsNullOrEmpty(userId))
            {
                return View();
            }
            else
            {
                //未登录则重定向至登陆页面
                return RedirectToAction("Login", "Home", new { errorMessage = "请先登录" });
            }
        }

        public IActionResult Manage()
        {
            //后台管理
            //判断是否已登录
            string userId = HttpContext.Session.GetString("user_id");
            bool isadmin = Convert.ToBoolean(HttpContext.Session.GetString("is_admin"));
            if (!string.IsNullOrEmpty(userId))
            {
                //判断是否具有管理员权限
                if (isadmin == true)
                {
                    return View();
                }
                else
                {
                    //重定向至首页
                    return RedirectToAction("Index", "Home", new { errorMessage = "无访问权限" });
                }
            }
            else
            {
                //未登录则重定向至登陆页面
                return RedirectToAction("Index", "Home", new { errorMessage = "无访问权限" });
            }
        }

        public IActionResult Contact()
        {
            //联系我们
            return View();
        }
    }
}
