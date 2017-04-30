using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PROJECTO.WEB.BackEnd.DBConn
{
    public class Projects
    {
        public MySqlConnection conn;

        public Projects()
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

        public List<string> LoadProjects(string userID)
        {
            try
            {
                var result = new List<string>();

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "SELECT * FROM projecto.accounts WHERE id='" + userID + "'";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader.GetString("name"));
                    result.Add(reader.GetString("surname"));
                }
                reader.Close();
                cmd.Dispose();

                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.CommandTimeout = 40;
                cmd2.CommandText = "SELECT * FROM projecto.projects WHERE ownerID='" + userID + "'";
                cmd2.Connection = conn;
                cmd2.CommandType = CommandType.Text;
                MySqlDataReader reader2 = cmd2.ExecuteReader();

                int firstProjectID = 100000001;

                while (reader2.Read())
                {
                    if (firstProjectID == 100000001)
                    {
                        result.Add(reader2.GetInt32("ID").ToString());
                        firstProjectID = 0;
                    }
                    result.Add(reader2.GetString("project"));
                    var m = new Members();
                    result.Add(m.LoadMemberInfo(reader2.GetString("ownerID"), null)[0].Split(',')[1].ToString());
                    result.Add(reader2.GetString("memberIDs").Split(',').Length.ToString());
                    result.Add(reader2.GetString("deadline"));
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

        public List<string> LoadProjectMembers(string projectID)
        {
            try
            {
                var result = new List<string>();

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "SELECT memberIDs FROM projecto.projects WHERE ID='" + projectID + "'";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                MySqlDataReader reader = cmd.ExecuteReader();

                string members_of_project = null;

                while (reader.Read())
                {
                    members_of_project = reader.GetString("memberIDs");
                }
                reader.Close();
                cmd.Dispose();

                string[] members = members_of_project.Split(',');

                foreach (string memberID in members)
                {
                    var mem = new Members();
                    result.AddRange(mem.LoadMemberInfo(memberID, null));
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
    }
}