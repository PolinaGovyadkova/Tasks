namespace CargoProduct.BaseCargo
{
    /// <summary>
    /// Fuel
    /// </summary>
    /// <seealso cref="CargoProduct.BaseCargo.Cargo" />
    public class Fuel : Cargo
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
    }
}