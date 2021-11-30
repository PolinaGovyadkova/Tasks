using System;

namespace Parser.Helper
{
    /// <summary>
    /// MatrixException
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class MatrixException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        public MatrixException(string message) : base("Can't convert: \r\n" + message)
        {
        }
    }
}