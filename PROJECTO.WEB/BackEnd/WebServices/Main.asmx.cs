using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Data;

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
            var sc = new DBClass();
            return sc.MOTD();
        }

        //TODO: deconstruct this Web Service into a smaller ones

        [WebMethod]
        public List<string> LoadProjects(string userID)
        {
            var sc = new DBConn.Projects();
            return sc.LoadProjects(userID);
        }

        [WebMethod]
        public List<string> LoadProjectMembers(string projectID)
        {
            var sc = new DBConn.Projects();
            return sc.LoadProjectMembers(projectID);
        }

        [WebMethod]
        public List<string> LoadMemberInfo(string memberID, string memberEmail)
        {
            var sc = new DBConn.Members();
            return sc.LoadMemberInfo(memberID, memberEmail);
        }

        [WebMethod]
        public List<string> LoadMessages(string firstUserID, string secondUserID, string chsnProj)
        {
            var sc = new DBConn.Messages();
            return sc.LoadMessages(firstUserID, secondUserID, chsnProj);
        }

        [WebMethod]
        public string SendMessage(string messageText, string senderID, string receiverID, string sentTime, string chsnproj)
        {
            var sc = new DBConn.Messages();
            return sc.SendMessage(messageText, senderID, receiverID, sentTime, chsnproj);
        }



        [WebMethod]
        public string Maintenance()
        {
            var sc = new DBConn.Maintenance();
            return sc.ClearNonActivated();
        }
    }
}
