using DataBaseConnection;
using ORM.Table;

namespace ORM.BD
{
    /// <summary>
    /// Data Base
    /// </summary>
    /// <seealso cref="DataBaseConnection.ConnectionString" />
    public class DataBase : ConnectionString
    {
        /// <summary>
        /// Gets or sets the clients.
        /// </summary>
        /// <value>
        /// The clients.
        /// </value>
        public DataBaseSet<Client> Clients { get; set; }
        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        /// <value>
        /// The books.
        /// </value>
        public DataBaseSet<Book> Books { get; set; }
        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        /// <value>
        /// The genres.
        /// </value>
        public DataBaseSet<Genre> Genres { get; set; }
        /// <summary>
        /// Gets or sets the authors.
        /// </summary>
        /// <value>
        /// The authors.
        /// </value>
        public DataBaseSet<Author> Authors { get; set; }
        /// <summary>
        /// Gets or sets the client book history.
        /// </summary>
        /// <value>
        /// The client book history.
        /// </value>
        public DataBaseSet<ClientBookHistory> ClientBookHistory { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataBase"/> class.
        /// </summary>
        public DataBase()
        {
            Clients = new DataBaseSet<Client>();
            Books = new DataBaseSet<Book>();
            Genres = new DataBaseSet<Genre>();
            Authors = new DataBaseSet<Author>();
            ClientBookHistory = new DataBaseSet<ClientBookHistory>();
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => Clients.GetHashCode() + Books.GetHashCode() + Genres.GetHashCode() + Authors.GetHashCode() + ClientBookHistory.GetHashCode();
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is DataBase dataBase && Books == dataBase.Books && ClientBookHistory == dataBase.ClientBookHistory && Authors == dataBase.Authors && Genres == dataBase.Genres && Clients == dataBase.Clients;
    }
}