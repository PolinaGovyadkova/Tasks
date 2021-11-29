using System;

namespace Parser.Helper
{
    public class MatrixException : Exception
    {
        public MatrixException(string message) : base("Can't convert: \r\n" + message)
        {
        }
    }
}