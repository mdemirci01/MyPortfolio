using MyPortfolio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Admin.Controllers
{
    public class SearchController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IPostService postService;
        
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
    }
}