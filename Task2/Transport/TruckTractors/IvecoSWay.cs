using Transport.BaseElements;

namespace Transport.TruckTractors
{
    /// <summary>
    /// IvecoSWay
    /// </summary>
    /// <seealso cref="Transport.BaseElements.TruckTractor" />
    public class IvecoSWay : TruckTractor
    {
        /// <summary>
        /// Gets the fuel consumption.
        /// </summary>
        /// <value>
        /// The fuel consumption.
        /// </value>
        public override int FuelConsumption => 16;
    }
}