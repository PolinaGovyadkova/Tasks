using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportWork
{
    public class FileException : Exception
    {
        public FileException(string message)
            : base("Invalid path to file.: \r\n" + message)
        {
        }
        
    }
}
