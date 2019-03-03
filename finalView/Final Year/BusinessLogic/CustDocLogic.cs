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
    public class CustDocLogic
    {
        public static int Insert(CustDoc cd)
        {
            String query = "Insert into CustDoc values(@DocTitle,@DocFile,@DocRemarks,@IssueDate,@DueDate,@CustomerID)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("DocTitle", cd.DocTitle));
            parameters.Add(new SqlParameter("DocFile", cd.DocFile));
            parameters.Add(new SqlParameter("DocRemarks", cd.DocRemarks));
            parameters.Add(new SqlParameter("IssueDate", cd.IssueDate));
            parameters.Add(new SqlParameter("DueDate", cd.DueDate));
            parameters.Add(new SqlParameter("CustomerID",cd.CustomerID));
            return DBHelper.ModifyData(query, parameters);
        }

        public static int Update(CustDoc cd)
        {
            string query = "UPDATE CustDoc SET DocTitle = @DocTitle, DocFile = @DocFile, DocRemarks = @DocRemarks, IssueDate = @IssueDate,DueDate = @DueDate, CustomerID = @CustomerID where CustDocID=@CustDocID ";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("DocTitle", cd.DocTitle));
            parameters.Add(new SqlParameter("DocFile", cd.DocFile));
            parameters.Add(new SqlParameter("DocRemarks", cd.DocRemarks));
            parameters.Add(new SqlParameter("IssueDate", cd.IssueDate));
            parameters.Add(new SqlParameter("DueDate", cd.DueDate));
            parameters.Add(new SqlParameter("CustomerID",cd.CustomerID));
            parameters.Add(new SqlParameter("CustDocID", cd.CustDocID));

            return DBHelper.ModifyData(query, parameters);
        }

        public static int Delete(int ID)
        {
            String query = "Delete CustDoc where CustDocID=@CustDocID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CustDocID", ID));
            return DBHelper.ModifyData(query, parameters);
        }
        public static CustDoc SelectByPK(int ID)
        {
            string query = "SELECT * FROM CustDoc WHERE CustDocID = @ID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("ID", ID));
            DataTable dt = DBHelper.SelectData(query, parameters);

            CustDoc cd = new CustDoc();
            cd.CustDocID = ID;
            cd.DocTitle = dt.Rows[0]["DocTitle"].ToString();
            cd.DocFile = dt.Rows[0]["DocFile"].ToString();
            cd.DocRemarks = dt.Rows[0]["DocRemarks"].ToString();
            cd.IssueDate = Convert.ToDateTime(dt.Rows[0]["IssueDate"].ToString());
            cd.DueDate = Convert.ToDateTime(dt.Rows[0]["DueDate"].ToString());
            cd.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());

            return cd;
        }
        public static DataTable SelectALL()
        {
            string query = "SELECT * FROM CustDoc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            return DBHelper.SelectData(query, parameters);
        }
        public static DataTable getCustomerDocuments(int ID)
        {
            String query = "SELECT * FROM CustDoc where CustomerID=@CustomerID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CustomerID", ID));
            DataTable dt = DBHelper.SelectData(query, parameters);
            return dt;
        }
    }
}