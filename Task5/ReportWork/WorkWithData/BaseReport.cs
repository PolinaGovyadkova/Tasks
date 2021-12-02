using System;

namespace ReportWork.WorkWithData
{
    public abstract class BaseReport : IReport
    {
        public abstract void PopularType(string file);

        public abstract void BorrowedBook(DateTime start, DateTime finish, string file);

        public abstract void BadBooks(string file);
    }
}