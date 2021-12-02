using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORM.Creator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Table;

namespace ORM.Creator.Tests
{
    /// <summary>
    /// FactoryTests
    /// </summary>
    [TestClass()]
    public class FactoryTests
    {
        /// <summary>
        /// Creates new objectauthortest.
        /// </summary>
        [TestMethod()]
        public void NewObjectAuthorTest()
        {
            var factory = new Factory();
            var result = factory.NewObject<Author>();
            var expected = new Author();
            Assert.AreEqual(result.ToString(), expected.ToString());
        }

        /// <summary>
        /// Creates new objectclienttest.
        /// </summary>
        [TestMethod()]
        public void NewObjectClientTest()
        {
            var factory = new Factory();
            var result = factory.NewObject<Client>();
            var expected = new Client();
            Assert.AreEqual(result.ToString(), expected.ToString());
        }

        /// <summary>
        /// Creates new objectgenretest.
        /// </summary>
        [TestMethod()]
        public void NewObjectGenreTest()
        {
            var factory = new Factory();
            var result = factory.NewObject<Genre>();
            var expected = new Genre();
            Assert.AreEqual(result.ToString(), expected.ToString());
        }

        /// <summary>
        /// Creates new objectbooktest.
        /// </summary>
        [TestMethod()]
        public void NewObjectBookTest()
        {
            var factory = new Factory();
            var result = factory.NewObject<Book>();
            var expected = new Book();
            Assert.AreEqual(result.ToString(), expected.ToString());
        }

        /// <summary>
        /// Creates new objectclientbookhistorytest.
        /// </summary>
        [TestMethod()]
        public void NewObjectClientBookHistoryTest()
        {
            var factory = new Factory();
            var result = factory.NewObject<ClientBookHistory>();
            var expected = new ClientBookHistory();
            Assert.AreEqual(result.ToString(), expected.ToString());
        }
    }
}