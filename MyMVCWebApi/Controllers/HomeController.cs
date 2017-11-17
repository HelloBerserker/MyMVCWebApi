using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "我的API测试";

            return View();
        }
        public string Get(string a, string b)
        {
            return a + b;
        }
    }
}
