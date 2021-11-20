using Dishes.Abstract;
using Dishes.Processes.ProcessesInterfaces;
using Dishes.Products.Drinks;

namespace Dishes.Products.Ingredients
{
    /// <summary>
    /// Salt
    /// </summary>
    /// <seealso cref="DefaultProduct" />
    /// <seealso cref="Dishes.Processes.ProcessesInterfaces.IMixProcess" />
    public class Salt : DefaultProduct, IMixProcess
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Salt"/> class.
        /// </summary>
        public Salt() : base(3, 25, 2, 35, 20)
        {
        }
    }
}