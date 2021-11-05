using Transport.Intefaces;

namespace Transport.BaseElements
{
    /// <summary>
    /// Transport
    /// </summary>
    /// <seealso cref="Transport.Intefaces.ITransport" />
    public abstract class Transport : ITransport
    {
        /// <summary>
        /// Gets or sets the payload capacity.
        /// </summary>
        /// <value>
        /// The payload capacity.
        /// </value>
        public abstract double PayloadCapacity { get; set; }
    }
}