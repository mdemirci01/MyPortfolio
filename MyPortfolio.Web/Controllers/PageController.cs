using MyPortfolio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Web.Controllers
{
    public class PageController : Controller
    {
        private readonly IPageService pageService;

        public PageController(IPageService pageService)
        {
            this.pageService = pageService;
        }
        // GET: AboutPage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(Guid id)
        {
            var page = pageService.Find(id);

            return View(page);
        }
    }
}