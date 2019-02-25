using MyPortfolio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;
        private readonly ITechnologyService technologyService;
        public ProjectController(IProjectService projectService, ITechnologyService technologyService)
        {
            this.projectService = projectService;
            this.technologyService = technologyService;
        }
        // GET: Project
        public ActionResult Index()
        {
            var project = projectService.GetAll();
            ViewBag.Technologies = technologyService.GetAll();
            return View(project);
        }
    }
}