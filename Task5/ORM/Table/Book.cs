namespace ORM.Table
{
    /// <summary>
    /// Book
    /// </summary>
    /// <seealso cref="ORM.Table.BaseTableElement" />
    public class Book : BaseTableElement
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the genre identifier.
        /// </summary>
        /// <value>
        /// The genre identifier.
        /// </value>
        public int GenreId { get; set; }
        /// <summary>
        /// Gets or sets the author identifier.
        /// </summary>
        /// <value>
        /// The author identifier.
        /// </value>
        public int AuthorId { get; set; }
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is Book author && base.Equals(obj) && Id == author.Id && Name == author.Name && GenreId == author.GenreId && AuthorId == author.AuthorId;

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => Name.GetHashCode() + GenreId.GetHashCode() + AuthorId.GetHashCode() + base.GetHashCode();
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => base.ToString() + string.Format($"Name {Name} GenreId {GenreId} AuthorId {AuthorId}");
    }
}