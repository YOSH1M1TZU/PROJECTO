using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PROJECTO.WEB.BackEnd.DBConn
{
    public class TasksMain
    {
        public MySqlConnection conn;

        public TasksMain()
        {
            string myConnectionString;

            myConnectionString = "server=127.0.0.1;Port=3310;uid=AdminTester;pwd=AdminPassword123$;database=projecto;";

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySqlException ex) { }
        }

        public string MoveTask(string from, string to, string taskTitle, string taskDesc, string taskCategory, string projectID)
        {
            try
            {
                string result = null;

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "INSERT INTO projecto." + to + " (" + to + "Title, " + to + "Desc, projectID, " + to + "Category) VALUES ('" + taskTitle + "', '" + taskDesc + "', '" + projectID + "', '" + taskCategory + "');";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.CommandTimeout = 40;
                cmd2.CommandText = "DELETE FROM projecto." + from + " WHERE projectID='" + projectID + "' AND " + from + "Title='" + taskTitle + "';";
                cmd2.Connection = conn;
                cmd2.CommandType = CommandType.Text;
                cmd2.ExecuteNonQuery();

                result = "OK";

                if (result != null) return result;
                else
                {
                    return result;
                }
            }
            catch (MySqlException ex)
            {
                return "ERR";
            }
        }
    }
}