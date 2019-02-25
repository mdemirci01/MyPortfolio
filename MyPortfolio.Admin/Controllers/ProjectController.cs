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

        public ActionResult Edit(Guid id)
        {
            var project = projectService.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                var model = projectService.Find(project.Id);
                model.Name = project.Name;
                model.ShortDescription = project.ShortDescription;
                model.Description = project.Description;
                model.GithubLink = project.GithubLink;
                model.Technology = project.Technology;
                model.Year = project.Year;
                model.Photo = project.Photo;
                model.IsActive = project.IsActive;
                projectService.Update(model);
                return RedirectToAction("Index");


            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            projectService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            return View(projectService.Find(id));
        }
    }
}