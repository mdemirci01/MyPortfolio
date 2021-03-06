﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MyPortfolio.Model;
using MyPortfolio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Admin.Controllers
{
    [Authorize]
    public class ApplicationUserController : ControllerBase
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        public ApplicationUserController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, INotificationService notificationService, ApplicationRoleManager roleManager) : base(notificationService)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _roleManager = roleManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: ApplicationUser
        public ActionResult Index()
        {
            var users = UserManager.Users.ToList();
            return View(users);
        }
        public ActionResult Delete(string id)
        {
            var userToDelete = UserManager.FindById(id);
            var currentUserId = User.Identity.GetUserId();
            if (userToDelete == null)
            {
                TempData["NullUser"] = "Uyarı: Kullanıcı bulunamadı!";
                return RedirectToAction("Index");
            }
            if (userToDelete.Id == currentUserId)
            {
                TempData["CurrentUser"] = "Uyarı: Kendinizi silemezsiniz!";
                return RedirectToAction("Index");
            }
            UserManager.Delete(userToDelete);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string id)
        {
            var user = UserManager.FindById(id);
            ViewBag.Roles = _roleManager.Roles.ToList();

            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(ApplicationUser user, string[] SelectedRole)
        {
            if (ModelState.IsValid)
            {
                var model = UserManager.FindById(user.Id);
                model.FullName = user.FullName;
                model.Email = user.Email;
                model.Photo = user.Photo;
                UserManager.Update(model);

                var oldRoles = model.Roles.Select(r => r.RoleId).ToList();
                var rolesToRemove = _roleManager.Roles.Where(w => oldRoles.Contains(w.Id)).Select(r => r.Name).ToArray();
                UserManager.RemoveFromRoles(user.Id, rolesToRemove);
                var rolesToAdd = _roleManager.Roles.Where(w => SelectedRole.Contains(w.Id)).Select(r => r.Name).ToArray();
                UserManager.AddToRoles(user.Id, rolesToAdd);

                return RedirectToAction("Index");
            }
            ViewBag.Roles = _roleManager.Roles.ToList();

            return View();
        }
    }
}