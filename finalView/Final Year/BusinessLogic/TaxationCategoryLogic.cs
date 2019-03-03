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
    public class TaxationCategoryLogic
    {
        public static int Insert(TaxationCategory tc)
        {
            String query = "Insert into TaxationCategory values(@CatName)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CatName", tc.CatName));
            return DBHelper.ModifyData(query, parameters);
        }

        public static int Update(TaxationCategory tc)
        {
            String query = "Update TaxationCategory set CatName=@CatName where TaxationCategoryID=@TaxationCategoryID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CatName", tc.CatName));
            parameters.Add(new SqlParameter("TaxationCategoryID", tc.TaxationCategoryID));
            return DBHelper.ModifyData(query, parameters);
        }

        public static int Delete(int ID)
        {
            String query = "Delete TaxationCategory where TaxationCategoryID=@TaxationCategoryID ";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("TaxationCategoryID", ID));
            return DBHelper.ModifyData(query, parameters);
        }

        public static TaxationCategory SelectByPK(int ID)
        {
            string query = "SELECT * FROM TaxationCategory WHERE TaxationCategoryID = @ID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("ID", ID));
            DataTable dt = DBHelper.SelectData(query, parameters);

            TaxationCategory tc = new TaxationCategory();
            if(dt.Rows.Count>0)
            {
                tc.TaxationCategoryID = ID;
                tc.CatName = dt.Rows[0]["CatName"].ToString();
            }
            return tc;
        }

        public static DataTable SelectALL()
        {
            string query = "SELECT * FROM TaxationCategory";
            List<SqlParameter> parameters = new List<SqlParameter>();
            return DBHelper.SelectData(query, parameters);
        }
    }
}