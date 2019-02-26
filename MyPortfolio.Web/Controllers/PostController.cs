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
        public ActionResult Index(int page = 1)
        {
            
            ViewBag.Categories = categoryService.GetAll();
            int skip = (page - 1) * 5;
            int take = 5;
            // sayfa noya göre 5 kayıt getir
            var posts = postService.GetAll().OrderByDescending(o => o.CreatedAt).Skip(skip).Take(take).ToList();

            // son yazılar
            ViewBag.RecentPosts = postService.GetAll().OrderByDescending(o => o.CreatedAt).Take(4).ToList();
            ViewBag.Page = page;
            return View(posts);
        }
        public ActionResult Blog() {

            return View();

        }
    }
}