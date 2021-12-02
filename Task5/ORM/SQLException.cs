using System;

namespace ORM
{
    /// <summary>
    /// SQLException
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class SQLException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SQLException"/> class.
        /// </summary>
        /// <param name="message">Сообщение, описывающее ошибку.</param>
        public SQLException(string message)
            : base("Sql query error: \r\n" + message)
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
        public override bool Equals(object obj) => obj is SQLException;
    }
}
