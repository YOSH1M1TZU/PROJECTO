using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PROJECTO.WEB.BackEnd.DBConn
{
    public class LoginRegister
    {
        public MySqlConnection conn;

        public LoginRegister()
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
    }
}