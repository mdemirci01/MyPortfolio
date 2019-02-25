using MyPortfolio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;
        
        public PostController(IPostService postService, ICategoryService categoryService) {
            this.postService = postService;
            this.categoryService = categoryService;

        }
        // GET: Post
        public ActionResult Index()
        {
            
            ViewBag.Categories = categoryService.GetAll();
            var posts = postService.GetAll();
            ViewBag.Post = posts;
            return View();
        }
        public ActionResult Blog() {

            return View();

        }
    }
}