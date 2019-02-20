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
    public class CustScheduleLogic
    {
        public static int Insert(CustSchedule cs)
        {
            String query = "Insert into CustSchedule values(@CustomerServiceID,@DueDate,@Requirements,@Status,@ActualDate,@DocFile)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CustomerServiceID",cs.CustomerServiceID));
            parameters.Add(new SqlParameter("@DueDate",cs.DueDate));
            parameters.Add(new SqlParameter("@Requirements",cs.Requirements));
            parameters.Add(new SqlParameter("@Status",cs.Status));
            parameters.Add(new SqlParameter("@ActualDate",cs.ActualDate));
            parameters.Add(new SqlParameter("@DocFile",cs.DocFile));
            return DBHelper.ModifyData(query, parameters);
        }

        public static int Update(CustSchedule cs)
        {
            string query = "UPDATE CustSchedule SET CustomerServiceID = @CustomerServiceID, DueDate = @DueDate, Requirements = @Requirements, Status = @Status,ActualDate = @ActualDate, DocFile = @DocFile where CustScheduleID=@CustScheduleID ";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CustomerServiceID", cs.CustomerServiceID));
            parameters.Add(new SqlParameter("@DueDate", cs.DueDate));
            parameters.Add(new SqlParameter("@Requirements", cs.Requirements));
            parameters.Add(new SqlParameter("@Status", cs.Status));
            parameters.Add(new SqlParameter("@ActualDate", cs.ActualDate));
            parameters.Add(new SqlParameter("@DocFile", cs.DocFile));
          //  parameters.Add(new SqlParameter("@CustScheduleID", cs.CustScheduleID));

            return DBHelper.ModifyData(query, parameters);
        }

        public static int Delete(int ID)
        {
            String query = "Delete CustSchedule where CustScheduleID=@CustScheduleID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CustScheduleID", ID));
            return DBHelper.ModifyData(query, parameters);
        }
        public static CustSchedule SelectByPK(int ID)
        {
            string query = "SELECT * FROM CustSchedule WHERE CustScheduleID = @ID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", ID));
            DataTable dt = DBHelper.SelectData(query, parameters);

            CustSchedule cs = new CustSchedule();
           cs.CustomerServiceID = Convert.ToInt32(dt.Rows[0]["CustomerServiceID"].ToString());
           cs.DueDate = Convert.ToDateTime(dt.Rows[0]["DueDate"].ToString());
           cs.Requirements = dt.Rows[0]["Requirements"].ToString();
           cs.Status = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
           cs.ActualDate = Convert.ToDateTime(dt.Rows[0]["ActualDate"].ToString());
           cs.DocFile = dt.Rows[0]["DocFile"].ToString();

            return cs;
        }
        public static DataTable SelectALL()
        {
            string query = "SELECT * FROM CustSchedule";
            List<SqlParameter> parameters = new List<SqlParameter>();
            return DBHelper.SelectData(query, parameters);
        }
    }
}