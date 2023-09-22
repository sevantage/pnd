using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var appSetting = ConfigurationManager.AppSettings["MyAppSetting"];
            return View((object)appSetting);
        }
    }
}