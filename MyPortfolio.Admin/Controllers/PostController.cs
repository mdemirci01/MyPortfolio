using AutoMapper;
using MyPortfolio.Admin.Models;
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
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;
        public PostController(IPostService postService, ICategoryService categoryService, INotificationService notificationService) : base(notificationService)
        {
            this.postService = postService;
            this.categoryService = categoryService;
        }
        // GET: Post
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var posts = postService.GetAll();
            var postViewModels = Mapper.Map<IEnumerable<PostViewModel>>(posts);
            return View(postViewModels);
        }
        public ActionResult Create()
        {
            var postViewModel = new PostViewModel();
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name");
            return View(postViewModel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(PostViewModel postViewModel, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(upload.FileName);
                    string extension = Path.GetExtension(fileName).ToLower();
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                    {
                        string path = Path.Combine(ConfigurationManager.AppSettings["uploadPath"], fileName);
                        upload.SaveAs(path);
                        postViewModel.Photo = fileName;
                        var post = Mapper.Map<Post>(postViewModel);
                        postService.Insert(post);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");
                    }
                }
                else
                {
                    var post = Mapper.Map<Post>(postViewModel);
                    postService.Insert(post);
                    return RedirectToAction("index");
                }

            }

            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", postViewModel.CategoryId);
            return View(postViewModel);
        }
        public ActionResult Edit(Guid id)
        {
            var post = postService.Find(id);
            var postViewModel = Mapper.Map<PostViewModel>(post);
            if (postViewModel == null)
            {
                return HttpNotFound();

            }
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", postViewModel.CategoryId);
            return View(postViewModel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(PostViewModel postViewModel, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(upload.FileName);
                    string extension = Path.GetExtension(fileName).ToLower();
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                    {
                        string path = Path.Combine(ConfigurationManager.AppSettings["uploadPath"], fileName);
                        upload.SaveAs(path);
                        postViewModel.Photo = fileName;
                        var post = Mapper.Map<Post>(postViewModel);
                        postService.Update(post);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");

                    }
                }
                else
                {
                    // resim seçilip yüklenmese bile diğer bilgileri güncelle
                    var post = Mapper.Map<Post>(postViewModel);
                    postService.Update(post);
                    return RedirectToAction("index");
                }


            }
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", postViewModel.CategoryId);
            return View(postViewModel);
        }
        public ActionResult Delete(Guid id)
        {
            postService.Delete(id);
            return RedirectToAction("index");
        }

        public ActionResult Details(Guid id)
        {
            var post = postService.Find(id);
            var postViewModel = Mapper.Map<PostViewModel>(post);
            if (postViewModel == null)
            {
                return HttpNotFound();

            }

            return View(postViewModel);
        }
    }
}