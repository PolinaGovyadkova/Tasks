using System.Data.SqlClient;

namespace DataBaseConnection
{
    public class ConnectionString
    {
        private readonly string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Task5DataBase;Integrated Security=True";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public override int GetHashCode()
        {
            return GetConnection().GetHashCode();
        }
    }
}