using MyPortfolio.Model;
using MyPortfolio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Admin.Controllers
{
    public class PageController : Controller
    {

        private readonly IPageService pageService;

        public PageController(IPageService pageService)
        {
            this.pageService = pageService;
        }
        // GET: Page
        public ActionResult Index()
        {
            var pages = pageService.GetAll();
            return View(pages);
        }

        public ActionResult Create()
        {
            var page = new Page();
            ViewBag.CategoryId = new SelectList(pageService.GetAll(), "Id", "Name");
            return View(page);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Page page)
        {
            if (ModelState.IsValid)
            {
                pageService.Insert(page);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            var page = pageService.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Page page)
        {
            if (ModelState.IsValid)
            {
                var model = pageService.Find(page.Id);
                model.Title = page.Title;
                model.Description = page.Description;
                pageService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            pageService.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id)
        {
            var page = pageService.Find(id);

            return View(page);
        }
    }
}