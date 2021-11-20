using Dishes.Abstract;
using Dishes.Interfaces;

namespace Dishes.Products.Drinks
{
    /// <summary>
    /// OrangeJucie
    /// </summary>
    /// <seealso cref="Dishes.Abstract.Product" />
    /// <seealso cref="Dishes.Interfaces.IAddProcess" />
    public class OrangeJucie : Drink, IAddProcess
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrangeJucie"/> class.
        /// </summary>
        public OrangeJucie() : base(5, 15, 10, 10, 10)
        {
        }
    }
}