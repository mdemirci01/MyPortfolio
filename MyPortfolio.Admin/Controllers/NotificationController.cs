using MyPortfolio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Admin.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationService notificationService;
        public NotificationController(INotificationService notificationService) {
            this.notificationService = notificationService;

        }

        // GET: Notification
        public ActionResult Index()
        {
            var notification = notificationService.GetAll();
            return View(notification);
        }
        
    }
}