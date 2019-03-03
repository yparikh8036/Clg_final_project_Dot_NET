using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using Final_Year.DataAccess;
using Final_Year.Models;

namespace TaxConsultantAutomation2018.BusinessLogic
{
    public class TaxationUpdateLogic
    {
        public static int Insert(TaxationUpdate td)
        {
            String query = "Inseert into TaxationUpdate values(@TaxationCategoryID,@Title,@Description,@Photo,@EmployeeID,@CreateDate,@IsActive)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("TaxationCategoryID", td.TaxationCategoryID));
            parameters.Add(new SqlParameter("Title", td.Title));
            parameters.Add(new SqlParameter("Description", td.Description));
            parameters.Add(new SqlParameter("Photo", td.Photo));
          //  parameters.Add(new SqlParameter("@EmployeeID",td.EmployeeID));
            parameters.Add(new SqlParameter("CreateDate", td.CreateDate));
            parameters.Add(new SqlParameter("IsActive", td.IsActive));

            return DBHelper.ModifyData(query, parameters);
        }

        public static int Update(TaxationUpdate td)
        {
            String query = "Update TaxationUpdate set TaxationCategoryID=@TaxationCategoryID,Title=@Title,Description=@Description,Photo=@Photo,EmployeeID=@EmployeeID,CreateDate=@CreateDate,IsActive=@IsActive where TaxationUpdateID=@TaxationUpdateID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("TaxationCategoryID", td.TaxationCategoryID));
            parameters.Add(new SqlParameter("Title", td.Title));
            parameters.Add(new SqlParameter("Description", td.Description));
            parameters.Add(new SqlParameter("Photo", td.Photo));
           // parameters.Add(new SqlParameter("@EmployeeID", td.EmployeeID));
            parameters.Add(new SqlParameter("CreateDate", td.CreateDate));
            parameters.Add(new SqlParameter("IsActive", td.IsActive));
            parameters.Add(new SqlParameter("TaxationUpdateID", td.TaxationUpdateID));
            return DBHelper.ModifyData(query, parameters);
        }

        public static int Delete(int ID)
        {
            String query = "Delete from TaxationUpdate where TaxationUpdateID=@ID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("ID", ID));
            return DBHelper.ModifyData(query, parameters);
        }

        public static TaxationUpdate SelectByPK(int ID)
        {
            string query = "SELECT * FROM TaxationUpdate WHERE TaxationUpdateID = @ID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("ID", ID));
            DataTable dt = DBHelper.SelectData(query, parameters);

            TaxationUpdate td = new TaxationUpdate();
            td.TaxationUpdateID = ID;
            td.TaxationCategoryID = Convert.ToInt32(dt.Rows[0]["TaxationCategoryID"].ToString());
            td.Title= dt.Rows[0]["Title"].ToString();
            td.Description = dt.Rows[0]["Description"].ToString();
            td.Photo = dt.Rows[0]["Photo"].ToString();
            td.CreateDate = Convert.ToDateTime(dt.Rows[0]["CreateDate"].ToString());
          //  td.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"].ToString());
            td.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());
            return td;
        }

        public static DataTable SelectALL()
        {
            string query = "SELECT * FROM TaxationUpdate";
            List<SqlParameter> parameters = new List<SqlParameter>();
            return DBHelper.SelectData(query, parameters);
        }
    }
}