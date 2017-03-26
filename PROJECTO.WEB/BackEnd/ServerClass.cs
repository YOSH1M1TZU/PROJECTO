using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROJECTO.WEB.BackEnd
{
    public class ServerClass
    {
        public string MOTD()
        {
            //rand MOTD from database
            return "random";
        }

        public bool Login(string email, string password)
        {
            if (email == "admin" && password == "admin") return true;
            else return false;
        }

        public void Register()
        {
            
        }

        public void ChatMessage()
        {

        }
    }
}