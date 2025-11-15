using CRUDWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWebAPI.DAO.InterfaceDAO
{
    public interface IEmployeeDAO
    {
        List<Employee> GetAll();
        Employee GetById(int id);
        bool Insert(Employee emp);
        bool Update(Employee emp);
        bool Delete(int id);
    }
}
