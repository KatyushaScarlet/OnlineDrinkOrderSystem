using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineDrinkOrderSystem.DAL;
using OnlineDrinkOrderSystem.Models;
using Newtonsoft.Json;

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
    }
}