using System;

namespace ReportWork.WorkWithData
{
    public interface IReport
    {
        void PopularType(string file);

        void BorrowedBook(DateTime start, DateTime finish, string file);

        void BadBooks(string file);
    }
}