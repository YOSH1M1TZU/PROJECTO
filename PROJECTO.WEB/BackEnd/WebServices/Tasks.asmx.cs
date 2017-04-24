using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PROJECTO.WEB.BackEnd.WebServices
{
    /// <summary>
    /// Summary description for Tasks
    /// </summary>
    [WebService(Namespace = "http://localhost/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Tasks : System.Web.Services.WebService
    {
        [WebMethod]
        public List<string> LoadTodos(string chosenProject)
        {
            var sc = new DBConn.ToDo();
            return sc.LoadTodos(chosenProject);
        }

        [WebMethod]
        public string AddTodos(string title, string desc, string projectID)
        {
            var sc = new DBConn.ToDo();
            return sc.AddTodos(title, desc, projectID);
        }

        [WebMethod]
        public string EditTodos(string oldTitle, string newTitle, string newDesc, string projectID)
        {
            var sc = new DBConn.ToDo();
            return sc.EditTodos(oldTitle, newTitle, newDesc, projectID);
        }

        [WebMethod]
        public string RemoveTodos(string title, string projectID)
        {
            var sc = new DBConn.ToDo();
            return sc.RemoveTodos(title, projectID);
        }
    }
}
