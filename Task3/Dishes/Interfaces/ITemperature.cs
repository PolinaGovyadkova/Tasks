namespace Dishes.Interfaces
{
    /// <summary>
    /// Temperature interface
    /// </summary>
    public interface ITemperature
    {
        /// <summary>
        /// Gets or sets the maximum temperature.
        /// </summary>
        /// <value>
        /// The maximum temperature.
        /// </value>
        int MaxTemperature { get; set; }
        /// <summary>
        /// Gets or sets the minimum temperature.
        /// </summary>
        /// <value>
        /// The minimum temperature.
        /// </value>
        int MinTemperature { get; set; }
    }
}