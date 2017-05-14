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

        public List<string> LoadMyProjects(string userID)
        {
            try
            {
                var result = new List<string>();

                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.CommandTimeout = 40;
                cmd2.CommandText = "SELECT * FROM projecto.projects WHERE ownerID='" + userID + "'";
                cmd2.Connection = conn;
                cmd2.CommandType = CommandType.Text;
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    result.Add(reader2.GetInt32("ID").ToString());
                    result.Add(reader2.GetString("project"));
                    result.Add(reader2.GetString("ownerID"));
                    var m = new Members();
                    result.Add(m.LoadMemberInfo(reader2.GetString("ownerID"), null)[0].Split(',')[1].ToString());
                    result.Add(reader2.GetString("memberIDs").Split(',').Length.ToString());
                    result.Add(reader2.GetString("deadline"));
                }

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

        public List<string> LoadParticipatingProjects(string userID)
        {
            try
            {
                var result = new List<string>();

                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.CommandTimeout = 40;
                cmd2.CommandText = "SELECT * FROM projecto.projects WHERE memberIDs LIKE '%" + userID + "%'";
                cmd2.Connection = conn;
                cmd2.CommandType = CommandType.Text;
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    result.Add(reader2.GetInt32("ID").ToString());
                    result.Add(reader2.GetString("project"));
                    result.Add(reader2.GetString("ownerID"));
                    var m = new Members();
                    result.Add(m.LoadMemberInfo(reader2.GetString("ownerID"), null)[0].Split(',')[1].ToString());
                    result.Add(reader2.GetString("memberIDs").Split(',').Length.ToString());
                    result.Add(reader2.GetString("deadline"));
                }

                if (result != null) return result;
                else
                {
                    result.Add("ERR");
                    result.Add("ERR");
                    return result;
                }
            }
            catch (MySqlException ex)
            {
                var result = new List<string>();
                result.Add("ERR");
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

        public string AddProjectMember(string memberID, string projectID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "UPDATE projecto.projects SET memberIDs=CONCAT(memberIDs,'," + memberID + "') WHERE ID='" + projectID + "'";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                return "OK";
            }
            catch (MySqlException ex)
            {
                return ex.ToString();
            }
        }

        public string RemoveProjectMember(string memberID, string projectID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "UPDATE projecto.projects SET memberIDs = REPLACE(memberIDs, '," + memberID + "', '') WHERE ID='" + projectID + "'";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                return "OK";
            }
            catch (MySqlException ex)
            {
                return ex.ToString();
            }
        }



        public string AddProject(string name, string desc, string deadline, string ownerID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "INSERT INTO projecto.projects (project, description, deadline, ownerID, memberIDs) VALUES ('" + name + "', '" + desc + "', '" + deadline + "', '" + ownerID + "', '0');";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                return "OK";
            }
            catch (MySqlException ex)
            {
                return ex.ToString();
            }
        }

        public string DeleteProject(string projectID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "DELETE FROM projecto.projects WHERE ID='" + projectID + "'";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.CommandTimeout = 40;
                cmd2.CommandText = "DELETE * FROM projecto.todo WHERE projectID='" + projectID + "'";
                cmd2.Connection = conn;
                cmd2.CommandType = CommandType.Text;
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();

                MySqlCommand cmd3 = new MySqlCommand();
                cmd3.CommandTimeout = 40;
                cmd3.CommandText = "DELETE * FROM projecto.inprogress WHERE projectID='" + projectID + "'";
                cmd3.Connection = conn;
                cmd3.CommandType = CommandType.Text;
                cmd3.ExecuteNonQuery();
                cmd3.Dispose();

                MySqlCommand cmd4 = new MySqlCommand();
                cmd4.CommandTimeout = 40;
                cmd4.CommandText = "DELETE * FROM projecto.forreview WHERE projectID='" + projectID + "'";
                cmd4.Connection = conn;
                cmd4.CommandType = CommandType.Text;
                cmd4.ExecuteNonQuery();
                cmd4.Dispose();

                MySqlCommand cmd5 = new MySqlCommand();
                cmd5.CommandTimeout = 40;
                cmd5.CommandText = "DELETE * FROM projecto.done WHERE projectID='" + projectID + "'";
                cmd5.Connection = conn;
                cmd5.CommandType = CommandType.Text;
                cmd5.ExecuteNonQuery();
                cmd5.Dispose();

                MySqlCommand cmd6 = new MySqlCommand();
                cmd6.CommandTimeout = 40;
                cmd6.CommandText = "DELETE * FROM projecto.messages WHERE projectID='" + projectID + "'";
                cmd6.Connection = conn;
                cmd6.CommandType = CommandType.Text;
                cmd6.ExecuteNonQuery();
                cmd6.Dispose();

                return "OK";
            }
            catch (MySqlException ex)
            {
                return ex.ToString();
            }
        }
    }
}