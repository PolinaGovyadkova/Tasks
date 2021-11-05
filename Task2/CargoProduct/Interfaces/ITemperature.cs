using System.Collections.Generic;

namespace CargoProduct.Interfaces
{
    /// <summary>
    /// ITemperature
    /// </summary>
    public interface ITemperature
    {
        /// <summary>
        /// Gets the temperature.
        /// </summary>
        /// <value>
        /// The temperature.
        /// </value>
        List<int> Temperature { get; }
    }
}