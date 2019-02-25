using MyPortfolio.Model;
using MyPortfolio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Admin.Controllers
{
    public class TechnologyController : Controller
    {
        private readonly ITechnologyService technologyService;
        // GET: Technology
        public TechnologyController(ITechnologyService technologyService)
        {
            this.technologyService = technologyService;
        }
        public ActionResult Index()
        {
            var technology = technologyService.GetAll();
            return View(technology);
        }
        public ActionResult Create()
        {
            var technology = new Technology();
            return View(technology);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Technology technology)
        {
            if (ModelState.IsValid)
            {
                technologyService.Insert(technology);
                return RedirectToAction("Index");
            }
            return View(technology);
        }
        public ActionResult Edit(Guid id)
        {
            var technology = technologyService.Find(id);
            if (technology == null)
            {
                return HttpNotFound();
            }
            return View(technology);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Technology technology)
        {
            if (ModelState.IsValid)
            {
                var model = technologyService.Find(technology.Id);
                model.Name = technology.Name;
                technologyService.Update(model);
                return RedirectToAction("Index");
            }
            return View();

        }
        public ActionResult Delete(Guid id)
        {
            technologyService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            return View(technologyService.Find(id));
        }

    }
}