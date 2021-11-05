using System;
using Transport.Intefaces;

namespace Transport.BaseElements
{
    /// <summary>
    /// TruckTractor
    /// </summary>
    /// <seealso cref="Transport.Intefaces.ITurkTractor" />
    public abstract class TruckTractor : ITurkTractor
    {
        /// <summary>
        /// The consumption
        /// </summary>
        private double _consumption;
        /// <summary>
        /// The index
        /// </summary>
        private double _index;
        /// <summary>
        /// Gets the fuel consumption.
        /// </summary>
        /// <value>
        /// The fuel consumption.
        /// </value>
        public abstract int FuelConsumption { get; }
        /// <summary>
        /// Gets or sets the payload capacity.
        /// </summary>
        /// <value>
        /// The payload capacity.
        /// </value>
        public double PayloadCapacity { get; set; }
        /// <summary>
        /// Gets or sets the semitrailer.
        /// </summary>
        /// <value>
        /// The semitrailer.
        /// </value>
        public Semitrailer Semitrailer { get; set; }

        /// <summary>
        /// Adds the trailer.
        /// </summary>
        /// <param name="semiTrailer">The semi trailer.</param>
        /// <exception cref="System.Exception">Прицеп есть.</exception>
        public void AddTrailer(ISemitrailer semiTrailer)
        {
            Semitrailer = Semitrailer is null
                ? (Semitrailer)semiTrailer
                : throw new Exception("Прицеп есть.");
            _consumption = Semitrailer != null
                ? _index * Semitrailer.PayloadCapacity + _index * 1000
                : _index * 1000;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }
            var truckTractor = (TruckTractor)obj;
            return PayloadCapacity == truckTractor.PayloadCapacity;
        }

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
        public override string ToString() => $"Седельный тягач марки {GetType().Name} с максимально перевозимым весом {PayloadCapacity}";
    }
}