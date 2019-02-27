using MyPortfolio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Web.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult Newsletter()
        {
            return PartialView("_NewsletterPartial");
        }
    }
}