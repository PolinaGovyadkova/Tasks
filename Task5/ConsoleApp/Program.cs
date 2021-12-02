using ReportWork.Types;
using System;

namespace ConsoleApp
{
    /// <summary>
    /// Program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Main(string[] args)
        {
            var xlsxFile = new XLSXFile();
            var file = @"..\..\..\..\BorrowedBookList.xlsx";

            var filePathBorrowedBook = @"..\..\..\..\BorrowedBook.xlsx";

            var column = 2;

            xlsxFile.BadBooks(file);
            //xlsxFile.BorrowedBook(new DateTime(2006, 11, 1), new DateTime(2106, 11, 1), filePathBorrowedBook);

            //DataBase _database = new DataBase();
            //var books = _database.Books.ToList();
            //var authors = _database.Authors.ToList();
            //var genres = _database.Genres.ToList();
            //var client = _database.Clients.ToList();
            //var clientBookHistory = _database.ClientBookHistory.ToList();
            //var result = ReportMethod.EachSubscriberBooksForDate(new DateTime(2006 , 11 , 1), new DateTime(2106, 11, 1), client,books, clientBookHistory);
            //var result = ReportMethod.GetPopularGenre(books, genres).Name;
            //Console.WriteLine(result);
            //ConnectionString connectionString = new ConnectionString();
            //Functional<Author> functional = new Functional<Author>(connectionString.GetConnection());
            //var expected = new Author()
            //{
            //    Id = 3,
            //    Name = "Albert",
            //    Surname = "Smash",
            //    Patronymic = "Smith"
            //};
            //functional.UpdateElement(1,expected);
            //Functional<ClientBookHistory> functional = new Functional<ClientBookHistory>(connectionString.GetConnection());
            //List<ClientBookHistory> result = functional.ReadElement();
            //var expected = new Book()
            //{
            //    Id = 1,
            //    Name = "War and Piece",
            //    GenreId = 2,
            //    AuthorId = 1
            //};

            ////var result = functional.ReadElement(expected.Id);
            //foreach (var VARIABLE in result)
            //{
            //    Console.WriteLine(VARIABLE);
            //}
            Console.ReadKey();
        }
    }
}