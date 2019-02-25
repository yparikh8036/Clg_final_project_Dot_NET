using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Final_Year.DataAccess;
using Final_Year.Models;

namespace Final_Year.BusinessLogic
{
    public class CustomerServiceLogic
    {
        public static int Insert(CustomerService cs)
        {
            String query = "Insert into CustomerService values(@CustomerID,@ServiceID,@StartDate,@EndDate)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CustomerID", cs.CustomerID));
            parameters.Add(new SqlParameter("@ServiceID", cs.ServiceID));
            parameters.Add(new SqlParameter("@StartDate", cs.StartDate));
            parameters.Add(new SqlParameter("@EndDate", cs.EndDate));
            return DBHelper.ModifyData(query, parameters);
        }

        public static int Update(CustomerService cs)
        {
            String query = "Update CustomerService set CustomerID=@CustomerID,ServiceID=@ServiceID,StartDate=@StartDate,EndDate=@EndDate where CustomerServiceID=@CustomerServiceID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CustomerID", cs.CustomerID));
            parameters.Add(new SqlParameter("@ServiceID", cs.ServiceID));
            parameters.Add(new SqlParameter("@StartDate", cs.StartDate));
            parameters.Add(new SqlParameter("@EndDate", cs.EndDate));
            parameters.Add(new SqlParameter("@CustomerServiceID", cs.CustomerServiceID));
            return DBHelper.ModifyData(query, parameters);
        }

        public static int Delete(int ID)
        {
            String query = "Delete from CustomerService Where CustomerServiceID=@CustomerServiceID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CustomerServiceID", ID));
            return DBHelper.ModifyData(query, parameters);
        }

        public static CustomerService SelectByPK(int ID)
        {
            string query = "SELECT * FROM CustomerService WHERE CustomerServiceID = @ID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", ID));
            DataTable dt = DBHelper.SelectData(query, parameters);

            CustomerService cs = new CustomerService();
            cs.CustomerServiceID = ID;
            cs.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());
            cs.ServiceID = Convert.ToInt32(dt.Rows[0]["ServiceID"].ToString());
            cs.StartDate = Convert.ToDateTime(dt.Rows[0]["StartDate"].ToString());
            cs.EndDate = Convert.ToDateTime(dt.Rows[0]["EndDate"].ToString());
            return cs;
        }

        public static DataTable SelectALL()
        {
            string query = "SELECT * FROM CustomerService";
            List<SqlParameter> parameters = new List<SqlParameter>();
            return DBHelper.SelectData(query, parameters);
        }
        public static DataTable CustomerServiceList()
        {
            String query = "Select cs.CustomerServiceID,cs.StartDate,cs.EndDate,s.Sname,c.Name,cs.CustomerID from CustomerService cs inner Join Customer c on cs.CustomerID=c.CustomerID inner Join Service s on cs.ServiceID=s.ServiceID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            // parameters.Add(new SqlParameter("@CustomerID", CustomerID));
            DataTable dt = DBHelper.SelectData(query, parameters);
            //CustomerService cs = new CustomerService();
            //cs.CustomerServiceID = Convert.ToInt32(dt.Rows[0]["CustomerServiceID"]);
            //cs.CustomerID = CustomerID;
            //cs.ServiceID = Convert.ToInt32(dt.Rows[0]["ServiceID"].ToString());
            //cs.StartDate = Convert.ToDateTime(dt.Rows[0]["StartDate"].ToString());
            //cs.EndDate = Convert.ToDateTime(dt.Rows[0]["EndDate"].ToString());

            return dt;
        }

        public static DataTable CustomerServiceByPKAndCustID(int CustomerID,int CustomerServiceID)
        {
            String query = "Select cs.CustomerServiceID,cs.StartDate,cs.EndDate,s.Sname,c.Name,cs.ServiceID,cs.CustomerID from CustomerService cs left Join Customer c on cs.CustomerID=c.CustomerID left Join Service s on cs.ServiceID=s.ServiceID where cs.CustomerID=@CustomerID and cs.CustomerServiceID=@CustomerServiceID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CustomerID", CustomerID));
            parameters.Add(new SqlParameter("CustomerServiceID", CustomerServiceID));
            DataTable dt = DBHelper.SelectData(query, parameters);
            return dt;
        }
        public static DataTable CustomerServiceByCustID(int CustomerID)
        {
            String query = "Select cs.CustomerServiceID,cs.StartDate,cs.EndDate,s.Sname,c.Name from CustomerService cs inner Join Customer c on cs.CustomerID=c.CustomerID inner Join Service s on cs.ServiceID=s.ServiceID where cs.CustomerID=@CustomerID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CustomerID", CustomerID));
            DataTable dt = DBHelper.SelectData(query, parameters);
            return dt;
        }
    }
}