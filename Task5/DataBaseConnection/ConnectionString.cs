using System.Data.SqlClient;

namespace DataBaseConnection
{
    /// <summary>
    /// Class for connecting to a database
    /// </summary>
    public class ConnectionString
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Task5DataBase;Integrated Security=True";

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnection() => new SqlConnection(_connectionString);
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => GetConnection().GetHashCode();
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is ConnectionString connection && _connectionString == connection._connectionString && GetConnection() == connection.GetConnection();
    }
}