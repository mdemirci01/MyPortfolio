using MyPortfolio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Admin.Controllers
{
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService notificationService;
        public NotificationController(INotificationService notificationService) : base(notificationService)
        {
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