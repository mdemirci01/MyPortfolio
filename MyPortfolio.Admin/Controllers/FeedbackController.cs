using MyPortfolio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Admin.Controllers
{
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService feedbackService;

        public FeedbackController(IFeedbackService feedbackService, INotificationService notificationService) : base(notificationService)
        {
            this.feedbackService = feedbackService;
        }

        // GET: Feedback
        public ActionResult Index()
        {
            var feedback = feedbackService.GetAll();
            return View(feedback);
        }

        public ActionResult Delete(Guid id)
        {
            feedbackService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            var feedbackDetails = feedbackService.Find(id);
            if (feedbackDetails == null)
            {
                return HttpNotFound();
            }
            return View(feedbackDetails);
        }
    }
}