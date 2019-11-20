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

        [HttpGet]
        //public string AddToCart(int id = 0, int count = 0)
        //{

        //}
    }
}