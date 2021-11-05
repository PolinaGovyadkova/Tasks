using CargoProduct.Interfaces;
using Transport.BaseElements;

namespace Transport.Intefaces
{
    /// <summary>
    /// ITurkTractor
    /// </summary>
    /// <seealso cref="Transport.Intefaces.ITransport" />
    public interface ITurkTractor : ITransport
    {
        /// <summary>
        /// Gets or sets the semitrailer.
        /// </summary>
        /// <value>
        /// The semitrailer.
        /// </value>
        Semitrailer Semitrailer { get; set; }
        /// <summary>
        /// Gets the fuel consumption.
        /// </summary>
        /// <value>
        /// The fuel consumption.
        /// </value>
        int FuelConsumption { get; }

        /// <summary>
        /// Adds the trailer.
        /// </summary>
        /// <param name="semiTrailer">The semi trailer.</param>
        void AddTrailer(ISemitrailer semiTrailer);
    }
}