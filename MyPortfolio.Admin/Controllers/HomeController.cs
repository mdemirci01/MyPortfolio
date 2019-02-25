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
        private readonly IPostService postService;
        private readonly IPageService pageService;
        private readonly ApplicationUserManager userManager;

        public HomeController(ApplicationUserManager userManager, ICategoryService categoryService,IPostService postService,IPageService pageService)
        {
            this.categoryService = categoryService;
            this.postService = postService;
            this.pageService = pageService;
            this.userManager = userManager;
           
        }

        public ActionResult Index()
        {
            
            var category = categoryService.GetAll();
            ViewBag.Categories = category;
            ViewBag.PostCount = postService.GetAll().Count();
            ViewBag.CategoryCount = categoryService.GetAll().Count();
            ViewBag.PageCount = pageService.GetAll().Count();
            ViewBag.UserCount = userManager.Users.Count();
            var user = userManager.FindByName(User.Identity.Name);
            ViewBag.CurrentUser = user.FullName;
            var post = postService.GetAll();     
            ViewBag.Posts = post;
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