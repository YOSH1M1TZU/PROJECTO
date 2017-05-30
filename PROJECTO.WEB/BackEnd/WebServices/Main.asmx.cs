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

        [WebMethod]
        public List<string> LoadMyProjects(string userID)
        {
            var sc = new DBConn.Projects();
            return sc.LoadMyProjects(userID);
        }

        [WebMethod]
        public List<string> LoadParticipatingProjects(string userID)
        {
            var sc = new DBConn.Projects();
            return sc.LoadParticipatingProjects(userID);
        }



        [WebMethod]
        public List<string> LoadProjectMembers(string projectID)
        {
            var sc = new DBConn.Projects();
            return sc.LoadProjectMembers(projectID);
        }

        [WebMethod]
        public string AddProjectMember(string memberID, string chsnProj)
        {
            var sc = new DBConn.Projects();
            return sc.AddProjectMember(memberID, chsnProj);
        }

        [WebMethod]
        public string RemoveProjectMember(string memberID, string chsnProj)
        {
            var sc = new DBConn.Projects();
            return sc.RemoveProjectMember(memberID, chsnProj);
        }



        [WebMethod]
        public string AddProject(string name, string desc, string deadline, string ownerID)
        {
            var sc = new DBConn.Projects();
            return sc.AddProject(name, desc, deadline, ownerID);
        }

        [WebMethod]
        public string DeleteProject(string chsnProj)
        {
            var sc = new DBConn.Projects();
            return sc.DeleteProject(chsnProj);
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
        public List<string> LoadFinances(string chsnProj)
        {
            var sc = new DBConn.Finances();
            return sc.LoadFinances(chsnProj);
        }

        [WebMethod]
        public string AddFinance(string title, string amount, string type, string chsnProj)
        {
            var sc = new DBConn.Finances();
            return sc.AddFinance(title, amount, type, chsnProj);
        }



        [WebMethod]
        public string Maintenance()
        {
            var sc = new DBConn.Maintenance();
            return sc.ClearNonActivated();
        }
    }
}
