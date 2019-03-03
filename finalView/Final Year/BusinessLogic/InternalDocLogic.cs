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
    public class InternalDocLogic
    {
        public static int Insert(InternalDoc id)
        {
            String query = "Insert into InternalDoc values(@DocTitle,@DocFile,@DocRemarks,@IssueDate,@DueDate,@EmployeeID)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("DocTitle",id.DocTitle));
            parameters.Add(new SqlParameter("DocFile",id.DocFile));
            parameters.Add(new SqlParameter("DocRemarks",id.DocRemarks));
            parameters.Add(new SqlParameter("IssueDate",id.IssueDate));
            parameters.Add(new SqlParameter("DueDate",id.DueDate));
            parameters.Add(new SqlParameter("EmployeeID", id.EmployeeID));
            return DBHelper.ModifyData(query, parameters);
        }

        public static int Update(InternalDoc id)
        {
            string query = "UPDATE InternalDoc SET DocTitle = @DocTitle, DocFile = @DocFile, DocRemarks = @DocRemarks, IssueDate = @IssueDate,DueDate = @DueDate, EmployeeID = @EmployeeID where InternalDocID=@InternalDocID ";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("DocTitle",id.DocTitle));
            parameters.Add(new SqlParameter("DocFile",id.DocFile));
            parameters.Add(new SqlParameter("DocRemarks",id.DocRemarks));
            parameters.Add(new SqlParameter("IssueDate",id.IssueDate));
            parameters.Add(new SqlParameter("DueDate",id.DueDate));
            parameters.Add(new SqlParameter("EmployeeID", id.EmployeeID));
            parameters.Add(new SqlParameter("InternalDocID", id.InternalDocID));

            return DBHelper.ModifyData(query, parameters);
        }

        public static int Delete(int ID)
        {
            String query = "Delete InternalDoc where InternalDocID=@InternalDocID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("InternalDocID", ID));
            return DBHelper.ModifyData(query, parameters);
        }
        public static InternalDoc SelectByPK(int ID)
        {
            string query = "SELECT * FROM InternalDoc WHERE InternalDocID = @ID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("ID", ID));
            DataTable dt = DBHelper.SelectData(query, parameters);

           InternalDoc id = new InternalDoc();
           id.InternalDocID = ID;
           id.DocTitle = dt.Rows[0]["DocTitle"].ToString();
           id.DocFile = dt.Rows[0]["DocFile"].ToString();
           id.DocRemarks = dt.Rows[0]["DocRemarks"].ToString();
           id.IssueDate = Convert.ToDateTime(dt.Rows[0]["IssueDate"].ToString());
           id.DueDate = Convert.ToDateTime(dt.Rows[0]["DueDate"].ToString());
           id.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"].ToString());

            return id;
        }
        public static DataTable SelectALL()
        {
            string query = "SELECT * FROM InternalDoc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            return DBHelper.SelectData(query, parameters);
        }
    }
}