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
    public class CustAccDocLogic
    {
        public static int Insert(CustAccDoc cad)
        {
            String query = "Insert into CustAccDoc values(@CustomerID,@DocFile,@DocDate)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CustomerID", cad.CustomerID));
            parameters.Add(new SqlParameter("DocFile", cad.DocFile));
            parameters.Add(new SqlParameter("DocDate", cad.DocDate));
            return DBHelper.ModifyData(query, parameters);
        }

        public static int Update(CustAccDoc cad)
        {
            String query = "Update CustAccDoc set CustomerID=@CustomerID,DocFile=@DocFile,DocDate=@DocDate where CustAccDocID=@CustAccDocID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CustomerID", cad.CustomerID));
            parameters.Add(new SqlParameter("DocFile", cad.DocFile));
            parameters.Add(new SqlParameter("DocDate", cad.DocDate));
            parameters.Add(new SqlParameter("CustAccDocID", cad.CustAccDocID));
            return DBHelper.ModifyData(query, parameters);
        }

        public static int Delete(int ID)
        {
            String query = "Delete from CustAccDoc Where CustAccDocID=@CustAccDocID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CustAccDocID", ID));
            return DBHelper.ModifyData(query, parameters);
        }

        public static CustAccDoc SelectByPK(int ID)
        {
            string query = "SELECT * FROM CustAccDoc WHERE CustAccDocID = @ID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("ID", ID));
            DataTable dt = DBHelper.SelectData(query, parameters);

            CustAccDoc cad = new CustAccDoc();
            cad.CustAccDocID = ID;
            cad.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());
            cad.DocFile = dt.Rows[0]["DocFile"].ToString();
            cad.DocDate = Convert.ToDateTime(dt.Rows[0]["DocDate"].ToString());
            return cad;
        }

        public static DataTable SelectALL()
        {
            string query = "SELECT * FROM CustAccDoc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            return DBHelper.SelectData(query, parameters);
        }
    }
}