namespace Transport.Intefaces
{
    /// <summary>
    /// ITransport
    /// </summary>
    public interface ITransport
    {
        /// <summary>
        /// Gets or sets the payload capacity.
        /// </summary>
        /// <value>
        /// The payload capacity.
        /// </value>
        double PayloadCapacity { get; set; }
    }
}