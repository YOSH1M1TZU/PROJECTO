using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PROJECTO.WEB.BackEnd.DBConn
{
    public class Members
    {
        public MySqlConnection conn;

        public Members()
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

        public List<string> LoadMemberInfo(string memberID, string memberEmail)
        {
            try
            {
                var result = new List<string>();

                if (memberID != null)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandTimeout = 40;
                    cmd.CommandText = "SELECT * FROM projecto.accounts WHERE id='" + memberID + "'";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(reader.GetString("id") + "," + reader.GetString("name") + " " + reader.GetString("surname"));
                    }
                    reader.Close();
                    cmd.Dispose();
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandTimeout = 40;
                    cmd.CommandText = "SELECT * FROM projecto.accounts WHERE email='" + memberEmail + "'";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(reader.GetString("id") + "," + reader.GetString("name") + " " + reader.GetString("surname"));
                    }
                    reader.Close();
                    cmd.Dispose();
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
                result.Add("ERR");
                return result;
            }
        }
    }
}