using Final_Year.BusinessLogic;
using Final_Year.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Year.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            //DataTable dt = CustomerLogic.getHomeDetails(Convert.ToInt32(Request.Params["CustomerID"])); 
            return View();
        }

        public ActionResult MyProfile()
        {
            Customer c = CustomerLogic.SelectByPK(Convert.ToInt32(Request.Params["CustomerID"]));
            return View(c);
        }
    }
}