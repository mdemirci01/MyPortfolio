using MyPortfolio.Model;
using MyPortfolio.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Admin.Controllers
{
    public class ProjectController : ControllerBase
    {
        // GET: Project
        private readonly ITechnologyService technologyService;
        private readonly IProjectService projectService;
        public ProjectController(IProjectService projectService, ITechnologyService technologyService, INotificationService notificationService) : base(notificationService)
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
        public ActionResult Create(Project project, HttpPostedFileBase[] Uploads)
        {
            if (ModelState.IsValid)
            {
                if (Uploads != null && Uploads.Length >= 1)
                {
                    project.ProjectFiles.Clear();
                    foreach (var item in Uploads)
                    {
                        if (item != null && item.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(item.FileName);
                            var extension = Path.GetExtension(fileName).ToLower();
                            if (extension == ".jpg" || extension == ".gif" || extension == ".png" || extension == ".pdf" || extension == ".doc" || extension == ".docx")
                            {
                                var path = Path.Combine(ConfigurationManager.AppSettings["uploadPath"], fileName);
                                item.SaveAs(path);
                                var file = new ProjectFile();
                                file.Id = Guid.NewGuid();
                                file.FileName = fileName;
                                file.CreatedAt = DateTime.Now;
                                file.CreatedBy = User.Identity.Name;
                                file.UpdatedAt = DateTime.Now;
                                file.UpdatedBy = User.Identity.Name;
                                file.IsActive = true;
                                project.ProjectFiles.Add(file);
                            }
                        }
                    }
                }
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