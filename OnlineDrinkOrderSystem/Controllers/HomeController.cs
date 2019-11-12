using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineDrinkOrderSystem.Models;
using Newtonsoft.Json;
using OnlineDrinkOrderSystem.Common;
using Microsoft.Extensions.Options;

namespace OnlineDrinkOrderSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string SubmitToken(string token)
        {
            ResultResponse result = new ResultResponse();
            result.status = false;
            result.message = "Token:" + token;
            if (!string.IsNullOrEmpty(token))
            {
                result.status = GoogleOauth.GoogleJwtVerify(token);
            }
            return JsonConvert.SerializeObject(result);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
