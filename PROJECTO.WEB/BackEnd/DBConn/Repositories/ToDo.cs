using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PROJECTO.WEB.BackEnd.DBConn
{
    public class ToDo
    {
        public MySqlConnection conn;

        public ToDo()
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
                    result.Add(reader.GetString("todoCategory"));
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






        public string AddTodos(string title, string desc, string category, string projectID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "INSERT INTO projecto.todo (todoTitle, todoDesc, projectID, todoCategory) VALUES ('" + title + "', '" + desc + "', '" + projectID + "', '" + category + "');";
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
    }
}