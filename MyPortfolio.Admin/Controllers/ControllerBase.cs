using MyPortfolio.Model;
using MyPortfolio.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Admin.Controllers
{
    public class ControllerBase:Controller
    {
        private readonly INotificationService notificationService;
        public ControllerBase(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }
        // bu metot tüm actionlardan önce çalışır
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
        // bu metot tüm actionlardan sonra çalışır
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (notificationService != null) { 
                ViewBag.Notification = notificationService.GetAll();
            } else {
                ViewBag.Notification = new List<Notification>();
            }
            ViewBag.AssetsUrl = ConfigurationManager.AppSettings["assetsUrl"];
            base.OnActionExecuted(filterContext);
        }
    }
}