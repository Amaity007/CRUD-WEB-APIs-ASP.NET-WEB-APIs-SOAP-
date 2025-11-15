using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDWebAPI.Database
{
    public class DBConnection
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;
        
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}