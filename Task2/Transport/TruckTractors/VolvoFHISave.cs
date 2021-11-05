using Transport.BaseElements;

namespace Transport.TruckTractors
{
    /// <summary>
    /// VolvoFHISave
    /// </summary>
    /// <seealso cref="Transport.BaseElements.TruckTractor" />
    public class VolvoFHISave : TruckTractor
    {
        /// <summary>
        /// Gets the fuel consumption.
        /// </summary>
        /// <value>
        /// The fuel consumption.
        /// </value>
        public override int FuelConsumption => 6;
    }
}