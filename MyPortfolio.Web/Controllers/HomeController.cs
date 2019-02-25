using MyPortfolio.Service;
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
        private readonly IPageService pageService;       

        public HomeController( IPageService pageService)
        {           
            this.pageService = pageService;
        }

        public ActionResult Index()
        {
            ViewBag.user = ConfigurationManager.AppSettings["myKey"];
            return View();
        }
       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var page = pageService.FindByTitle("Hakkında");
            return View(page);
        }
        
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