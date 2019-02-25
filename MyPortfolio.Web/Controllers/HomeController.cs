using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.user = ConfigurationManager.AppSettings["myKey"];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        /*
           public ActionResult Abouts(Guid id)
        {
            var page = pageService.Find(id);

            return View(page);
        }
        */
        public ActionResult Portfolio()
        {

            ViewBag.Message = "Your portfolio page.";

            return View();
        }
        public ActionResult Blog()
        {

            ViewBag.Message = "Your  Blog page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}