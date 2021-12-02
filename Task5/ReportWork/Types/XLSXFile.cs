using Microsoft.Office.Interop.Excel;
using ORM;
using System;
using System.Linq;
using Org.BouncyCastle.Pkix;
using ORM.BD;
using ReportWork.Enum;
using ReportWork.WorkWithData;
using ReportWork.WorkWithData.Method;

namespace ReportWork.Types
{
    /// <summary>
    /// XLSXFile
    /// </summary>
    /// <seealso cref="ReportWork.WorkWithData.BaseReport" />
    public class XLSXFile : BaseReport
    {
        /// <summary>
        /// Popular  type.
        /// </summary>
        /// <param name="file">The file.</param>
        public override void PopularType(string file)
        {
            var application = new Application();
            var workBook = application.Workbooks.Add();
            var workSheet = (Worksheet)workBook.ActiveSheet;

            workSheet.Cells[1, "A"] = "Popular author";
            workSheet.Cells[1, "B"] = "Most reading subscriber";
            workSheet.Cells[1, "C"] = "Popular genre";

            var database = new DataBase();
            var books = database.Books.ToList();
            var genres = database.Genres.ToList();
            var authors = database.Authors.ToList();
            var clients = database.Clients.ToList();
            var histories = database.ClientBookHistory.ToList();
            var author = ReportMethod.MostPopularAuthor(authors, books).Name   + " " + ReportMethod.MostPopularAuthor(authors, books).Surname;
            var clientName = ReportMethod.GetMostReadingSubscriber(histories, clients).FullName;
            var genreType = ReportMethod.GetPopularGenre(books, genres).Name;
            workSheet.Cells[2, "A"] = author;
            workSheet.Cells[2, "B"] = clientName;
            workSheet.Cells[2, "C"] = genreType;
            Checker(file, application, workBook);
        }

        /// <summary>
        /// Borrowed book.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="finish">The finish.</param>
        /// <param name="file">The file.</param>
        public override void BorrowedBook(DateTime start, DateTime finish, string file)
        {
            var application = new Application();
            var workBook = application.Workbooks.Add();
            var workSheet = (Worksheet)workBook.ActiveSheet;
            var database = new DataBase();
            var books = database.Books.ToList();
            var clients = database.Clients.ToList();
            var histories = database.ClientBookHistory.ToList();
            var badBooks = ReportMethod.EachSubscriberBooksForDate(start, finish, clients, books, histories);
            var excelCells = (Range)workSheet.Range[workSheet.Cells[1, "A"], workSheet.Cells[20, "O"]].Cells;
            excelCells.Merge(Type.Missing);
            workSheet.Cells[1, 1] = badBooks;
            Checker(file, application, workBook);
        }

        /// <summary>
        /// Bad books.
        /// </summary>
        /// <param name="file">The file.</param>
        public override void BadBooks(string file)
        {
            var application = new Application();
            var workBook = application.Workbooks.Add();
            var workSheet = (Worksheet)workBook.ActiveSheet;
            var database = new DataBase();
            var books = database.Books.ToList();
            var histories = database.ClientBookHistory.ToList();
            var badBooks = ReportMethod.GetBadBookList(books, histories);
            workSheet.Cells[1, "A"] = "Id";
            workSheet.Cells[1, "B"] = "Name";
            for (var i = 2; i < badBooks.Count(); i++)
            {
                workSheet.Cells[i, "A"].Value = badBooks[i].Id;
                workSheet.Cells[i, "B"].Value = badBooks[i].Name;
            }

            var maxLine = badBooks.Count();
            var rngSort = workSheet.Range["A1", $"F{maxLine}"];
            rngSort.Sort(rngSort.Columns[
                1, Type.Missing], (XlSortOrder)SortType.Ascending,
                null, Type.Missing, XlSortOrder.xlAscending, Type.Missing,
                XlSortOrder.xlAscending,
                XlYesNoGuess.xlYes, Type.Missing, Type.Missing, XlSortOrientation.xlSortColumns);
            Checker(file, application, workBook);
        }

        /// <summary>
        /// Checkers the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="application">The application.</param>
        /// <param name="workBook">The work book.</param>
        /// <exception cref="ReportWork.FileException"></exception>
        private static void Checker(string file, Application application, Workbook workBook)
        {
            try
            {
                workBook.Close(true, $"{Environment.CurrentDirectory}" + file);
                application.Quit();
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
        public override bool Equals(object obj) => obj is XLSXFile;
    }
}