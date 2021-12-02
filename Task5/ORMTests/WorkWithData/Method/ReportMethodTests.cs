using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportWork.WorkWithData.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.BD;
using ORM.Table;

namespace ReportWork.WorkWithData.Method.Tests
{
    [TestClass()]
    public class ReportMethodTests
    {
        readonly DataBase _database = new DataBase();
        [TestMethod()]
        public void MostPopularAuthorTest()
        {
            var books = _database.Books.ToList();
            var authors = _database.Authors.ToList();
            var author = ReportMethod.MostPopularAuthor(authors, books).Name + " " + ReportMethod.MostPopularAuthor(authors, books).Surname;
            Assert.AreEqual("Napoleon Hill", author);
        }

        [TestMethod()]
        public void GetBadBookListTest()
        {
            var books = _database.Books.ToList();
            var histories = _database.ClientBookHistory.ToList();
            var badBooks = ReportMethod.GetBadBookList(books, histories);
            var nameBooks = badBooks.Select(element => element.Name).ToList();
            var result = new List<string>(){ "To Kill a Mockingbird", "The Poets Laureate Anthology", "Where The Sidewalk Ends", "The Odyssey", "The 7 Habits of Highly Effective People", "Think And Grow Rich" };
            CollectionAssert.AreEqual(result, nameBooks);
        }

        [TestMethod()]
        public void GetPopularGenreTest()
        {
            var books = _database.Books.ToList();
            var genres = _database.Genres.ToList();
            var expected = "Poetry";
            var result = ReportMethod.GetPopularGenre(books, genres).Name;

            Assert.AreEqual(result, expected);
        }

        [TestMethod()]
        public void GetMostReadingSubscriberTest()
        {
            var clients = _database.Clients.ToList();
            var histories = _database.ClientBookHistory.ToList();
            var clientName = ReportMethod.GetMostReadingSubscriber(histories, clients).FullName;

            Assert.AreEqual("Anderson Taft Guryevich", clientName);
        }

        [TestMethod()]
        public void EachSubscriberBooksForDateTest()
        {
            var books = _database.Books.ToList();
            var clients = _database.Clients.ToList();
            var сlientBookHistories = _database.ClientBookHistory.ToList();
            var start = new DateTime(2021, 01, 01);
            var finish = new DateTime(2022, 01, 01);
            var clientName = ReportMethod.EachSubscriberBooksForDate(start, finish, clients, books, сlientBookHistories);
            Assert.IsTrue(clientName.Length !=0);
        }
    }
}