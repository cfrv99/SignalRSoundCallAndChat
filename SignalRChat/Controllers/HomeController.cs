using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalRChat.Middlewares;
using SignalRChat.Models;

namespace SignalRChat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var session = HttpContext.Session.GetString("UserName");
            var key = ChatList.FirstOrDefault(i => i.Value == session).Key;
            HttpContext.Session.Clear();
            if (key != null || !string.IsNullOrEmpty(key))
            {
                ChatList.Remove(key);

            }
            ViewBag.GroupName = Guid.NewGuid();

            return View();
        }

        static Dictionary<string, string> ChatList = new Dictionary<string, string>();
        [HttpPost]
        public IActionResult Index([FromBody] LoginModel model)
        {
            var data = HttpContext.Session.GetString("UserName");
            if (!string.IsNullOrWhiteSpace(data))
            {
                HttpContext.Session.Clear();
            }
            if (model.Login.ToLower() == "ferid" || model.Login.ToLower() == "murad" || model.Login.ToLower() == "orxan" || model.Login.ToLower() == "aychin")
            {
                if (!ChatList.Any(i => i.Value == model.Login))
                {
                    ChatList.Add(DateTime.Now.ToString(), model.Login);
                    HttpContext.Session.SetString("UserName", model.Login);
                    return Content("Ok");
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return Unauthorized();
            }

        }
        public IActionResult Privacy()
        {
            var data = HttpContext.Session.GetString("UserName");
            Console.WriteLine(data);
            List<string> datas = new List<string>(){"1","2","3","4","5","6","7","8","9"};
            var a = datas.AsQueryable().WhereIf(datas.Contains("7"), i => i == "3");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
