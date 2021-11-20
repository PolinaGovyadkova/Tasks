using Dishes.Abstract;
using Dishes.Interfaces;

namespace Dishes.Products.Drinks
{
    /// <summary>
    /// Water
    /// </summary>
    /// <seealso cref="Dishes.Abstract.Product" />
    /// <seealso cref="Dishes.Interfaces.IAddProcess" />
    public class Water : Drink, IAddProcess
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Water"/> class.
        /// </summary>
        public Water() : base(200, 15, 5, 50, 10)
        {
        }
    }
}