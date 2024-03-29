﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineDrinkOrderSystem.Models;
using OnlineDrinkOrderSystem.DAL;
using OnlineDrinkOrderSystem.Common;
using Newtonsoft.Json;

namespace OnlineDrinkOrderSystem.Controllers
{
    public class DebugController : Controller
    {
        public string Index()
        {
            return "debug ok";
        }

        //sql测试

        //public string check(string name)
        //{
        //    return UserManager.CheckNameExist(name).ToString();
        //}

        //public double Round(double input=0)
        //{
        //    return Tool.Rounde(input);
        //}
        ////用户权限变更测试
        //[HttpGet]
        //public bool ChangeUserPrivilege(int userId,bool isAdmin)
        //{
        //    return UserManager.ChangeUserPrivilege(userId, isAdmin);
        //}

        ////商品添加测试
        //[HttpGet]
        //public string AddTest()
        //{
        //    Item item = new Item();
        //    item.Item_Name = "测试商品";
        //    item.Image_Url = "/img/item/test.jpg";
        //    item.Description = "此处为商品描述";
        //    item.Item_Price = 9.9;
        //    item.Category_ID = 6;
        //    item.Click_Counts = 100;
        //    item.Stock = 999;
        //    item.Date_added = DateTime.Now;
        //    item.Cost = 4.9;
        //    item.Sold = 10;
        //    item.Discount = 0;
        //    return ItemManager.AddItem(item).ToString();
        //}

        ////商品批量添加测试
        //[HttpGet]
        //public string AddItems(int count=1)
        //{
        //    int success = 0;
        //    for (int i = 0; i < count; i++)
        //    {
        //        //取新的随机种子
        //        Random rdm = new Random(int.Parse(DateTime.Now.ToString("HHmmssfff")).GetHashCode());//保证不重复

        //        //创建新商品
        //        Item item = new Item();
        //        item.Item_Name = "测试商品" + rdm.Next(100000, 999999);
        //        item.Image_Url = "/img/item/test.jpg";
        //        item.Description = "此处为商品描述";
        //        item.Item_Price = (double)rdm.Next(1000, 10000) / (double)100;
        //        item.Category_ID = rdm.Next(1, 6);
        //        item.Click_Counts = rdm.Next(100, 1000);
        //        item.Stock = rdm.Next(100, 10000);
        //        item.Date_added = DateTime.Now.AddDays(0 - rdm.Next(0, 1000));
        //        item.Cost = item.Item_Price / (double)10;
        //        item.Sold = rdm.Next(100, 1000);
        //        item.Discount = 0;
        //        var result = ItemManager.AddItem(item);

        //        //成功计数
        //        if (result) success++;
        //    }

        //    return string.Format("add items {0}/{1} ok", success, count);
        //}

        //商品批量添加
        //[HttpGet]
        //public string AddItems()
        //{
        //    //冰淇淋 id=5 001-006 
        //    //冰沙 id=3 007-016 
        //    //果汁 id=2 017-021 
        //    //咖啡 id=4 022-029
        //    //奶茶 id=1 030-034

        //    int success = 0;
        //    for (int i = 30; i <= 34; i++)
        //    {
        //        //取新的随机种子
        //        Random rdm = new Random(int.Parse(DateTime.Now.ToString("HHmmssfff")).GetHashCode());//保证不重复

        //        //创建新商品
        //        Item item = new Item();
        //        item.Item_Name = "奶茶" + rdm.Next(100000, 999999);
        //        item.Image_Url = string.Format("/img/item/{0}.jpg", i.ToString("D3"));
        //        item.Description = "此处为 "+ item.Item_Name + " 的商品描述";
        //        item.Item_Price = (int)rdm.Next(3, 5) * 10;
        //        item.Category_ID = 1;
        //        item.Click_Counts = rdm.Next(100, 999);
        //        item.Stock = rdm.Next(10, 99);
        //        item.Date_added = DateTime.Now.AddDays(0 - rdm.Next(0, 1000));
        //        item.Cost = item.Item_Price / 2;
        //        item.Sold = rdm.Next(10, 99);
        //        item.Discount = 0;
        //        var result = ItemManager.AddItem(item);

        //        //成功计数
        //        if (result) success++;
        //    }

        //    return string.Format("add items {0} ok", success);
        //}


        //[HttpGet]
        //public string GetItemList(int page, int pagesize, string keyword, int category_ID, ItemOrder itemOrder)
        //{
        //    var items = ItemManager.GetItemList(page, pagesize, keyword, category_ID, itemOrder);
        //    var result = JsonConvert.SerializeObject(items);
        //    return result;
        //}

        //[HttpGet]
        //public string GetUserOrders(int userId)
        //{
        //    var items = OrderManager.GetUserOrders(userId);
        //    var result = JsonConvert.SerializeObject(items);
        //    return result;
        //}

        //[HttpGet]

        //public string GetOrderDetail(int orderId)
        //{
        //    var result = OrderManager.GetOrderDetail(orderId);
        //    return JsonConvert.SerializeObject(result);
        //}

        //[HttpGet]
        //public string GetOrderList(int orderId)
        //{
        //    var items = OrderManager.GetOrderList(orderId);
        //    var result = JsonConvert.SerializeObject(items);
        //    return result;
        //}

        //[HttpGet]
        //public string CheckUserOwnsOrder(int userId, int orderId)
        //{
        //    var temp = OrderManager.CheckUserOwnsOrder(userId, orderId);
        //    return temp.ToString();
        //}

        //[HttpGet]
        //public bool SetOrderStatus(int orderId, int status)
        //{
        //    return OrderManager.SetOrderStatus(orderId, status);
        //}
    }
}