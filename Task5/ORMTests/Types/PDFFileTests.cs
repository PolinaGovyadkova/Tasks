using Aspose.Pdf;
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
    /// PDFFileTests
    /// </summary>
    [TestClass()]
    public class PDFFileTests
    {
        /// <summary>
        /// The PDF
        /// </summary>
        readonly PDFFile _pdf = new PDFFile();
        /// <summary>
        /// Popular test.
        /// </summary>
        [TestMethod()]
        public void PopularTypeTest()
        {
            const string filePath = @"..\..\..\..\PopularTypes.pdf";
            _pdf.PopularType( filePath);
            var textFromFile = File.ReadAllText(filePath);
            Assert.IsTrue(textFromFile.Length != 0);
        }

        /// <summary>
        /// Borrowed book test.
        /// </summary>
        [TestMethod()]
        public void BorrowedBookTest()
        {
            const string filePath = @"..\..\..\..\BorrowedBooks.pdf";
            _pdf.BorrowedBook(new DateTime(2021, 03, 01), new DateTime(2022, 07, 01), filePath);
            var textFromFile = File.ReadAllText(filePath);
            Assert.IsTrue(textFromFile.Length != 0);
        }

        /// <summary>
        /// Bad books test.
        /// </summary>
        [TestMethod()]
        public void BadBooksTest()
        {
            const string filePath = @"..\..\..\..\BadBooks.pdf";
            _pdf.BadBooks(filePath);
            var textFromFile = File.ReadAllText(filePath);
            Assert.IsTrue(textFromFile.Length != 0 );
        }
    }
}