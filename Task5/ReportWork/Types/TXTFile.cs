using ORM;
using System;
using System.IO;
using System.Linq;
using ORM.BD;
using ReportWork.WorkWithData;
using ReportWork.WorkWithData.Method;

namespace ReportWork.Types
{
    /// <summary>
    /// TXTFile
    /// </summary>
    /// <seealso cref="ReportWork.WorkWithData.BaseReport" />
    public class TXTFile : BaseReport
    {
        /// <summary>
        /// Popular type.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <exception cref="ReportWork.FileException"></exception>
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

        /// <summary>
        /// Borrowed book.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="finish">The finish.</param>
        /// <param name="file">The file.</param>
        /// <exception cref="ReportWork.FileException"></exception>
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

        /// <summary>
        /// Bad books.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <exception cref="ReportWork.FileException"></exception>
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
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => base.GetHashCode();
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is TXTFile;

    }
}