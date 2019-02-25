using MyPortfolio.Data;
using MyPortfolio.Model;
using MyPortfolio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Admin.Controllers
{
    public class NewsLetterController : ControllerBase
    {
        private readonly INewsletterService newsletterService;
        public NewsLetterController(INewsletterService newsletterService, INotificationService notificationService) : base(notificationService)
        {
            this.newsletterService = newsletterService;
        }
        // GET: NewsLetter
        public ActionResult Index()
        {
            var newsletters = newsletterService.GetAll();
            return View(newsletters);
        }
        public ActionResult Create()
        {
            var newsletter = new Newsletter();
            return View(newsletter);
        }

        [HttpPost]
        public ActionResult Create(Newsletter newsletter)
        {
            if (ModelState.IsValid)
            {
                newsletterService.Insert(newsletter);
                return RedirectToAction("Index");
            }
            return View(newsletter);
        }

        public ActionResult Edit(Guid id)
        {
            var newsletter = newsletterService.Find(id);
            if (newsletter == null)
            {
                return HttpNotFound();
            }
            return View(newsletter);
        }
        [HttpPost]
        public ActionResult Edit(Newsletter newsletter)
        {
            if (ModelState.IsValid)
            {
                newsletterService.Update(newsletter);
                return RedirectToAction("Index");
            }
            return View(newsletter);
        }

        public ActionResult Delete(Guid id)
        {
            newsletterService.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id)
        {
            var newsletter = newsletterService.Find(id);
            return View(newsletter);
        }
    }
}