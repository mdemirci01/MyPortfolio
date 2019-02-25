using MyPortfolio.Admin.Models;
using MyPortfolio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Admin.Controllers
{
    public class SearchController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IPostService postService;
        private readonly IPageService pageService;
        public SearchController(ICategoryService categoryService, IPostService postService, IPageService pageService, INotificationService notificationService) : base(notificationService)
        {
            this.categoryService = categoryService;
            this.postService = postService;
            this.pageService = pageService;
        }
        // GET: Search
        public ActionResult Index(string name)
        {          
            if (name != "")
            {
                var searchResults = new List<SearchViewModel>();

                var categories = categoryService.Search(name).Select(s => new SearchViewModel {Id =s.Id, Title = s.Name, Description = s.Description, CreatedAt = s.CreatedAt, Type = "Kategori", IsActive = s.IsActive }).ToList();
                searchResults.AddRange(categories);

                var posts = postService.Search(name).Select(s => new SearchViewModel {Id = s.Id, Title = s.Title, Description = s.Description, CreatedAt = s.CreatedAt, Type = "Yazı", IsActive = s.IsActive }).ToList();
                searchResults.AddRange(posts);

                var pages = pageService.Search(name).Select(s => new SearchViewModel { Id = s.Id, Title = s.Title, Description = s.Description, CreatedAt = s.CreatedAt, Type = "Sayfa", IsActive = s.IsActive }).ToList();
                searchResults.AddRange(pages);

                return View(searchResults);
            }
            return RedirectToAction("Index", "Home"); 
        }
    }
}