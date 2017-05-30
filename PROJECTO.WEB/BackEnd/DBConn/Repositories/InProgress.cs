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
                    result.Add(reader.GetString("inprogressCategory"));
                }
                cmd.Dispose();
                reader.Close();

                if (result != null) return result;
                else
                {
                    result.Add("ERR");
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

        ~InProgress()
        {
            conn.Close();
        }
    }
}