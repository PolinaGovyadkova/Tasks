using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseConnection
{
    public class ConnectionString
    {
        private readonly string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Task5DataBase;Integrated Security=True";
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
