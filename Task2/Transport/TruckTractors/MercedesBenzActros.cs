using Transport.BaseElements;

namespace Transport.TruckTractors
{
    /// <summary>
    /// MercedesBenzActros
    /// </summary>
    /// <seealso cref="Transport.BaseElements.TruckTractor" />
    public class MercedesBenzActros : TruckTractor
    {
        /// <summary>
        /// Gets the fuel consumption.
        /// </summary>
        /// <value>
        /// The fuel consumption.
        /// </value>
        public override int FuelConsumption => 26;
    }
}