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
        private readonly ITechnologyService technologyService;
        private readonly IProjectService projectService;
        public ProjectController(IProjectService projectService, ITechnologyService technologyService)
        {
            this.projectService = projectService;
            this.technologyService = technologyService;
        }
        public ActionResult Index()
        {
            var project = projectService.GetAll();
            return View(project);
        }
        public ActionResult Create()
        {
            var project = new Project();
            ViewBag.Technologies = new SelectList(technologyService.GetAll(), "Id", "Name", project.TechnologyId);
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
            ViewBag.Technologies = new SelectList(technologyService.GetAll(), "Id", "Name", project.TechnologyId);
            return View(project);
        }

        public ActionResult Edit(Guid id)
        {
            var project = projectService.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.Technologies = new SelectList(technologyService.GetAll(), "Id", "Name", project.TechnologyId);
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
                model.Year = project.Year;
                model.Photo = project.Photo;
                model.IsActive = project.IsActive;
                model.TechnologyId = project.TechnologyId;
                projectService.Update(model);
                return RedirectToAction("Index");


            }
            ViewBag.Technologies = new SelectList(technologyService.GetAll(), "Id", "Name", project.TechnologyId);
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