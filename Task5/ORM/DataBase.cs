using DataBaseConnection;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Table;

namespace ORM
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
