using CRUDWebAPI.DAO.InterfaceDAO;
using CRUDWebAPI.DAO.ObjectFactory;
using CRUDWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace CRUDWebAPI.API
{
    /// <summary>
    /// Summary description for EmployeeWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeeWebService : System.Web.Services.WebService
    {
        IEmployeeDAO _employeeDAO = ObjectFactory.GetEmployeeDAO();
        private readonly JavaScriptSerializer json = new JavaScriptSerializer();
        private readonly string DevId = "AMDEV_007-01-2025";//As of now it is hardcoded or stored here but later 
                                                            //for security purpose I will make it dynamic.
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetAll(string DeveloperId)
        {
            if(DeveloperId == this.DevId)
            {
                Context.Response.ContentType = "application/json";
                Context.Response.Write(json.Serialize(_employeeDAO.GetAll()));
            }
            else
            {
                Context.Response.ContentType = "application/json";
                Context.Response.Write(json.Serialize("Invalid Developer Id"));
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetById(string DeveloperId, int id)
        {
            if(DeveloperId ==this.DevId)
            {
                Context.Response.ContentType = "application/json";
                Context.Response.Write(json.Serialize(_employeeDAO.GetById(id)));
            }
            else
            {
                Context.Response.ContentType = "application/json";
                Context.Response.Write(json.Serialize("Invalid Developer Id"));
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Insert(string DeveloperId, Employee emp)
        {
            if(DeveloperId == this.DevId)
            {
                Context.Response.ContentType = "application/json";
                bool result = _employeeDAO.Insert(emp);
                Context.Response.Write(json.Serialize(new { success = result }));
            }
            else
            {
                Context.Response.ContentType = "application/json";
                Context.Response.Write(json.Serialize("Invalid Developer Id"));
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Update(string DeveloperId, Employee emp)
        {
            if(DeveloperId == this.DevId)
            {
                Context.Response.ContentType = "application/json";
                bool result = _employeeDAO.Update(emp);
                Context.Response.Write(json.Serialize(new { success = result }));
            }
            else
            {
                Context.Response.ContentType = "application/json";
                Context.Response.Write(json.Serialize("Invalid Developer Id"));
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Delete(string DeveloperId, int id)
        {
            if(DeveloperId == this.DevId)
            {
                Context.Response.ContentType = "application/json";
                bool result = _employeeDAO.Delete(id);
                Context.Response.Write(json.Serialize(new { success = result }));
            }
            else
            {
                Context.Response.ContentType = "application/json";
                Context.Response.Write(json.Serialize("Invalid Developer Id"));
            }
        }
    }
}
