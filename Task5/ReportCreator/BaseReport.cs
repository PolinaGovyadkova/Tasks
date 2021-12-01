using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportCreator
{
    public abstract class BaseReport : IReport
    {
        public abstract void PopularType(string filePath);

        public abstract void BorrowedBook(string filePath);

        public abstract void BadBooks(string filePath);
    }
}
