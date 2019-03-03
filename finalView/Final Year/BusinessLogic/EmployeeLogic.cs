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
    public class EmployeeLogic
    {
        public static int Insert(Employee e)
        {
            String query = "insert into Employee values(@Name,@Email,@Mobile,@Address,@Username,@Password,@IsActive,@EmployeeRole,@Photo) ";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Name",e.Name));
            parameters.Add(new SqlParameter("Email",e.Email));
            parameters.Add(new SqlParameter("Mobile",e.Mobile));
            parameters.Add(new SqlParameter("Address",e.Address));
            parameters.Add(new SqlParameter("Username",e.Username));
            parameters.Add(new SqlParameter("Password",e.Password));
            parameters.Add(new SqlParameter("IsActive",e.IsActive));
            parameters.Add(new SqlParameter("EmployeeRole",e.EmployeeRole));
            parameters.Add(new SqlParameter("Photo",e.Photo));
            return DBHelper.ModifyData(query, parameters);
        }

        public static int Update(Employee e)
        {
            string query = "UPDATE Employee SET Name = @Name, Email = @Email, Mobile = @Mobile, Address = @Address, Username = @Username, Password = @Password, IsActive = @IsActive, EmployeeRole = @EmployeeRole,Photo=@Photo where EmployeeID=@EmployeeID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Name", e.Name));
            parameters.Add(new SqlParameter("Email", e.Email));
            parameters.Add(new SqlParameter("Mobile", e.Mobile));
            parameters.Add(new SqlParameter("Address", e.Address));
            parameters.Add(new SqlParameter("Username", e.Username));
            parameters.Add(new SqlParameter("Password", e.Password));
            parameters.Add(new SqlParameter("IsActive", e.IsActive));
            parameters.Add(new SqlParameter("EmployeeRole", e.EmployeeRole));
            parameters.Add(new SqlParameter("Photo", e.Photo));
            parameters.Add(new SqlParameter("EmployeeID", e.EmployeeID));
            return DBHelper.ModifyData(query, parameters);
        }

        public static int Delete(int ID)
        {
            String query = "Delete from Employee where EmployeeID=@ID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("ID", ID));
            return DBHelper.ModifyData(query, parameters);
        }

        public static Employee SelectByPK(int ID)
        {
            string query = "SELECT * FROM Employee WHERE EmployeeID = @ID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("ID", ID));
            DataTable dt = DBHelper.SelectData(query, parameters);

            Employee e = new Employee();
            e.EmployeeID = ID;
            e.Name = dt.Rows[0]["Name"].ToString();
            e.Email= dt.Rows[0]["Email"].ToString();
            e.Mobile= dt.Rows[0]["Mobile"].ToString();
            e.Address= dt.Rows[0]["Address"].ToString();
            e.Username= dt.Rows[0]["Username"].ToString();
            e.Password= dt.Rows[0]["Password"].ToString();
            e.IsActive= Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());
            e.EmployeeRole= dt.Rows[0]["EmployeeRole"].ToString();
            e.Photo= dt.Rows[0]["Photo"].ToString();
            return e;

        }
        public static DataTable SelectALL()
        {
            string query = "SELECT * FROM Employee";
            List<SqlParameter> parameters = new List<SqlParameter>();
            return DBHelper.SelectData(query, parameters);
        }

        public static Employee SelectByUnPs(String Username, String Password)
        {
            String query = "SELECT * FROM Employee WHERE Username = @Username AND Password = @Password";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Username", Username));
            parameters.Add(new SqlParameter("Password", Password));
            DataTable dt = DBHelper.SelectData(query, parameters);

            Employee e = new Employee();
            if (dt.Rows.Count > 0)
            {
                e.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"].ToString());
                e.Name = dt.Rows[0]["Name"].ToString();
                e.Email = dt.Rows[0]["Email"].ToString();
                e.Mobile = dt.Rows[0]["Mobile"].ToString();
                e.Address = dt.Rows[0]["Address"].ToString();
                e.Username = dt.Rows[0]["Username"].ToString();
                e.Password = dt.Rows[0]["Password"].ToString();
                e.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());
                e.EmployeeRole = dt.Rows[0]["EmployeeRole"].ToString();
                e.Photo = dt.Rows[0]["Photo"].ToString();
            }
            return e;
        }
        public static Boolean CheckEmail(String Email)
        {
            String query = "Select * from Employee  where Email=@Email";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Email", Email));
            DataTable dt = DBHelper.SelectData(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}