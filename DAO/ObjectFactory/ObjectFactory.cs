using CRUDWebAPI.DAO.InterfaceDAO;
using CRUDWebAPI.DAO.ImplementsDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDWebAPI.DAO.ObjectFactory
{
    public class ObjectFactory
    {
        public static IEmployeeDAO GetEmployeeDAO()
        {
            return new EmployeeDAO();
        }
    }
}