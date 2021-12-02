using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORM.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Table;
using DataBaseConnection;

namespace ORM.DAO.Tests
{
    /// <summary>
    /// FunctionalTests
    /// </summary>
    [TestClass()]
    public class FunctionalTests
    {
        /// <summary>
        /// The connection string
        /// </summary>
        readonly ConnectionString _connectionString = new ConnectionString();

        /// <summary>
        /// Reads the element test.
        /// </summary>
        [TestMethod()]
        public void ReadElementTest()
        {
            var functional = new Functional<Author>(_connectionString.GetConnection());
            var expected = new Author() { Id = 1, Name = "Albert",Surname = "Smash", Patronymic = "Smith"};
            var result = functional.ReadElement(expected.Id);
            Assert.AreEqual(result.ToString(), expected.ToString());
        }

        /// <summary>
        /// Reads the element all test.
        /// </summary>
        [TestMethod()]
        public void ReadElementAllTest()
        {
            var functional = new Functional<ClientBookHistory>(_connectionString.GetConnection());
            Assert.IsNotNull(functional.ReadElement());
        }

        /// <summary>
        /// Reads the element exception test.
        /// </summary>
        [TestMethod()]
        public void ReadElementExceptionTest()
        {
            var functional = new Functional<ClientBookHistory>(_connectionString.GetConnection());
            Assert.IsNull(functional.ReadElement(190));
        }

        /// <summary>
        /// Creates the delete read element test.
        /// </summary>
        [TestMethod()]
        public void CreateDeleteReadElementTest()
        {
            var functional = new Functional<Author>(_connectionString.GetConnection());
            functional.CreateElement(GetAuthor());
            var result = functional.ReadElement(GetAuthor().Id);
            functional.DeleteElement(GetAuthor().Id);
            Assert.AreEqual(result.ToString(), GetAuthor().ToString());
        }

        /// <summary>
        /// Updates the element test.
        /// </summary>
        [TestMethod()]
        public void UpdateElementTest()
        {
            var functional = new Functional<Author>(_connectionString.GetConnection());

            var expected = new Author() { Id = 1,Name = "Albert", Surname = "Smash",Patronymic = "Salman" };
            functional.UpdateElement(expected.Id, expected);
            Author result = functional.ReadElement(expected.Id);

            Assert.AreEqual(result.ToString(), expected.ToString());
        }
        /// <summary>
        /// Gets the author.
        /// </summary>
        /// <returns></returns>
        private static Author GetAuthor() => new Author { Id = 12, Name = "Test", Surname = "Tester", Patronymic = "Testovich" };
    }
}