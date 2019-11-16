using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineDrinkOrderSystem.Common;
using OnlineDrinkOrderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OnlineDrinkOrderSystem.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public string SubmitToken(string token)
        {
            ResultResponse result = new ResultResponse();
            result.status = false;
            result.message = "Token:" + token;
            if (!string.IsNullOrEmpty(token))
            {
                result.status = GoogleOauth.GoogleTokenVerify(token);
            }
            return JsonConvert.SerializeObject(result);
        }
    }
}