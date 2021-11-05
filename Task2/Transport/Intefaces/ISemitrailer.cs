using CargoProduct.Interfaces;
using System;

namespace Transport.Intefaces
{
    /// <summary>
    /// ISemitrailer
    /// </summary>
    /// <seealso cref="Transport.Intefaces.ITransport" />
    public interface ISemitrailer : ITransport
    {
        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        /// <value>
        /// The volume.
        /// </value>
        double Volume { get; set; }
        /// <summary>
        /// Gets the free weight.
        /// </summary>
        /// <value>
        /// The free weight.
        /// </value>
        double FreeWeight { get; }
        /// <summary>
        /// Gets the free volume.
        /// </summary>
        /// <value>
        /// The free volume.
        /// </value>
        double FreeVolume { get; }
        /// <summary>
        /// Gets the type product.
        /// </summary>
        /// <value>
        /// The type product.
        /// </value>
        Type TypeProduct { get; }

        /// <summary>
        /// Products the add.
        /// </summary>
        /// <param name="product">The product.</param>
        void ProductAdd(ICargo product);
    }
}