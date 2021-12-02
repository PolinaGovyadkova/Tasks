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
    [TestClass()]
    public class FunctionalTests
    {
        readonly ConnectionString _connectionString = new ConnectionString();

        [TestMethod()]
        public void ReadElementTest()
        {
            var functional = new Functional<Author>(_connectionString.GetConnection());
            var expected = new Author() { Id = 1, Name = "Albert",Surname = "Smash", Patronymic = "Smith"};
            var result = functional.ReadElement(expected.Id);
            Assert.AreEqual(result.ToString(), expected.ToString());
        }

        [TestMethod()]
        public void ReadElementAllTest()
        {
            var functional = new Functional<ClientBookHistory>(_connectionString.GetConnection());
            Assert.IsNotNull(functional.ReadElement());
        }

        [TestMethod()]
        public void ReadElementExceptionTest()
        {
            var functional = new Functional<ClientBookHistory>(_connectionString.GetConnection());
            Assert.IsNull(functional.ReadElement(190));
        }

        [TestMethod()]
        public void CreateDeleteReadElementTest()
        {
            var functional = new Functional<Author>(_connectionString.GetConnection());
            functional.CreateElement(GetAuthor());
            var result = functional.ReadElement(GetAuthor().Id);
            functional.DeleteElement(GetAuthor().Id);
            Assert.AreEqual(result.ToString(), GetAuthor().ToString());
        }

        [TestMethod()]
        public void UpdateElementTest()
        {
            var functional = new Functional<Author>(_connectionString.GetConnection());

            var expected = new Author() { Id = 1,Name = "Albert", Surname = "Smash",Patronymic = "Salman" };
            functional.UpdateElement(expected.Id, expected);
            Author result = functional.ReadElement(expected.Id);

            Assert.AreEqual(result.ToString(), expected.ToString());
        }
        private static Author GetAuthor() => new Author { Id = 12, Name = "Test", Surname = "Tester", Patronymic = "Testovich" };
    }
}