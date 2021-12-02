using DataBaseConnection;
using ORM.Table;

namespace ORM.BD
{
    public class DataBase : ConnectionString
    {
        public DataBaseSet<Client> Clients { get; set; }
        public DataBaseSet<Book> Books { get; set; }
        public DataBaseSet<Genre> Genres { get; set; }
        public DataBaseSet<Author> Authors { get; set; }
        public DataBaseSet<ClientBookHistory> ClientBookHistory { get; set; }

        public DataBase()
        {
            Clients = new DataBaseSet<Client>();
            Books = new DataBaseSet<Book>();
            Genres = new DataBaseSet<Genre>();
            Authors = new DataBaseSet<Author>();
            ClientBookHistory = new DataBaseSet<ClientBookHistory>();
        }
    }
}