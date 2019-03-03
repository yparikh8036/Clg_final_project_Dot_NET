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
    public class Worklogic
    {
        public static int Insert(Work w)
        {
            String query = "Insert into Work values(@CreatorID,@AssignedID,@Title,@Description,@CreateDate,@DueDate,@Status,@CompletionDate,@CompletionRemarks)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CreatorID", w.CreatorID));
            parameters.Add(new SqlParameter("AssignedID", w.AssignedID));
            parameters.Add(new SqlParameter("Title", w.Title));
            parameters.Add(new SqlParameter("Description", w.Description));
            parameters.Add(new SqlParameter("CreateDate", w.CreateDate));
            parameters.Add(new SqlParameter("DueDate", w.DueDate));
            parameters.Add(new SqlParameter("Status", w.Status));
            parameters.Add(new SqlParameter("CompletionDate", w.CompletionDate));
            parameters.Add(new SqlParameter("CompletionRemarks", w.CompletionRemarks));
            return DBHelper.ModifyData(query, parameters);
        }

        public static int Update(Work w)
        {
            String query = "Update Work set CreatorID=@CreatorID,Assigned=@AssignedID,Title=@Title,Description=@Description,CreateDate=@CreateDate,DueDate=@DueDate,Statu=@Status,CompletionDate=@CompletionDate,CompletionRemarks=@CompletionRemarks where WorkID=@WorkID)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CreatorID", w.CreatorID));
            parameters.Add(new SqlParameter("AssignedID", w.AssignedID));
            parameters.Add(new SqlParameter("Title", w.Title));
            parameters.Add(new SqlParameter("Description", w.Description));
            parameters.Add(new SqlParameter("CreateDate", w.CreateDate));
            parameters.Add(new SqlParameter("DueDate", w.DueDate));
            parameters.Add(new SqlParameter("Status", w.Status));
            parameters.Add(new SqlParameter("CompletionDate", w.CompletionDate));
            parameters.Add(new SqlParameter("CompletionRemarks", w.CompletionRemarks));
            parameters.Add(new SqlParameter("WorkID", w.WorkID));
            return DBHelper.ModifyData(query, parameters);
        }

        public static int Delete(int ID)
        {
            String query = "Delete from Work Where WorkID=@WorkID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("WorkID", ID));
            return DBHelper.ModifyData(query, parameters);
        }

        public static Work SelectByPK(int ID)
        {
            string query = "SELECT * FROM Work WHERE WorkID = @ID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("ID", ID));
            DataTable dt = DBHelper.SelectData(query, parameters);

            Work w= new Work();
            w.WorkID = ID;
            w.CreatorID = Convert.ToInt32(dt.Rows[0]["CreatorID"].ToString());
            w.AssignedID = Convert.ToInt32(dt.Rows[0]["AssignedID"].ToString());
            w.Title = dt.Rows[0]["Title"].ToString();
            w.Description = dt.Rows[0]["Description"].ToString();
            w.CreateDate = Convert.ToDateTime(dt.Rows[0]["CreateDate"].ToString());
            w.DueDate = Convert.ToDateTime(dt.Rows[0]["DueDate"].ToString());
            w.Status = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
            w.CompletionDate = Convert.ToDateTime(dt.Rows[0]["CompletionDate"].ToString());
            w.CompletionRemarks = dt.Rows[0]["CompletionRemarks"].ToString();
            return w;
        }

        public static DataTable SelectALL()
        {
            string query = "SELECT * FROM Work";
            List<SqlParameter> parameters = new List<SqlParameter>();
            return DBHelper.SelectData(query, parameters);
        }
    }
}