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
    public class PublicController : Controller
    {
        // GET: Public
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginSubmit()
        {
            Session["CurrentUrl"] = Request.Url.ToString();
            String Username = Request.Params["Username"];
            String Password = Request.Params["Password"];
            Employee e = EmployeeLogic.SelectByUnPs(Username, Password);

            if (e!=null && e.Email!=null)
            {
                Session["Employee"] = e;
                if(e.EmployeeRole.Equals("Partner"))
                {
                    return RedirectToAction("AdminHome", "Partner");
                }else if (e.EmployeeRole.Equals("Manager"))
                {
                    return RedirectToAction("ManagerHome","Manager");
                }
                else
                {
                    return RedirectToAction("StaffHome","Staff");
                }
            }
            else
            {
                Customer c = CustomerLogic.SelectByUnPs(Username, Password);
                if (c!=null && c.Email!= null)
                {
                    Session["Customer"] = c;
                    return RedirectToAction("CustomerHome","Partner");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
               
        }
       

    }
}