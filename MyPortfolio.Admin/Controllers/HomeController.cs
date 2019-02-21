using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyPortfolio.Model;
using MyPortfolio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;

        public HomeController(ApplicationUserManager userManager, ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public ActionResult Index()
        {
            
            var category = categoryService.GetAll();
            ViewBag.Categories = category;
            //var user = userManager.FindByName(User.Identity.Name);
            //ViewBag.CurrentUser = user;
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