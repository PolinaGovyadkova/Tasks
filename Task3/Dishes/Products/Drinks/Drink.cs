using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dishes.Abstract;

namespace Dishes.Products.Drinks
{
    /// <summary>
    /// Drink
    /// </summary>
    /// <seealso cref="Dishes.Abstract.Product" />
    public abstract class Drink : Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Drink"/> class.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="maxTemperature">The maximum temperature.</param>
        /// <param name="minTemperature">The minimum temperature.</param>
        /// <param name="size">The size.</param>
        /// <param name="weight">The weight.</param>
        protected Drink(float price, int maxTemperature, int minTemperature, float size, float weight) : base(price, maxTemperature, minTemperature, size, weight)
        {
        }
    }
}
