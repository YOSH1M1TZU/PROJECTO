using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PROJECTO.WEB.BackEnd.DBConn
{
    public class Messages
    {
        public MySqlConnection conn;

        public Messages()
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

        public List<string> LoadMessages(string firstUserID, string secondUserID, string chsnProj)
        {
            try
            {
                var result = new List<string>();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "SELECT * FROM projecto.messages WHERE messageSender='" + firstUserID + "' AND messageReceiver='" + secondUserID + "' AND projectID='" + chsnProj + "';";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader.GetString("messageText"));
                    result.Add(reader.GetString("sentTime"));
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

        public string SendMessage(string messageText, string senderID, string receiverID, string sentTime, string chsnproj)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 40;
                cmd.CommandText = "INSERT INTO projecto.messages (messageText, messageSender, messageReceiver, sentTime, projectID) VALUES ('" + messageText + "', '" + senderID + "', '" + receiverID + "', '" + sentTime + "', '" + chsnproj + "');";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
                return "OK";
            }
            catch (MySqlException ex)
            {
                return ex.ToString();
            }
        }

        ~Messages()
        {
            conn.Close();
        }
    }
}