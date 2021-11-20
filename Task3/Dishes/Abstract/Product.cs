using Dishes.Interfaces;

namespace Dishes.Abstract
{
    /// <summary>
    /// Product
    /// </summary>
    /// <seealso cref="Dishes.Abstract.Temperature" />
    /// <seealso cref="Dishes.Interfaces.IProduct" />
    public abstract class Product :Temperature, IProduct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="maxTemperature">The maximum temperature.</param>
        /// <param name="minTemperature">The minimum temperature.</param>
        /// <param name="size">The size.</param>
        /// <param name="weight">The weight.</param>
        protected Product(float price, int maxTemperature, int minTemperature, float size, float weight)
        {
            Price = price;
            Size = size;
            Weight = weight;
            MaxTemperature = maxTemperature;
            MinTemperature = minTemperature;
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public float Size { get; set; }
        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        public float Weight { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public float Price { get; set; }
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is Product product && product.Size == Size && product.Weight == Weight && product.Price == Price;
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