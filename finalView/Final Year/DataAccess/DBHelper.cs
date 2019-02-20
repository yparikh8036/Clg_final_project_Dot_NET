using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final_Year.DataAccess
{
    public class DBHelper
    {
        public static int ModifyData(string query, List<SqlParameter> parameters)
        {
            SqlConnection connection = new SqlConnection();
              connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            // connection.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectry|Database1.mdf';Integrated Security=True";
            SqlCommand command = new SqlCommand(query, connection);
            for (int i = 0; i < parameters.Count; i++)
            {
                if (parameters[i].Value == null)
                {
                    parameters[i].Value = DBNull.Value;
                }

                command.Parameters.Add(parameters[i]);
            }
            connection.Open();
            int x = command.ExecuteNonQuery();
            connection.Close();

            return x;
        }

        public static DataTable SelectData(string query, List<SqlParameter> parameters)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlCommand command = new SqlCommand(query, connection);
            for (int i = 0; i < parameters.Count; i++)
            {
                if (parameters[i].Value == null)
                {
                    parameters[i].Value = DBNull.Value;
                }

                command.Parameters.Add(parameters[i]);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            connection.Open();
            adapter.Fill(dt);
            connection.Close();

            return dt;
        }
    }
}