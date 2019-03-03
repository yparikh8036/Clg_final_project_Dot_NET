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
    public class BillLogic
    {
        public static int Insert(Bill bl)
        {
            String query = "Insert into Bill values(@CustomerID,@EmployeeID,@Title,@Amount,@BillDoc,@Status)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CustomerID", bl.CustomerID));
            parameters.Add(new SqlParameter("EmployeeID", bl.EmployeeID));
            parameters.Add(new SqlParameter("Title", bl.Title));
            parameters.Add(new SqlParameter("Amount", bl.Amount));
            parameters.Add(new SqlParameter("BillDoc", bl.BillDoc));
            parameters.Add(new SqlParameter("Status", bl.Status));
            return DBHelper.ModifyData(query, parameters);
        }

        public static int Update(Bill bl)
        {
            String query = "Update Bill set CustomerID=@CustomerID,EmployeeID=@EmployeeID,Title=@Title,Amount=@Amount,BillDoc=@BillDoc,Status=@Status where BillID=@BillID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CustomerID", bl.CustomerID));
            parameters.Add(new SqlParameter("EmployeeID", bl.EmployeeID));
            parameters.Add(new SqlParameter("Title", bl.Title));
            parameters.Add(new SqlParameter("Amount", bl.Amount));
            parameters.Add(new SqlParameter("BillDoc", bl.BillDoc));
            parameters.Add(new SqlParameter("Status", bl.Status));
            parameters.Add(new SqlParameter("BillID", bl.BillID));
            return DBHelper.ModifyData(query, parameters);
        }

        public static int Delete(int ID)
        {
            String query = "Delete from Bill Where BillID=@BillID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("BillID", ID));
            return DBHelper.ModifyData(query, parameters);
        }

        public static Bill SelectByPK(int ID)
        {
            string query = "SELECT * FROM Bill WHERE BillID = @ID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("ID", ID));
            DataTable dt = DBHelper.SelectData(query, parameters);

            Bill bl = new Bill();
            bl.BillID = ID;
            bl.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());
            bl.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"].ToString());
            bl.Title = dt.Rows[0]["Title"].ToString();
            bl.Amount = dt.Rows[0]["Amount"].ToString();
            bl.BillDoc = dt.Rows[0]["BillDoc"].ToString();
            bl.Status = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
            return bl;
        }

        public static DataTable SelectALL()
        {
            string query = "SELECT * FROM Bill";
            List<SqlParameter> parameters = new List<SqlParameter>();
            return DBHelper.SelectData(query, parameters);
        }
    }
}