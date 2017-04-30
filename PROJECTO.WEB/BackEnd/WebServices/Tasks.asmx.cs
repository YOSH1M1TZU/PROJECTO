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
        public List<string> LoadTodos(string projectID)
        {
            var sc = new DBConn.ToDo();
            return sc.LoadTodos(projectID);
        }

        [WebMethod]
        public List<string> LoadInProgress(string projectID)
        {
            var sc = new DBConn.InProgress();
            return sc.LoadInProgress(projectID);
        }

        [WebMethod]
        public List<string> LoadForReview(string projectID)
        {
            var sc = new DBConn.ForReview();
            return sc.LoadForReview(projectID);
        }

        [WebMethod]
        public List<string> LoadDone(string projectID)
        {
            var sc = new DBConn.Done();
            return sc.LoadDone(projectID);
        }






        [WebMethod]
        public string AddTodos(string title, string desc, string category, string projectID)
        {
            var sc = new DBConn.ToDo();
            return sc.AddTodos(title, desc, category, projectID);
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






        [WebMethod]
        public string MoveTask(string from, string to, string taskTitle, string taskDesc, string taskCategory, string projectID)
        {
            var sc = new DBConn.TasksMain();
            return sc.MoveTask(from, to, taskTitle, taskDesc, taskCategory, projectID);
        }
    }
}
