using System;

namespace ReportWork.WorkWithData
{
    /// <summary>
    /// IReport
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// Populars the type.
        /// </summary>
        /// <param name="file">The file.</param>
        void PopularType(string file);

        /// <summary>
        /// Borroweds the book.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="finish">The finish.</param>
        /// <param name="file">The file.</param>
        void BorrowedBook(DateTime start, DateTime finish, string file);

        /// <summary>
        /// Bads the books.
        /// </summary>
        /// <param name="file">The file.</param>
        void BadBooks(string file);
    }
}