using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PROJECTO.WEB.BackEnd.WebServices
{
    /// <summary>
    /// Summary description for AccMgmt
    /// </summary>
    [WebService(Namespace = "http://localhost/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AccMgmt : System.Web.Services.WebService
    {
        [WebMethod]
        public string Login(string email, string password)
        {
            var sc = new DBConn.Accounts();
            return sc.Login(email, password);
        }

        [WebMethod]
        public string Register(string name, string surname, string email, string password)
        {
            var sc = new DBConn.Accounts();
            return sc.Register(name, surname, email, password);
        }

        [WebMethod]
        public List<string> LoadUserInfo(string userID)
        {
            var sc = new DBConn.Accounts();
            return sc.LoadUserInfo(userID);
        }
    }
}
