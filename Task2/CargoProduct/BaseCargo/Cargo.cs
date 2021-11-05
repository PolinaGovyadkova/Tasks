using CargoProduct.Interfaces;

namespace CargoProduct.BaseCargo
{
    /// <summary>
    /// Cargo
    /// </summary>
    /// <seealso cref="CargoProduct.Interfaces.ICargo" />
    public abstract class Cargo : ICargo
    {
        /// <summary>
        /// Gets or sets the payload capacity.
        /// </summary>
        /// <value>
        /// The payload capacity.
        /// </value>
        public abstract double PayloadCapacity { get; set; }
        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        /// <value>
        /// The volume.
        /// </value>
        public abstract double Volume { get; set; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj.GetType() == GetType();

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"Груз {GetType().Name} объёмом {Volume} и массой {PayloadCapacity}";
    }
}