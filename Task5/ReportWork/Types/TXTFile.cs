using ORM;
using System;
using System.IO;
using System.Linq;
using ORM.BD;
using ReportWork.WorkWithData;
using ReportWork.WorkWithData.Method;

namespace ReportWork.Types
{
    public class TXTFile : BaseReport
    {
        public override void PopularType(string file)
        {
            var database = new DataBase();
            var books = database.Books.ToList();
            var genres = database.Genres.ToList();
            var authors = database.Authors.ToList();
            var clients = database.Clients.ToList();
            var histories = database.ClientBookHistory.ToList();
            var author = ReportMethod.MostPopularAuthor(authors, books).Name + " " + ReportMethod.MostPopularAuthor(authors, books).Surname;
            var clientName = ReportMethod.GetMostReadingSubscriber(histories, clients).FullName;
            var genreType = ReportMethod.GetPopularGenre(books, genres).Name;
            try
            {
                var streamWriter = new StreamWriter(file);
                streamWriter.WriteLine("Popular Author\t\tSubscriber\t\t\t\tPopular Genre");
                streamWriter.WriteLine($"{author}\t \t{clientName}\t \t {genreType}");
                streamWriter.Close();
            }
            catch (Exception e)
            {
                throw new FileException(e.Message);
            }
            
        }

        public override void BorrowedBook(DateTime start, DateTime finish, string file)
        {
            var database = new DataBase();
            var books = database.Books.ToList();
            var clients = database.Clients.ToList();
            var histories = database.ClientBookHistory.ToList();
            try
            {
                var streamWriter = new StreamWriter(file);
                streamWriter.WriteLine("info\n");
                streamWriter.WriteLine(ReportMethod.EachSubscriberBooksForDate(start, finish, clients, books, histories));
                streamWriter.Close();
            }
            catch (Exception e)
            {
                throw new FileException(e.Message);
            }
            
        }

        public override void BadBooks(string file)
        {
            var database = new DataBase();
            var books = database.Books.ToList();
            var histories = database.ClientBookHistory.ToList();
            var k = ReportMethod.GetBadBookList(books, histories);
            try
            {
                var streamWriter = new StreamWriter(file);
                streamWriter.WriteLine("Id\t\tName");
                foreach (var element in k)
                {
                    streamWriter.Write(element.Id);
                    streamWriter.Write("\t\t");
                    streamWriter.WriteLine(element.Name);
                }
                streamWriter.Close();
            }
            catch (Exception e)
            {
                throw new FileException(e.Message);
            }

        }

    }
}