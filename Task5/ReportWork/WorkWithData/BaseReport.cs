using System;

namespace ReportWork.WorkWithData
{
    /// <summary>
    /// BaseReport
    /// </summary>
    /// <seealso cref="ReportWork.WorkWithData.IReport" />
    public abstract class BaseReport : IReport
    {
        /// <summary>
        /// Populars the type.
        /// </summary>
        /// <param name="file">The file.</param>
        public abstract void PopularType(string file);

        /// <summary>
        /// Borroweds the book.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="finish">The finish.</param>
        /// <param name="file">The file.</param>
        public abstract void BorrowedBook(DateTime start, DateTime finish, string file);

        /// <summary>
        /// Bads the books.
        /// </summary>
        /// <param name="file">The file.</param>
        public abstract void BadBooks(string file);
    }
}