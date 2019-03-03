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
    public class CustContactLogic
    {
        public static int Insert(CustContact cc)
        {
            String query = "Insert into CustContact values(@Name,@Email,@Mobile,@Purpose,@CustomerID)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Name", cc.Name));
            parameters.Add(new SqlParameter("Email", cc.Email));
            parameters.Add(new SqlParameter("Mobile", cc.Mobile));
            parameters.Add(new SqlParameter("Purpose", cc.Purpose));
            parameters.Add(new SqlParameter("CustomerID", cc.CustomerID));
            return DBHelper.ModifyData(query, parameters);
        }

        public static int Update(CustContact cc)
        {
            string query = "UPDATE CustContact SET Name = @Name, Email = @Email, Mobile = @Mobile, Purpose = @Purpose, CustomerID = @CustomerID where CustContactID=@CustContactID " ;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Name", cc.Name));
            parameters.Add(new SqlParameter("Email", cc.Email));
            parameters.Add(new SqlParameter("Mobile", cc.Mobile));
            parameters.Add(new SqlParameter("Purpose", cc.Purpose));
            parameters.Add(new SqlParameter("CustomerID", cc.CustomerID));
            parameters.Add(new SqlParameter("CustContactID", cc.CustContactID));

            return DBHelper.ModifyData(query, parameters);
        }

        public static int Delete(int ID)
        {
            String query = "Delete from CustContact where CustContactID=@CustContactID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CustContactID", ID));
            return DBHelper.ModifyData(query, parameters);
        }
        public static CustContact SelectByPK(int ID)
        {
            string query = "SELECT * FROM CustContact WHERE CustContactID = @ID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("ID", ID));
            DataTable dt = DBHelper.SelectData(query, parameters);

            CustContact c = new CustContact();
            c.CustContactID = ID;
            c.Name = dt.Rows[0]["Name"].ToString();
            c.Email = dt.Rows[0]["Email"].ToString();
            c.Mobile = dt.Rows[0]["Mobile"].ToString();
            c.Purpose = dt.Rows[0]["Purpose"].ToString();
            c.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());

            return c;
        }
        public static DataTable SelectALL()
        {
            string query = "SELECT * FROM CustContact";
            List<SqlParameter> parameters = new List<SqlParameter>();
            return DBHelper.SelectData(query, parameters);
        }
        public static DataTable getCustomerContacts(int ID)
        {
            String query = "Select * from CustContact where CustomerID=@CustomerID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CustomerID", ID));
            DataTable dt = DBHelper.SelectData(query, parameters);
            return dt;
        }
    }
}