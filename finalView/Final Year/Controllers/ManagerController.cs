using Final_Year.BusinessLogic;
using Final_Year.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
        public ActionResult MyCustomers()
        {
            Employee e=(Employee)Session["Employee"];
            DataTable dt= CustomerLogic.SelectByManagerID(e.EmployeeID);

            return View(dt);
        }

    }
}