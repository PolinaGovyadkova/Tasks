using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportWork
{
    /// <summary>
    /// FileException
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class FileException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileException"/> class.
        /// </summary>
        /// <param name="message">Сообщение, описывающее ошибку.</param>
        public FileException(string message)
            : base("Invalid path to file.: \r\n" + message)
        {
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
        public override bool Equals(object obj) => obj is FileException;
    }
}
