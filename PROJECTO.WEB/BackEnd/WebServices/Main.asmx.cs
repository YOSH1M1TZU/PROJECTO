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
        public string Login(string email, string password)
        {
            var sc = new DBClass();
            return sc.Login(email, password);
        }

        [WebMethod]
        public string Register(string name, string surname, string email, string password)
        {
            var sc = new DBClass();
            return sc.Register(name, surname, email, password);
        }










        [WebMethod]
        public List<string> LoadProjects(string userID)
        {
            var sc = new DBClass();
            return sc.LoadProjects(userID);
        }














        [WebMethod]
        public List<string> LoadTodos(string chosenProject)
        {
            var sc = new DBClass();
            return sc.LoadTodos(chosenProject);
        }

        [WebMethod]
        public string AddTodos(string title,string desc, string projectID)
        {
            var sc = new DBClass();
            return sc.AddTodos(title, desc, projectID);
        }

        [WebMethod]
        public string EditTodos(string oldTitle, string newTitle, string newDesc, string projectID)
        {
            var sc = new DBClass();
            return sc.EditTodos(oldTitle, newTitle, newDesc, projectID);
        }

        [WebMethod]
        public string RemoveTodos(string title, string projectID)
        {
            var sc = new DBClass();
            return sc.RemoveTodos(title, projectID);
        }










        [WebMethod]
        public void ChatMessage(string senderID, string message, string project, string team)
        {

        }

        [WebMethod]
        public string Maintenance()
        {
            var sc = new DBClass();
            return sc.Maintenance();
        }
    }
}
