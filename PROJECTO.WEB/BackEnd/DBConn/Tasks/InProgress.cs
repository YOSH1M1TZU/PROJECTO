using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PROJECTO.WEB.BackEnd.DBConn
{
    public class InProgress
    {
        public MySqlConnection conn;

        public InProgress()
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

        public List<string> LoadInProgress(string projectID)
        {
            try
            {
                var result = new List<string>();

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "SELECT * FROM projecto.inprogress WHERE projectID='" + projectID + "'";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader.GetString("inprogressTitle"));
                    result.Add(reader.GetString("inprogressDesc"));
                }

                if (result != null) return result;
                else
                {
                    result.Add("Error");
                    return result;
                }
            }
            catch (MySqlException ex)
            {
                var result = new List<string>();
                result.Add(ex.ToString());
                return result;
            }
        }

        public string AddInProgress(string title, string desc, string projectID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "INSERT INTO projecto.inprogress (inprogressTitle, inprogressDesc, projectID) VALUES ('" + title + "', '" + desc + "', '" + projectID + "');";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                return "OK";
            }
            catch (MySqlException ex) { return ex.ToString(); }
        }

        public string EditInProgress(string oldTitle, string newTitle, string newDesc, string projectID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "UPDATE projecto.inprogress SET inprogressDesc='" + newDesc + "' WHERE inprogressTitle='" + oldTitle + "' AND projectID='" + projectID + "'";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.CommandTimeout = 40;
                cmd2.CommandText = "UPDATE projecto.inprogress SET inprogressTitle='" + newTitle + "' WHERE inprogressTitle='" + oldTitle + "' AND projectID='" + projectID + "'";
                cmd2.Connection = conn;
                cmd2.CommandType = CommandType.Text;
                cmd2.ExecuteNonQuery();
                return "OK";
            }
            catch (MySqlException ex) { return ex.ToString(); }
        }
    }
}