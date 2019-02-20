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
    public class CustomerLogic
    {
        public static int Insert(Customer c)
        {
            String query = "insert into Customer values(@Name,@Email,@Mobile,@Address,@Username,@Password,@IsActive,@AccName,@AccUsername,@AccPassword,@DOB,@PAN,@GSTIN,@EmployeeID) ";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Name", c.Name));
            parameters.Add(new SqlParameter("@Email", c.Email));
            parameters.Add(new SqlParameter("@Mobile", c.Mobile));
            parameters.Add(new SqlParameter("@Address", c.Address));
            parameters.Add(new SqlParameter("@Username", c.Username));
            parameters.Add(new SqlParameter("@Password", c.Password));
            parameters.Add(new SqlParameter("@IsActive", c.IsActive));
            parameters.Add(new SqlParameter("@AccName", c.AccName));
            parameters.Add(new SqlParameter("@AccUsername", c.AccUsername));
            parameters.Add(new SqlParameter("@AccPassword", c.AccPassword));
            parameters.Add(new SqlParameter("@DOB", c.DOB));
            parameters.Add(new SqlParameter("@PAN", c.PAN));
            parameters.Add(new SqlParameter("@GSTIN", c.GSTIN));
            parameters.Add(new SqlParameter("@EmployeeID", c.EmployeeID));

            return DBHelper.ModifyData(query, parameters);
        }
        public static int Update(Customer c)
        {
            string query = "UPDATE Customer SET Name = @Name, Email = @Email, Mobile = @Mobile, Address = @Address, Username = @Username, Password = @Password, IsActive = @IsActive, AccName = @AccName, AccUsername = @AccUsername, AccPassword = @AccPassword, DOB = @DOB, PAN = @PAN, GSTIN = @GSTIN, EmployeeID = @EmployeeID WHERE CustomerID = @CustomerID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Name", c.Name));
            parameters.Add(new SqlParameter("@Email", c.Email));
            parameters.Add(new SqlParameter("@Mobile", c.Mobile));
            parameters.Add(new SqlParameter("@Address", c.Address));
            parameters.Add(new SqlParameter("@Username", c.Username));
            parameters.Add(new SqlParameter("@Password", c.Password));
            parameters.Add(new SqlParameter("@IsActive", c.IsActive));
            parameters.Add(new SqlParameter("@AccName", c.AccName));
            parameters.Add(new SqlParameter("@AccUsername", c.AccUsername));
            parameters.Add(new SqlParameter("@AccPassword", c.AccPassword));
            parameters.Add(new SqlParameter("@DOB", c.DOB));
            parameters.Add(new SqlParameter("@PAN", c.PAN));
            parameters.Add(new SqlParameter("@GSTIN", c.GSTIN));
            parameters.Add(new SqlParameter("@EmployeeID", c.EmployeeID));
            parameters.Add(new SqlParameter("@CustomerID", c.CustomerID));

            return DBHelper.ModifyData(query, parameters);
        }
        public static int Delete(int CustomerID)
        {
            String query = "Delete Customer where CustomerID=@CustomerID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CustomerID", CustomerID));
            return DBHelper.ModifyData(query, parameters);
        }
        public static Customer SelectByPK(int ID)
        {
            string query = "SELECT * FROM Customer WHERE CustomerID = @ID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", ID));
            DataTable dt = DBHelper.SelectData(query, parameters);

            Customer c = new Customer();
            c.CustomerID = ID;
            c.Name = dt.Rows[0]["Name"].ToString();
            c.Email= dt.Rows[0]["Email"].ToString();
            c.Mobile= dt.Rows[0]["Mobile"].ToString();
            c.Address=dt.Rows[0]["Address"].ToString();
            c.Username= dt.Rows[0]["Username"].ToString();
            c.Password= dt.Rows[0]["Password"].ToString();
            c.IsActive= Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());
            c.AccName= dt.Rows[0]["AccName"].ToString();
            c.AccUsername= dt.Rows[0]["AccUsername"].ToString();
            c.AccPassword= dt.Rows[0]["AccPassword"].ToString();
            c.DOB= Convert.ToDateTime(dt.Rows[0]["DOB"].ToString());
            c.PAN= dt.Rows[0]["PAN"].ToString();
            c.GSTIN= dt.Rows[0]["GSTIN"].ToString();
            c.EmployeeID= Convert.ToInt32(dt.Rows[0]["EmployeeID"].ToString());

            return c;
        }
        public static DataTable SelectALL()
        {
            string query = "SELECT * FROM Customer";
            List<SqlParameter> parameters = new List<SqlParameter>();
            return DBHelper.SelectData(query, parameters);
        }
        public static Customer SelectByUnPs(String Username, String Password)
        {
            String query= "SELECT * FROM Customer WHERE Username = @Username AND Password = @Password";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Username", Username));
            parameters.Add(new SqlParameter("@Password", Password));
            DataTable dt = DBHelper.SelectData(query, parameters);

            Customer c = new Customer();
            if(dt.Rows.Count > 0)
            {
                c.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());
                c.Name = dt.Rows[0]["Name"].ToString();
                c.Email = dt.Rows[0]["Email"].ToString();
                c.Mobile = dt.Rows[0]["Mobile"].ToString();
                c.Address = dt.Rows[0]["Address"].ToString();
                c.Username = dt.Rows[0]["Username"].ToString();
                c.Password = dt.Rows[0]["Password"].ToString();
                c.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());
                c.AccName = dt.Rows[0]["AccName"].ToString();
                c.AccUsername = dt.Rows[0]["AccUsername"].ToString();
                c.AccPassword = dt.Rows[0]["AccPassword"].ToString();
                c.DOB = Convert.ToDateTime(dt.Rows[0]["DOB"].ToString());
                c.PAN = dt.Rows[0]["PAN"].ToString();
                c.GSTIN = dt.Rows[0]["GSTIN"].ToString();
                c.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"].ToString());
            }
            return c;
        }
        public static DataTable getHomeDetails(int CustomerID)
        {
            String query = "select s.Sname,cs.StartDate,cs.EndDate,e.Name from Service s Inner Join CustomerService cs on s.ServiceID = cs.ServiceID Inner Join Employee e on s.EmployeeID=e.EmployeeID where cs.CustomerID=@CustomerID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CustomerID", CustomerID));
            DataTable dt = DBHelper.SelectData(query, parameters);
            return dt;

        }
    }
}