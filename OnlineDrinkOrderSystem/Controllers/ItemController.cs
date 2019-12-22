using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineDrinkOrderSystem.DAL;
using OnlineDrinkOrderSystem.Models;
using OnlineDrinkOrderSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDrinkOrderSystem.Controllers
{
    public class ItemController : Controller
    {
        //获取单个商品信息
        [HttpGet]
        public string GetItem(int itemId = 0)
        {
            Item item = ItemManager.GetItem(itemId);
            if (item != null)
            {
                item.Cost = 0;//隐藏进价信息
            }

            return JsonConvert.SerializeObject(item);
        }

        //修改物品信息
        [HttpPost]
        public string AlterItemInfo(int itemId = 0, string itemName = "", string image = "", string description = "", double price = 0, int categoryId = 0, 
            int clickCount = 0, int stock = 0, DateTime dateAdd=default, double cost = 0, int sold = 0, int discount = 0)
        {
            Response response = new Response();
            response.status = false;
            //判断用户权限
            int nowUserId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            bool nowIsadmin = Convert.ToBoolean(HttpContext.Session.GetString("admin"));

            if (nowUserId != 0 && nowIsadmin)
            {
                if (itemId != 0 && !Tool.IsNullOrEmpty(itemName, image, description))
                {
                    Item item = new Item();
                    item.Item_ID = itemId;
                    item.Item_Name = itemName;
                    item.Image_Url = image;
                    item.Description = description;
                    item.Item_Price = price;
                    item.Category_ID = categoryId;
                    item.Click_Counts = clickCount;
                    item.Stock = stock;
                    item.Date_added = dateAdd;
                    item.Cost = cost;
                    item.Sold = sold;
                    item.Discount = discount;

                    bool result = ItemManager.AlterItemInfo(item);
                    if (result)
                    {
                        response.status = true;
                        response.message = "修改成功";
                    }
                    else
                    {
                        response.message = "修改失败，请联系管理员";
                    }
                }
                else
                {
                    response.message = "修改失败，请检查资料是否填写完整";
                }
            }
            else
            {
                response.message = "没有权限";
            }
            return JsonConvert.SerializeObject(response);
        }

        //添加商品
        [HttpPost]
        public string AddItem(string itemName = "", string image = "", string description = "", double price = 0, int categoryId = 0,
            int clickCount = 0, int stock = 0, DateTime dateAdd = default, double cost = 0, int sold = 0, int discount = 0)
        {
            Response response = new Response();
            response.status = false;
            //判断用户权限
            int nowUserId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            bool nowIsadmin = Convert.ToBoolean(HttpContext.Session.GetString("admin"));

            if (nowUserId != 0 && nowIsadmin)
            {
                if (!Tool.IsNullOrEmpty(itemName, image, description))
                {
                    Item item = new Item();
                    item.Item_Name = itemName;
                    item.Image_Url = image;
                    item.Description = description;
                    item.Item_Price = price;
                    item.Category_ID = categoryId;
                    item.Click_Counts = clickCount;
                    item.Stock = stock;
                    item.Date_added = dateAdd;
                    item.Cost = cost;
                    item.Sold = sold;
                    item.Discount = discount;

                    bool result = ItemManager.AddItem(item);
                    if (result)
                    {
                        response.status = true;
                        response.message = "添加成功";
                    }
                    else
                    {
                        response.message = "添加失败，请联系管理员";
                    }
                }
                else
                {
                    response.message = "添加失败，请检查资料是否填写完整";
                }
            }
            else
            {
                response.message = "没有权限";
            }
            return JsonConvert.SerializeObject(response);
        }

        //删除商品
        [HttpGet]
        public string DeleteItem(int itemId = 0)
        {
            Response response = new Response();
            response.status = false;
            int nowUserId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            bool nowIsadmin = Convert.ToBoolean(HttpContext.Session.GetString("admin"));

            if (nowUserId != 0 && nowIsadmin)
            {
                //删除商品
                ItemManager.DeleteItem(itemId);
                response.status = true;
                response.message = "操作成功";
            }
            else
            {
                response.message = "没有权限";
            }

            return JsonConvert.SerializeObject(response);
        }

        //添加物品进购物车
        [HttpGet]
        public string AddItemToCart(int itemId, int count)
        {
            Response response = new Response();
            response.status = false;
            //判断用户权限
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            if (userId != 0)
            {
                ItemManager.AddItemToCart(userId, itemId, count);
                response.message = "添加成功";
                response.status = true;
            }
            else
            {
                response.message = "请先登录";
            }
            return JsonConvert.SerializeObject(response);
        }

        //更新购物车
        [HttpPost]
        public string UpdateCart(List<CartPost> carts)
        {
            Response response = new Response();
            response.status = false;
            //判断用户权限
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            if (userId != 0)
            {
                //更新购物车信息
                List<Cart> cartResult = new List<Cart>();
                if (carts.Count()!=0)
                {

                    foreach (var item in carts)
                    {
                        if (item.value > 0)
                        {
                            Cart cart = new Cart();
                            cart.Item_ID = item.name;
                            cart.Quantity = item.value;
                            cartResult.Add(cart);
                        }
                    }
                }
                ItemManager.UpdateCart(userId, cartResult);
                response.message = "更新成功！";
                response.status = true;
            }
            else
            {
                response.message = "更新失败，请先登录";
            }
            return JsonConvert.SerializeObject(response);
        }

    }
}