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
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult StaffHome()
        {
            return View();
        }
        public ActionResult Customerdetails()
        {
            int id = Convert.ToInt32(Request.Params["CustomerID"]);
            Customer c = CustomerLogic.SelectByPK(id);
            DataTable dt = CustContactLogic.getCustomerContacts(id);
            ViewBag.custcontacts = dt;
            DataTable dt1 = CustDocLogic.getCustomerDocuments(id);
            ViewBag.custdocs = dt1;
            DataTable dt2 = CustScheduleLogic.getCustomerSchedule(id);
            ViewBag.custschedule = dt2;
            return View(c);
        }
        public ActionResult CustContactDelete()
        {
            int CustContactID = Convert.ToInt32(Request.Params["CustContactID"]);
            int CustomerID = Convert.ToInt32(Request.Params["CustomerID"]);
            CustContactLogic.Delete(CustContactID);
            return RedirectToAction("Customerdetails", new { CustomerID = CustomerID });
        }
        public ActionResult CustDocDelete()
        {
            int CustDocID = Convert.ToInt32(Request.Params["CustDocID"]);
            int CustomerID = Convert.ToInt32(Request.Params["CustomerID"]);
            CustDocLogic.Delete(CustDocID);
            return RedirectToAction("Customerdetails", new { CustomerID = CustomerID });
        }
        public ActionResult CustScheduleDelete()
        {
            int CustContactID = Convert.ToInt32(Request.Params["CustContactID"]);
            CustScheduleLogic.Delete(CustContactID);
            return RedirectToAction("Customerdetails");
        }
        [HttpPost]
        public ActionResult CustomerContactNewSubmit()
        {
            CustContact cc = new CustContact();
            cc.Name = Request.Params["Name"];
            cc.Email = Request.Params["Email"];
            cc.Mobile = Request.Params["Mobile"];
            cc.Purpose = Request.Params["Purpose"];
            cc.CustomerID = Convert.ToInt32(Request.Params["CustomerID"]);
            CustContactLogic.Insert(cc);
            return RedirectToAction("Customerdetails", new { CustomerID = cc.CustomerID });
        }
        [HttpPost]
        public ActionResult CustomerDocNewSubmit()
        {
            CustDoc cd = new CustDoc();
            cd.DocTitle = Request.Params["DocTitle"];
            cd.DocFile = Request.Params["DocFile"];
            cd.DocRemarks = Request.Params["DocRemarks"];
            cd.IssueDate = Convert.ToDateTime(Request.Params["IssueDate"]);
            cd.DueDate = Convert.ToDateTime(Request.Params["DueDate"]);
            cd.CustomerID = Convert.ToInt32(Request.Params["CustomerID"]);
            CustDocLogic.Insert(cd);
            return RedirectToAction("Customerdetails", new { CustomerID = cd.CustomerID });
        }
        //[HttpPost]
        //public ActionResult CustomerScheduleNewSubmit()
        //{

        //    //  return RedirectToAction("Customerdetails", new { CustomerID = cd.CustomerID });
        //    return View();
        //}
    }
}