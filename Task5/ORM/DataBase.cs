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
    public class DataBase
    {
        private DataBaseSet<ClientBookHistory> _clientBookHistory;
        private DataBaseSet<Author> _authors;
        private DataBaseSet<Book> _books;
        private DataBaseSet<Client> _clients;
        private DataBaseSet<Genre> _genres;

        public DataBaseSet<Client> Clients
        {
            get => _clients;
            set => _clients = value;
        }

        public DataBaseSet<Book> Books
        {
            get => _books;
            set => _books = value;
        }

        public DataBaseSet<Genre> Genres
        {
            get => _genres;
            set => _genres = value;
        }

        public DataBaseSet<Author> Authors
        {
            get => _authors;
            set => _authors = value;
        }

        public DataBaseSet<ClientBookHistory> ClientBookHistory
        {
            get => _clientBookHistory;
            set => _clientBookHistory = value;
        }

        private DataBase()
        {
            Clients = new DataBaseSet<Client>();
            Books = new DataBaseSet<Book>();
            Genres = new DataBaseSet<Genre>();
            Authors = new DataBaseSet<Author>();
            ClientBookHistory = new DataBaseSet<ClientBookHistory>();
        }
       
    }
}
