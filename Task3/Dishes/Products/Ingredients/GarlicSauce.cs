using Dishes.Abstract;
using Dishes.Processes.ProcessesInterfaces;
using Dishes.Products.Drinks;

namespace Dishes.Products.Ingredients
{
    /// <summary>
    /// GarlicSauce
    /// </summary>
    /// <seealso cref="Dishes.Abstract.Product" />
    /// <seealso cref="Dishes.Processes.ProcessesInterfaces.IMixProcess" />
    public class GarlicSauce : DefaultProduct, IMixProcess
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GarlicSauce"/> class.
        /// </summary>
        public GarlicSauce() : base(4, 12, 2, 15, 20)
        {
        }
    }
}