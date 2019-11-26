using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineDrinkOrderSystem.DAL;
using OnlineDrinkOrderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OnlineDrinkOrderSystem.Controllers
{
    public class OrderController : Controller
    {

        [HttpPost]
        public string CreateOrder(List<CartPost> carts,int delivery)
        {
            Response response = new Response();
            response.status = false;
            //判断是否已登录
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            if (userId != 0)
            {
                //更新购物车信息
                List<Cart> cartResult = new List<Cart>();
                if (carts.Count() != 0)
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
                //更新购物车
                ItemManager.UpdateCart(userId, cartResult);
                if (carts.Count!=0)
                {
                    //开始下单
                    User user = UserManage.GetUserInfo(userId);
                    bool result = OrderManager.NewOrder(user, delivery);
                    if (result)
                    {
                        response.message = "下单成功";
                        response.status = true;
                    }
                    else
                    {
                        //商品数量是否为空
                        response.message = "下单失败，部分商品暂无库存";
                    }
                }
                else
                {
                    response.message = "下单失败，商品为空";
                }

            }
            else
            {
                response.message = "请先登录";
            }
            return JsonConvert.SerializeObject(response);
        }

        //发货
        [HttpGet]
        public string SetOrderStatus(int orderId)
        {
            Response response = new Response();
            response.status = false;
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            bool isadmin = Convert.ToBoolean(HttpContext.Session.GetString("admin"));
            if (userId != 0 && isadmin)
            {
                //设置状态为发货
                bool result = OrderManager.SetOrderStatus(orderId, 2);
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
    }
}