using MyPortfolio.Model;
using MyPortfolio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Admin.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        private readonly IProjectService projectService;
        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }
        public ActionResult Index()
        {
            var project = projectService.GetAll();
            return View(project);
        }
        public ActionResult Create()
        {
            var project = new Project();
            return View(project);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                projectService.Insert(project);
                return RedirectToAction("Index");
            }
            return View(project);
        }

        public ActionResult Edit()
        {
            return View();

        }
        public ActionResult Delete()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
    }
}