using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportWork.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportWork.Types.Tests
{
    [TestClass()]
    public class XLSXFileTests
    {
        readonly XLSXFile _xlsxFile = new XLSXFile();
        [TestMethod()]
        public void PopularTypeTest()
        {
            string filePath = @"..\..\..\..\PopularTypes.xlsx";
            _xlsxFile.PopularType(filePath);
            string textFromFile = File.ReadAllText(filePath);
            Assert.IsTrue(textFromFile.Length != 0);
        }

        [TestMethod()]
        public void BorrowedBookTest()
        {
            string filePath = @"..\..\..\..\BorrowedBooks.xlsx";
            _xlsxFile.BorrowedBook(new DateTime(2021, 03, 01), new DateTime(2022, 07, 01), filePath);
            string textFromFile = File.ReadAllText(filePath);
            Assert.IsTrue(textFromFile.Length != 0);
        }

        [TestMethod()]
        public void BadBooksTest()
        {
            string filePath = @"..\..\..\..\BadBooks.xlsx";
            _xlsxFile.BadBooks(filePath);
            string textFromFile = File.ReadAllText(filePath);
            Assert.IsTrue(textFromFile.Length != 0);
        }
    }
}