using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineDrinkOrderSystem.DAL;
using OnlineDrinkOrderSystem.Models;
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
        public string GetItem(int id = 0)
        {
            Item item = ItemManager.GetItem(id);
            if (item != null)
            {
                item.Cost = 0;//隐藏进价信息
            }

            return JsonConvert.SerializeObject(item);
        }

        //添加物品进购物车
        [HttpGet]
        public string AddItemToCart(int id, int count)
        {
            Response response = new Response();
            response.status = false;
            //判断是否已登录
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            if (userId != 0)
            {
                ItemManager.AddItemToCart(userId, id, count);
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
            //判断是否已登录
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