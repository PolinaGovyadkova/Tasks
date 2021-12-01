using ORM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseConnection;
using ORM.Creator;
using ORM.DAO;
using ORM.Table;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionString connectionString = new ConnectionString();
            Functional<Author> crud = new Functional<Author>(connectionString.GetConnection());
            var expected = new Author()
            {
                Id = 3,
                Name = "Albert",
                Surname = "Smash",
                Patronymic = "Smith"
            };
            crud.UpdateElement(1,expected);
            //Functional<ClientBookHistory> crud = new Functional<ClientBookHistory>(connectionString.GetConnection());
            //List<ClientBookHistory> result = crud.ReadElement();
            //var expected = new Book()
            //{
            //    Id = 1,
            //    Name = "War and Piece",
            //    GenreId = 2,
            //    AuthorId = 1
            //};

            ////var result = crud.ReadElement(expected.Id);
            //foreach (var VARIABLE in result)
            //{

            //    Console.WriteLine(VARIABLE);
            //}
            Console.ReadKey();
        }
    }
}
