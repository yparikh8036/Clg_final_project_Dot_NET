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
    public class ServiceLogic
    {
        public static int Insert(Service c)
        {
            String query = "Inseert into Service values(@Sname,@Description,@Requirements,@Documents,@EmployeeID)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Sname",c.Sname));
            parameters.Add(new SqlParameter("@Description",c.Description));
            parameters.Add(new SqlParameter("@Requirements",c.Requirements));
            parameters.Add(new SqlParameter("@Documents",c.Documents));
            parameters.Add(new SqlParameter("@EmployeeID",c.EmployeeID));

            return DBHelper.ModifyData(query, parameters);
        }

        public static int Update(Service c)
        {
            String query = "Update Service set Sname=@Sname,Description=@Description,Requirements=@Requirements,Documents=@Documents,EmployeeID=@EmployeeID where ServiceID=@ServiceID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Sname",c.Sname));
            parameters.Add(new SqlParameter("@Description",c.Description));
            parameters.Add(new SqlParameter("@Requirements",c.Requirements));
            parameters.Add(new SqlParameter("@Documents",c.Documents));
            parameters.Add(new SqlParameter("@EmployeeID",c.EmployeeID));
            parameters.Add(new SqlParameter("@ServiceID", c.ServiceID));
            return DBHelper.ModifyData(query, parameters);
        }

        public static int Delete(int ID)
        {
            String query = "Delete from Service where ServiceID=@ID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", ID));
            return DBHelper.ModifyData(query, parameters);
        }

        public static Service SelectByPK(int ID)
        {
            string query = "SELECT * FROM Service WHERE ServiceID = @ID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", ID));
            DataTable dt = DBHelper.SelectData(query, parameters);

            Service s = new Service();
            s.ServiceID = ID;
            s.Sname = dt.Rows[0]["Sname"].ToString();
            s.Description = dt.Rows[0]["Description"].ToString();
            s.Requirements = dt.Rows[0]["Requirements"].ToString();
            s.Documents = dt.Rows[0]["Documents"].ToString();
            s.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"].ToString());
            return s;
        }

        public static DataTable SelectALL()
        {
            string query = "SELECT * FROM Service";
            List<SqlParameter> parameters = new List<SqlParameter>();
            return DBHelper.SelectData(query, parameters);
        }
    }
}