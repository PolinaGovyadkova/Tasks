namespace Transport.BaseElements
{
    /// <summary>
    /// Coupling
    /// </summary>
    public class Coupling
    {
        /// <summary>
        /// Gets or sets the truck tractor.
        /// </summary>
        /// <value>
        /// The truck tractor.
        /// </value>
        public TruckTractor TruckTractor { get; set; }
        /// <summary>
        /// Gets or sets the semitrailer.
        /// </summary>
        /// <value>
        /// The semitrailer.
        /// </value>
        public Semitrailer Semitrailer { get; set; }
        /// <summary>
        /// The argument
        /// </summary>
        private const double _arg = 1.9;

        /// <summary>
        /// Initializes a new instance of the <see cref="Coupling"/> class.
        /// </summary>
        /// <param name="truckTractor">The truck tractor.</param>
        /// <param name="semitrailer">The semitrailer.</param>
        public Coupling(TruckTractor truckTractor, Semitrailer semitrailer)
        {
            TruckTractor = truckTractor;
            Semitrailer = semitrailer;
        }

        /// <summary>
        /// Gets the fuel consumption value.
        /// </summary>
        /// <value>
        /// The fuel consumption value.
        /// </value>
        public double FuelConsumptionValue => TruckTractor.FuelConsumption + Semitrailer.TotalWeight / 1000 * _arg;

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
            Coupling roadTrain = (Coupling)obj;
            return Semitrailer == roadTrain.Semitrailer && TruckTractor == roadTrain.TruckTractor;
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
        public override string ToString() => $"Автопоезд с расходом топлива {FuelConsumptionValue}";
    }
}