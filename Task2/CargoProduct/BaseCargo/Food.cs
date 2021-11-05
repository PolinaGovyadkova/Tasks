using CargoProduct.Interfaces;
using System.Collections.Generic;

namespace CargoProduct.BaseCargo
{
    /// <summary>
    /// Food
    /// </summary>
    /// <seealso cref="CargoProduct.BaseCargo.Cargo" />
    /// <seealso cref="CargoProduct.Interfaces.ITemperature" />
    public abstract class Food : Cargo, ITemperature
    {
        /// <summary>
        /// Gets or sets the payload capacity.
        /// </summary>
        /// <value>
        /// The payload capacity.
        /// </value>
        public override double PayloadCapacity { get; set; }
        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        /// <value>
        /// The volume.
        /// </value>
        public override double Volume { get; set; }
        /// <summary>
        /// Gets the temperature.
        /// </summary>
        /// <value>
        /// The temperature.
        /// </value>
        public abstract List<int> Temperature { get; }
    }
}