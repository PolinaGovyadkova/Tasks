namespace Dishes.Interfaces
{
    /// <summary>
    /// Product
    /// </summary>
    /// <seealso cref="Dishes.Interfaces.ITemperature" />
    public interface IProduct : ITemperature
    {
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        float Size { get; set; }
        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        float Weight { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        float Price { get; set; }
    }
}