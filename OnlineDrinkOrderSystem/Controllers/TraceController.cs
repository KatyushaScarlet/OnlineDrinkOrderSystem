using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OnlineDrinkOrderSystem.Common;
using OnlineDrinkOrderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineDrinkOrderSystem.DAL;

namespace OnlineDrinkOrderSystem.Controllers
{
    public class TraceController : Controller
    {
        //添加到追踪列表
        [HttpGet]
        public string AddItemToList(int itemId)
        {
            Response response = new Response();
            response.status = false;

            int nowUserId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            if (nowUserId != 0)
            {
                TraceManager.AddItemToList(nowUserId, itemId);
                response.status = true;
                response.message = "操作成功";
            }
            else
            {
                response.message = "请先登录";
            }
            return JsonConvert.SerializeObject(response);
        }

        //从追踪列表中移除
        [HttpGet]
        public string RemoveItemFromList(int itemId)
        {
            Response response = new Response();
            response.status = false;

            int nowUserId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            if (nowUserId != 0)
            {
                TraceManager.RemoveItemFromList(nowUserId, itemId);
                response.status = true;
                response.message = "操作成功";
            }
            else
            {
                response.message = "请先登录";
            }
            return JsonConvert.SerializeObject(response);
        }

        //判断商品是否存在于用户的追踪列表中
        [HttpGet]
        public bool CheckItemInTraceList(int itemId)
        {
            Response response = new Response();
            response.status = false;

            int nowUserId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            if (nowUserId != 0)
            {
                bool result = TraceManager.CheckItemInTraceList(nowUserId, itemId);
                if (result)
                {
                    return true;
                }
            }
            return false;
        }
    }
}