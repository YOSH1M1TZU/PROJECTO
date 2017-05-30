using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PROJECTO.WEB.BackEnd.DBConn
{
    public class Finances
    {
        public MySqlConnection conn;

        public Finances()
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

        public List<string> LoadFinances(string chsnProj)
        {
            try
            {
                var result = new List<string>();

                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.CommandTimeout = 40;
                cmd2.CommandText = "SELECT * FROM projecto.finances WHERE projectID='" + chsnProj + "'";
                cmd2.Connection = conn;
                cmd2.CommandType = CommandType.Text;
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    result.Add(reader2.GetInt32("ID").ToString());
                    result.Add(reader2.GetString("title"));
                    result.Add(reader2.GetString("amount"));
                    result.Add(reader2.GetString("type"));
                }
                cmd2.Dispose();
                reader2.Close();

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

        public string AddFinance (string title, string amount, string type, string chsnProj)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "INSERT INTO projecto.finances (title, amount, type, projectID) VALUES ('" + title + "', '" + amount + "', " + type + ", '" + chsnProj + "');";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return "OK";
            }
            catch (MySqlException ex) { return ex.ToString(); }
        }



        ~Finances()
        {
            conn.Close();
        }
    }
}