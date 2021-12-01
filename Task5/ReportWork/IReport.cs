using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportCreator
{
    public interface IReport
    {
        void PopularType(string filePath);
        void BorrowedBook(string filePath);
        void BadBooks(string filePath);
    }
}
