using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PROJECTO.WEB.BackEnd.DBConn
{
    public class Maintenance
    {
        public MySqlConnection conn;

        public Maintenance()
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

        public string ClearNonActivated()
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
                cmd.Dispose();
                
                return "OK";
            }
            catch (MySqlException ex) { return ex.ToString(); }
        }

        ~Maintenance()
        {
            conn.Close();
        }
    }
}