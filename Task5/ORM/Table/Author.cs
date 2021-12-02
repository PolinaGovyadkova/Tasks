namespace ORM.Table
{
    /// <summary>
    /// Author
    /// </summary>
    /// <seealso cref="ORM.Table.BaseTableElement" />
    public class Author : BaseTableElement
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        public string Surname { get; set; }
        /// <summary>
        /// Gets or sets the patronymic.
        /// </summary>
        /// <value>
        /// The patronymic.
        /// </value>
        public string Patronymic { get; set; }
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is Author author && base.Equals(obj) && Id == author.Id && Name == author.Name && Surname == author.Surname && Patronymic == author.Patronymic;
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => Name.GetHashCode() + Surname.GetHashCode() + Patronymic.GetHashCode() + base.GetHashCode();
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => base.ToString() + string.Format($"Name {Name} Surname {Surname} Patronymic {Patronymic}");
    }
}