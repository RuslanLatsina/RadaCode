using System;
using System.Web.Mvc;

namespace RadaCode.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var regdate = new DateTime(2015, 12, 1);
            var nowdate = new DateTime(2015, 12, 12);
            var number = 10 + ((int)(nowdate - regdate).TotalDays / 3);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}