using MyPortfolio.Model;
using MyPortfolio.Service;
using System;
using System.Collections.Generic;
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

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (notificationService != null) { 
                ViewBag.Notification = notificationService.GetAll();
            } else {
                ViewBag.Notification = new List<Notification>();
            }
            base.OnActionExecuted(filterContext);
        }
    }
}