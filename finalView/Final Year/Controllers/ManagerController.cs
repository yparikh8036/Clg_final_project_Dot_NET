using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Year.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Managers
        public ActionResult ManagerHome()
        {
            return View();
        }
    }
}