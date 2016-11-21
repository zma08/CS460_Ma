using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PirateApp.Controllers
{
    public class PiratesController : Controller
    {
        // GET: Pirates
        public ActionResult Index()
        {
            return View();
        }
    }
}