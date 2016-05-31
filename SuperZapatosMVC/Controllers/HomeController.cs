using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperZapatosMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Growth Acceleration Partners - Test";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Page";
            return View();
        }
    }
}