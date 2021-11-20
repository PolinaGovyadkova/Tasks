using Dishes.Abstract;

namespace Dishes.Products.Ingredients
{
    /// <summary>
    /// Default Product
    /// </summary>
    /// <seealso cref="Dishes.Abstract.Product" />
    public abstract class DefaultProduct : Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultProduct"/> class.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="maxTemperature">The maximum temperature.</param>
        /// <param name="minTemperature">The minimum temperature.</param>
        /// <param name="size">The size.</param>
        /// <param name="weight">The weight.</param>
        protected DefaultProduct(float price, int maxTemperature, int minTemperature, float size, float weight) : base(price, maxTemperature, minTemperature, size, weight)
        {
        }
    }
}
