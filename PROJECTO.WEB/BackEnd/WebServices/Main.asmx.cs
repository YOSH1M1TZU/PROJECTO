using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Windows;

namespace PROJECTO.WEB.BackEnd.WebServices
{
    [WebService(Namespace = "http://localhost/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Main : System.Web.Services.WebService
    {
        [WebMethod]
        public string MOTD()
        {
            var sc = new ServerClass();
            return sc.MOTD();
        }

        [WebMethod]
        public bool Login(string email, string password)
        {
            var sc = new ServerClass();
            return sc.Login(email, password);
        }

        [WebMethod]
        public void Register(string name, string surname, string email, string password)
        {
            
        }

        [WebMethod]
        public void ChatMessage(string senderID, string message, string project, string team)
        {

        }
    }
}
