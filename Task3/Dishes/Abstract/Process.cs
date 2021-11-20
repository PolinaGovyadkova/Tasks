using System;
using System.Collections.Generic;
using Dishes.Interfaces;

namespace Dishes.Abstract
{
    /// <summary>
    /// Process
    /// </summary>
    /// <seealso cref="Dishes.Interfaces.IProcessing" />
    public abstract class Process : IProcessing
    {
        /// <summary>
        /// Gets or sets the load.
        /// </summary>
        /// <value>
        /// The load.
        /// </value>
        public abstract int Load { get; set; }
        /// <summary>
        /// Gets or sets the size coefficient.
        /// </summary>
        /// <value>
        /// The size coefficient.
        /// </value>
        public virtual int SizeCoefficient { get; set; } = 0;
        /// <summary>
        /// Gets or sets the weight coefficient.
        /// </summary>
        /// <value>
        /// The weight coefficient.
        /// </value>
        public virtual int WeightCoefficient { get; set; } = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Process"/> class.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="price">The price.</param>
        protected Process(TimeSpan time, float price)
        {
            Time = time;
            Price += price;
        }

        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public TimeSpan Time { get; }
        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public float Price { get; }

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        public abstract Product Update(Product product);
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is Process process && process.Load == Load && process.Time == Time && process.Price == Price;
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => base.GetHashCode();
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => GetType().Name;
    }
}