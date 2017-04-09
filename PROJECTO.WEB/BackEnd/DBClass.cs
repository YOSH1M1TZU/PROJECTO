using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Windows;

namespace PROJECTO.WEB.BackEnd
{
    public class DBClass
    {
        public MySqlConnection conn;

        public DBClass ()
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

        public string MOTD()
        {
            return "random";
        }

        public string Login(string email, string password)
        {
            try
            {
                string result = null;
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "SELECT * FROM projecto.accounts WHERE email='" + email + "' AND password='" + password + "'";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetString("id");
                }
                if (result != null) return result;
                else return "ERR";
            }
            catch (MySqlException ex) { return ex.ToString(); }
        }

        public string Register(string name, string surname, string email, string password)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "INSERT INTO accounts (name, surname, email, password) VALUES ('" + name + "' , '" + surname + "' , '" + email + "' , '" + password + "');";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                return "OK";
            }
            catch (MySqlException ex) { return ex.ToString(); }
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
                    if(firstProjectID == 100000001)
                    {
                        result.Add(reader2.GetInt32("ID").ToString());
                        firstProjectID = 0;
                    }
                    result.Add(reader2.GetString("project"));
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






        public List<string> LoadTodos(string projectID)
        {
            try
            {
                var result = new List<string>();

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "SELECT * FROM projecto.todo WHERE projectID='" + projectID + "'";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader.GetString("todoTitle"));
                    result.Add(reader.GetString("todoDesc"));
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

        public string AddTodos(string title, string desc, string projectID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "INSERT INTO projecto.todo (todoTitle, todoDesc, projectID) VALUES ('" + title + "', '" + desc + "', '" + projectID + "');";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                return "OK";
            }
            catch (MySqlException ex) { return ex.ToString(); }
        }

        public string EditTodos(string oldTitle, string newTitle, string newDesc, string projectID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "UPDATE projecto.todo SET todoDesc='" + newDesc + "' WHERE todoTitle='" + oldTitle + "' AND projectID='" + projectID + "'";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.CommandTimeout = 40;
                cmd2.CommandText = "UPDATE projecto.todo SET todoTitle='" + newTitle + "' WHERE todoTitle='" + oldTitle + "' AND projectID='" + projectID + "'";
                cmd2.Connection = conn;
                cmd2.CommandType = CommandType.Text;
                cmd2.ExecuteNonQuery();
                return "OK";
            }
            catch (MySqlException ex) { return ex.ToString(); }
        }

        public string RemoveTodos(string title, string projectID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "DELETE FROM projecto.todo WHERE projectID='" + projectID + "' AND todoTitle='" + title + "';";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                return "OK";
            }
            catch (MySqlException ex) { return ex.ToString(); }
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

        public List<string> LoadFinished(string projectID)
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













        public List<string> Projects_Owned_Reader(string ownerID)
        {
            try
            {
                var result = new List<string>();

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "SELECT * FROM projecto.projects WHERE ownerID='" + ownerID + "'";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                MySqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    result.Add(reader.GetString("project"));
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

        public string Maintenance()
        {
            //deleting of non activated accounts
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "DELETE FROM projecto.accounts WHERE activated='0';";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                return "OK";
            }
            catch (MySqlException ex) { return ex.ToString(); }
        }

        public void ChatMessage()
        {

        }
    }
}