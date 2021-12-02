using System;

namespace ORM.Table
{
    /// <summary>
    /// ClientBookHistory
    /// </summary>
    /// <seealso cref="ORM.Table.BaseTableElement" />
    public class ClientBookHistory : BaseTableElement
    {
        /// <summary>
        /// Gets or sets the receiving date.
        /// </summary>
        /// <value>
        /// The receiving date.
        /// </value>
        public DateTime ReceivingDate { get; set; }
        /// <summary>
        /// Gets or sets the book identifier.
        /// </summary>
        /// <value>
        /// The book identifier.
        /// </value>
        public int BookId { get; set; }
        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>
        /// The client identifier.
        /// </value>
        public int ClientId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is return.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is return; otherwise, <c>false</c>.
        /// </value>
        public bool IsReturn { get; set; }
        /// <summary>
        /// Gets or sets the book condition.
        /// </summary>
        /// <value>
        /// The book condition.
        /// </value>
        public string BookCondition { get; set; }
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is ClientBookHistory clientBookHistory && base.Equals(obj) && Id == clientBookHistory.Id && ReceivingDate == clientBookHistory.ReceivingDate && ClientId == clientBookHistory.ClientId && BookCondition == clientBookHistory.BookCondition && IsReturn == clientBookHistory.IsReturn;
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => ReceivingDate.GetHashCode() + BookId.GetHashCode() + IsReturn.GetHashCode() +BookCondition.GetHashCode()+ Id.GetHashCode();
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => base.ToString() + string.Format($"ReceivingDate {ReceivingDate}  BookId {BookId}  ClientId {ClientId} IsReturn {IsReturn} BookCondition {BookCondition}");
    }
}