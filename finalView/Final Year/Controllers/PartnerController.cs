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

            // if (Request.Files["Photo"].ContentLength > 0)
            //{
            //     string filename = DateTime.Now.Ticks.ToString() + "_" + Request.Files["Photo"].FileName;
            //     string PhysicalFileName = Server.MapPath("~/UserProfilePicture/" + filename);
            //     Request.Files["Photo"].SaveAs(PhysicalFileName);
            //     e.Photo = filename;
            // }
            // else
            // {
            //     e.Photo = "";
            //}
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
           Employee e= EmployeeLogic.SelectByPK(Convert.ToInt32(Request.Params["EmployeeID"]));
           return View(e);
        }
        [HttpPost]
        public ActionResult EmployeeEditSubmit()
        {
            Employee e = EmployeeLogic.SelectByPK(Convert.ToInt32(Request.Params["EmployeeID"]));
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
            int Id =Convert.ToInt32(Request.Params["EmployeeID"]);
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
            DataTable dt = CustomerServiceLogic.CustomerServiceByCustID(Convert.ToInt32(Request.Params["CustomerID"]));
            ViewBag.customerService = dt;
            return View(c);
        }
        [HttpPost]
        public ActionResult CustomerEditSubmit()
        {
            Customer c = CustomerLogic.SelectByPK(Convert.ToInt32(Request.Params["CustomerID"]));
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

        public ActionResult EmployeeProfile()
        {
            Employee e1 =(Employee)Session["Employee"];
            Employee e = EmployeeLogic.SelectByPK(e1.EmployeeID);
            return View(e);
        }

        public ActionResult ServiceNew()
        {  
            return View();
        }
        [HttpPost]
        public ActionResult ServiceNewSubmit()
        {
            Service s = new Service();
            s.Sname = Request.Params["Sname"];
            s.Description = Request.Params["Description"];
            s.Requirements = Request.Params["Requirements"];
            s.Documents = Request.Params["Documents"];
            s.EmployeeID = Convert.ToInt32(Request.Params["EmployeeID"]);
            ServiceLogic.Insert(s);
            return RedirectToAction("ServiceList");
        }
        public ActionResult ServiceList()
        {
            DataTable dt = ServiceLogic.SelectALL();
            return View(dt);
        }
        public ActionResult ServiceEdit()
        {
            Service s = ServiceLogic.SelectByPK(Convert.ToInt32(Request.Params["ServiceID"]));
            return View(s);
        }
        [HttpPost]
        public ActionResult ServiceEditSubmit()
        {
            Service c = ServiceLogic.SelectByPK(Convert.ToInt32(Request.Params["ServiceID"]));
            c.Sname = Request.Params["Sname"];
            c.Description = Request.Params["Description"];
            c.Documents = Request.Params["Documents"];
            c.Requirements = Request.Params["Requirements"]; 
            c.EmployeeID = Convert.ToInt32(Request.Params["EmployeeID"]);

            ServiceLogic.Update(c);
            return RedirectToAction("ServiceList");
        }
        public ActionResult ServiceDelete()
        {
            int ServiceId = Convert.ToInt32(Request.Params["ServiceID"]);
            ServiceLogic.Delete(ServiceId);
            return RedirectToAction("ServiceList");
        }

        //public ActionResult GetCustomerServiceList()
        //{
        //    DataTable dtCSL = CustomerServiceLogic.CustomerServiceList(Convert.ToInt32(Request.Params["CustomerID"]));
        //    ViewBag.dtCSL = dtCSL;
        //    return RedirectToAction("CustomerEdit", dtCSL);
        //}

        public ActionResult CustomerServiceNew()
        {
            DataTable dt1 = CustomerLogic.SelectALL();
            DataTable dt2 = ServiceLogic.SelectALL();

            ViewBag.customerDt = dt1;
            ViewBag.serviceDt = dt2;
            return View();
        }
        [HttpPost]
        public ActionResult CustomerServiceNewSubmit()
        {
            CustomerService cs = new CustomerService();
            cs.CustomerID = Convert.ToInt32(Request.Params["CustomerID"]);
            cs.ServiceID = Convert.ToInt32(Request.Params["ServiceID"]);
            cs.StartDate = Convert.ToDateTime(Request.Params["StartDate"]);
            cs.EndDate = Convert.ToDateTime(Request.Params["EndDate"]);
            CustomerServiceLogic.Insert(cs);
            return RedirectToAction("CustomerServiceList");
        }
        public ActionResult CustomerServiceList()
        {
            DataTable dtCSL = CustomerServiceLogic.CustomerServiceList();
            return View(dtCSL);
        }
      
        public ActionResult CustomerServiceDelete()
        {
            int CustomerServiceID = Convert.ToInt32(Request.Params["CustomerServiceID"]);
            CustomerServiceLogic.Delete(CustomerServiceID);
            return RedirectToAction("CustomerServiceList");
        }
        public ActionResult CustomerServiceEdit()
        {
            DataTable dt= CustomerServiceLogic.CustomerServiceByPKAndCustID(Convert.ToInt32(Request.Params["CustomerID"]), Convert.ToInt32(Request.Params["CustomerServiceID"]));
            return View(dt);
        }
        public ActionResult CustomerServiceEditSubmit()
        {
            CustomerService cs = new CustomerService();
            cs.CustomerServiceID = Convert.ToInt32(Request.Params["CustomerServiceID"]);
            cs.CustomerID = Convert.ToInt32(Request.Params["CustomerID"]);
            cs.ServiceID = Convert.ToInt32(Request.Params["ServiceID"]);
            cs.StartDate = Convert.ToDateTime(Request.Params["StartDate"]);
            cs.EndDate = Convert.ToDateTime(Request.Params["EndDate"]);
            CustomerServiceLogic.Update(cs);

            if (Session["CurrentUrl"] == null){ return RedirectToAction("Login", "Public"); }
              else { return RedirectToRoute(Session["CurrentUrl"]); }
            
        }
    }
}