using CRUDWebAPI.DAO.InterfaceDAO;
using CRUDWebAPI.Database;
using CRUDWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDWebAPI.DAO.ImplementsDAO
{
    public class EmployeeDAO : IEmployeeDAO
    {
        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string Query = @"SELECT * FROM Employees";
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    employees.Add(new Employee
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        Email = dr["Email"].ToString(),
                        Department = dr["Department"].ToString(),
                        Salary = Convert.ToDecimal(dr["Salary"])
                    });

                }
            }
            return employees;
        }

        public Employee GetById(int id)
        {
            Employee employee = null;
            using(SqlConnection con = DBConnection.GetConnection())
            {
                string Query = @"SELECT * FROM Employees WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(Query,con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    employee = new Employee
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        Email = dr["Email"].ToString(),
                        Department = dr["Department"].ToString(),
                        Salary = Convert.ToDecimal(dr["Salary"])
                    };
                }
            }
            return employee;
        }

        public bool Insert(Employee emp)
        {
            using(SqlConnection con = DBConnection.GetConnection())
            {
                string Query = @"INSERT INTO Employees (Name, Email, Department, Salary) 
                                 VALUES (@Name, @Email, @Department, @Salary)";

                SqlCommand cmd = new SqlCommand(Query,con);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                con.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool Update(Employee emp)
        {
            using(SqlConnection con = DBConnection.GetConnection())
            {
                string Query = @"UPDATE Employees SET Name = @Name, Email = @Email, Department = @Department, Salary = @Salary WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(Query,con);
                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                con.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool Delete(int id)
        {
            using(SqlConnection con = DBConnection.GetConnection())
            {
                String Query = @"DELETE FROM Employees WHERE ID = @Id";
                SqlCommand cmd  = new SqlCommand(@Query,con);
                cmd.Parameters.AddWithValue(@"id", id);
                con.Open();

                return cmd.ExecuteNonQuery() > 0;
            }

        }
    }
}