using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Year.Models;
using Final_Year.BusinessLogic;

namespace Final_Year.Controllers
{
    public class PartnerController : Controller
    {
        // GET: Partner
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult EmployeeNew()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeNewSubmit()
        {
            Employee e = new Employee();
            e.Name = Request.Params["Name"];
            e.Email = Request.Params["Email"];
            e.Mobile = Request.Params["Mobile"];
            e.Address = Request.Params["Address"];
            e.EmployeeRole = Request.Params["EmployeeRole"];
            e.Username = Request.Params["Username"];
            e.Password = Request.Params["Password"];
            e.IsActive = (Request.Params["IsActive"] == "1");
            e.Photo = Request.Params["Photo"];
            EmployeeLogic.Insert(e);
            return RedirectToAction("EmployeeList");
        }
        public ActionResult EmployeeList()
        {
              DataTable dt = EmployeeLogic.SelectALL();
              return View(dt);
        }
        public ActionResult EmployeeEdit()
        {
             
            Employee e= EmployeeLogic.SelectByPK(Convert.ToInt32(Request.Params["Id"]));
           return View(e);
        }
        [HttpPost]
        public ActionResult EmployeeEditSubmit()
        {
            Employee e = EmployeeLogic.SelectByPK(Convert.ToInt32(Request.Params["Id"]));
            e.Name = Request.Params["Name"];
            e.Email = Request.Params["Email"];
            e.Mobile = Request.Params["Mobile"];
            e.Address = Request.Params["Address"];
            e.EmployeeRole = Request.Params["EmployeeRole"];
            e.Username = Request.Params["Username"];
            e.Password = Request.Params["Password"];
            e.IsActive = (Request.Params["IsActive"] == "1");
            e.Photo = Request.Params["Photo"];
            EmployeeLogic.Update(e);
            return RedirectToAction("EmployeeList");
        }
       
        public ActionResult EmployeeDelete()
        {
            int Id =Convert.ToInt32(Request.Params["Id"]);
            EmployeeLogic.Delete(Id);
            return RedirectToAction("EmployeeList");
        }
        public ActionResult CustomerNew()
        {
            return View();
        }
        public ActionResult CustomerNewSubmit()
        {
            Customer c = new Customer();
            c.Name = Request.Params["Name"];
            c.Email = Request.Params["Email"];
            c.Mobile = Request.Params["Mobile"];
            c.Address = Request.Params["Address"];
            c.Username = Request.Params["Username"];
            c.Password = Request.Params["Password"];
            c.IsActive = (Request.Params["IsActive"] == "1");
            c.AccName = Request.Params["AccName"];
            c.AccUsername = Request.Params["AccUsername"];
            c.AccPassword = Request.Params["AccPassword"];
            c.DOB = Convert.ToDateTime(Request.Params["DOB"]);
            c.PAN = Request.Params["PAN"];
            c.GSTIN = Request.Params["GSTIN"];
            c.EmployeeID = Convert.ToInt32(Request.Params["EmployeeID"]);

            CustomerLogic.Insert(c);
            return RedirectToAction("CustomerList");
        }
        public ActionResult CustomerList()
        {
            DataTable dt = CustomerLogic.SelectALL();
            return View(dt);
        }
        public ActionResult CustomerEdit()
        {
            Customer c = CustomerLogic.SelectByPK(Convert.ToInt32(Request.Params["CustomerID"]));
            return View(c);
        }
        public ActionResult CustomerEditSubmit()
        {
            Customer c = new Customer();
            c.Name = Request.Params["Name"];
            c.Email = Request.Params["Email"];
            c.Mobile = Request.Params["Mobile"];
            c.Address = Request.Params["Address"];
            c.Username = Request.Params["Username"];
            c.Password = Request.Params["Password"];
            c.IsActive = (Request.Params["IsActive"] == "1");
            c.AccName = Request.Params["AccName"];
            c.AccUsername = Request.Params["AccUsername"];
            c.AccPassword = Request.Params["AccPassword"];
            c.DOB = Convert.ToDateTime(Request.Params["DOB"]);
            c.PAN = Request.Params["PAN"];
            c.GSTIN = Request.Params["GSTIN"];
            c.EmployeeID = Convert.ToInt32(Request.Params["EmployeeID"]);

            CustomerLogic.Update(c);
            return RedirectToAction("CustomerList");

        }
        public ActionResult CustomerDelete()
        {
            int CustomerID = Convert.ToInt32(Request.Params["CustomerID"]);
            CustomerLogic.Delete(CustomerID);
            return RedirectToAction("CustomerList");
        }

        public ActionResult GetCustomerServiceList()
        {
            DataTable dtCSL = CustomerServiceLogic.CustomerServiceList(Convert.ToInt32(Request.Params["CustomerID"]));
            ViewBag.dtCSL = dtCSL;
            return RedirectToAction("CustomerEdit", dtCSL);
        }
        
    }
}