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
    /// <summary>
    /// TXTFileTests
    /// </summary>
    [TestClass()]
    public class TXTFileTests
    {
        /// <summary>
        /// The text
        /// </summary>
        TXTFile txt = new TXTFile();
        /// <summary>
        /// Popular type test.
        /// </summary>
        [TestMethod()]
        public void PopularTypeTest()
        {
            string filePath = @"..\..\..\..\PopularTypes.txt";
            txt.PopularType(filePath);
            string textFromFile = File.ReadAllText(filePath);
            Assert.IsTrue(textFromFile.Length != 0);
        }

        /// <summary>
        /// Borrowed book test.
        /// </summary>
        [TestMethod()]
        public void BorrowedBookTest()
        {
            string filePath = @"..\..\..\..\BorrowedBooks.txt";
            txt.BorrowedBook(new DateTime(2021, 03, 01), new DateTime(2022, 07, 01), filePath);
            string textFromFile = File.ReadAllText(filePath);
            Assert.IsTrue(textFromFile.Length != 0);
        }

        /// <summary>
        /// Bad books test.
        /// </summary>
        [TestMethod()]
        public void BadBooksTest()
        {
            string filePath = @"..\..\..\..\BadBooks.txt";
            txt.BadBooks(filePath);
            string textFromFile = File.ReadAllText(filePath);
            Assert.IsTrue(textFromFile.Length != 0);
        }
    }
}