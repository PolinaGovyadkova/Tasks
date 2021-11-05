namespace CargoProduct.Interfaces
{
    /// <summary>
    /// ICargo
    /// </summary>
    public interface ICargo
    {
        /// <summary>
        /// Gets or sets the payload capacity.
        /// </summary>
        /// <value>
        /// The payload capacity.
        /// </value>
        double PayloadCapacity { get; set; }
        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        /// <value>
        /// The volume.
        /// </value>
        double Volume { get; set; }
    }
}