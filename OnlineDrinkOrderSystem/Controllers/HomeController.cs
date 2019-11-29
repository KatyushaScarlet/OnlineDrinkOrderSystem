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
        public IActionResult Index()
        {
            //商店首页
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
            //判断用户权限
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            if (userId != 0)
            {
                //获取购物车信息
                List<Cart> carts = ItemManager.GetUserCart(userId);
                ViewData["carts"] = carts;
                return View();
            }
            else
            {
                //未登录则重定向至登陆页面

                HttpContext.Session.SetString("tip", "请先登录");
                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult Login()
        {
            //用户登录
            //判断用户权限
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            if (userId != 0)
            {
                //已登录则重定向至首页

                HttpContext.Session.SetString("tip", "您已登录");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult SignUp()
        {
            //用户登录
            //判断用户权限
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            if (userId != 0)
            {
                //已登录则重定向至首页

                HttpContext.Session.SetString("tip", "您已登录");
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
            //判断用户权限
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            if (userId != 0)
            {
                return View();
            }
            else
            {
                //未登录则重定向至登陆页面

                HttpContext.Session.SetString("tip", "请先登录");
                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult Account(int id = 0)
        {
            //我的账户

            //是否已登录
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            //是否有管理权限
            bool isadmin = Convert.ToBoolean(HttpContext.Session.GetString("admin"));
            //若要修改的用户id为0则默认为当前用户id
            int nowUserId = (id == 0) ? userId : id;

            if (userId != 0)
            {
                //要修改的用户信息不是当前用户，但没有管理员权限
                if ((nowUserId != userId) && (isadmin = false))
                {
                    //重定向至首页

                    HttpContext.Session.SetString("tip", "没有权限");
                    return RedirectToAction("Index", "Home");
                }
                User user = UserManager.GetUserInfo(nowUserId);
                ViewData["user"] = user;

                return View();
            }
            else
            {
                //未登录则重定向至登陆页面

                HttpContext.Session.SetString("tip", "请先登录");
                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult Order()
        {
            //历史订单
            //判断用户权限
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            if (userId != 0)
            {
                //获取订单列表
                List<Order_Detail> order_Details = OrderManager.GetUserOrders(userId);
                //回传viewdata
                ViewData["details"] = order_Details;
                return View();
            }
            else
            {
                //未登录则重定向至登陆页面

                HttpContext.Session.SetString("tip", "请先登录");
                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult OrderView(int orderId = 0)
        {
            //获取订单详情
            //是否已登录
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            //是否有管理权限
            bool isadmin = Convert.ToBoolean(HttpContext.Session.GetString("admin"));

            if (userId != 0)
            {
                bool checkOrderExist = OrderManager.CheckOrderIdExist(orderId);
                if (checkOrderExist)
                {
                    //如果订单存在
                    bool checkUserOwnsOrder = OrderManager.CheckUserOwnsOrder(userId, orderId);
                    if (checkUserOwnsOrder || isadmin)
                    {
                        //用户拥有订单，或当前用户有管理员权限
                        //获取订单内详情列表
                        Order_Detail detail = OrderManager.GetOrderDetail(orderId);
                        List<Order_List> list = OrderManager.GetOrderList(orderId);
                        //回传viewdata
                        ViewData["list"] = list;
                        ViewData["detail"] = detail;
                        return View();
                    }
                    else
                    {
                        //无访问权限

                        HttpContext.Session.SetString("tip", "无访问权限");
                        return RedirectToAction("Order", "Home");
                    }
                }
                else
                {
                    //如果订单不存在

                    HttpContext.Session.SetString("tip", "订单不存在");
                    return RedirectToAction("Order", "Home");
                }
            }
            else
            {
                //未登录则重定向至登陆页面

                HttpContext.Session.SetString("tip", "请先登录");
                return RedirectToAction("Login", "Home");
            }
        }
        //订单管理
        public IActionResult OrderManage()
        {
            //判断用户权限
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            bool isadmin = Convert.ToBoolean(HttpContext.Session.GetString("admin"));
            if (userId != 0 && isadmin)
            {
                //获取所有订单列表
                List<Order_Detail> order_Details = OrderManager.GetAllOrders();
                //回传viewdata
                ViewData["details"] = order_Details;
                return View();
            }
            else
            {
                //重定向至首页
                HttpContext.Session.SetString("tip", "无访问权限");
                return RedirectToAction("Index", "Home");
            }
        }
        //商品管理
        public IActionResult ItemManage(int page = 1, int pageSize = 20, string keyWord = "", int category_ID = 0, ItemOrder itemOrder = ItemOrder.none)
        {
            //判断用户权限
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            bool isadmin = Convert.ToBoolean(HttpContext.Session.GetString("admin"));
            if (userId != 0 && isadmin)
            {
                //获取所有商品列表
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
            else
            {
                //重定向至首页
                HttpContext.Session.SetString("tip", "无访问权限");
                return RedirectToAction("Index", "Home");
            }
        }
        //商品信息修改/新增商品（id为0则为新增页面）
        public IActionResult ItemInfoManage(int itemId= 0)
        {
            //判断用户权限
            int nowUserId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            bool nowIsadmin = Convert.ToBoolean(HttpContext.Session.GetString("admin"));
            if (nowUserId != 0 && nowIsadmin)
            {
                if (itemId!=0)
                {
                    ViewData["iteminfo"] = ItemManager.GetItem(itemId);
                }

                return View();
            }
            else
            {
                //重定向至首页
                HttpContext.Session.SetString("tip", "无访问权限");
                return RedirectToAction("Index", "Home");
            }
        }

        //用户管理
        public IActionResult UserManage()
        {
            //判断用户权限
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            bool isadmin = Convert.ToBoolean(HttpContext.Session.GetString("admin"));
            if (userId != 0&& isadmin)
            {
                //获取所有用户
                List<User> users = UserManager.GetUsers();
                //回传viewdata
                ViewData["users"] = users;
                return View();

            }
            else
            {
                //重定向至首页
                HttpContext.Session.SetString("tip", "无访问权限");
                return RedirectToAction("Index", "Home");
            }
        }

        //用户信息修改/新增用户（id为0则为新增页面）
        public IActionResult UserInfoManage(int userId=0)
        {
            //判断用户权限
            int nowUserId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            bool nowIsadmin = Convert.ToBoolean(HttpContext.Session.GetString("admin"));
            if (nowUserId != 0&& nowIsadmin)
            {
                if (userId!=0)
                {
                    ViewData["userinfo"] = UserManager.GetUserInfo(userId);
                }

                return View();
            }
            else
            {
                //重定向至首页
                HttpContext.Session.SetString("tip", "无访问权限");
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Contact()
        {
            //联系我们
            return View();
        }
    }
}
