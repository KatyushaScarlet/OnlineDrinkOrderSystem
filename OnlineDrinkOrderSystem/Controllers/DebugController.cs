using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineDrinkOrderSystem.Models;
using OnlineDrinkOrderSystem.DAL;

namespace OnlineDrinkOrderSystem.Controllers
{
    public class DebugController : Controller
    {
        public string Index()
        {
            return "debug ok";
        }

        //商品添加测试
        [HttpGet]
        public string AddTest()
        {
            Item item = new Item();
            item.Item_Name = "测试商品";
            item.Image_Url = "/img/item/test.jpg";
            item.Description = "此处为商品描述";
            item.Item_Price = 9.9;
            item.Category_ID = 6;
            item.Click_Counts = 100;
            item.Stock = 999;
            item.Date_added = DateTime.Now;
            item.Cost = 4.9;
            item.Sold = 10;
            item.Discount = 0;
            return ItemManager.AddItem(item).ToString();
        }

        //商品批量添加测试
        [HttpGet]
        public string AddItems(int count=1)
        {
            int success = 0;
            for (int i = 0; i < count; i++)
            {
                //取新的随机种子
                Random rdm = new Random(int.Parse(DateTime.Now.ToString("HHmmssfff")).GetHashCode());//保证不重复

                //创建新商品
                Item item = new Item();
                item.Item_Name = "测试商品" + rdm.Next(100000, 999999);
                item.Image_Url = "/img/item/test.jpg";
                item.Description = "此处为商品描述";
                item.Item_Price = (double)rdm.Next(1000, 10000) / (double)100;
                item.Category_ID = rdm.Next(1, 6);
                item.Click_Counts = rdm.Next(100, 1000);
                item.Stock = rdm.Next(100, 10000);
                item.Date_added = DateTime.Now.AddDays(0 - rdm.Next(0, 1000));
                item.Cost = item.Item_Price / (double)10;
                item.Sold = rdm.Next(100, 1000);
                item.Discount = 0;
                var result = ItemManager.AddItem(item);
                
                //成功计数
                if (result) success++;
            }

            return string.Format("add items {0}/{1} ok", success, count);
        }
    }
}