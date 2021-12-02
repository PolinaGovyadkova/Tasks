using System;

namespace ORM.Table
{
    /// <summary>
    /// Client
    /// </summary>
    /// <seealso cref="ORM.Table.BaseTableElement" />
    public class Client : BaseTableElement
    {
        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName { get; set; }
        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public string Gender { get; set; }
        /// <summary>
        /// Gets or sets the birth year.
        /// </summary>
        /// <value>
        /// The birth year.
        /// </value>
        public DateTime BirthYear { get; set; }
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is Client author && base.Equals(obj) && Id == author.Id && FullName == author.FullName && Gender == author.Gender && BirthYear == author.BirthYear;
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => FullName.GetHashCode() + Gender.GetHashCode() + BirthYear.GetHashCode() + base.GetHashCode();
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => base.ToString() + string.Format($"FullName {FullName} Gender {Gender} BirthDate {BirthYear}");
    }
}