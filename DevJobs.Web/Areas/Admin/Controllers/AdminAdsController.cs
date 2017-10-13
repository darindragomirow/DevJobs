using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevJobs.Web.Areas.Admin.Controllers
{
    public class AdminAdsController : Controller
    {
        // GET: Admin/AdminAds
        public ActionResult Index()
        {
            return View();
        }
    }
}