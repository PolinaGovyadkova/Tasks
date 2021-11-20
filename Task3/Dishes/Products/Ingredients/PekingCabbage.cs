using Dishes.Abstract;
using Dishes.Processes.ProcessesInterfaces;
using Dishes.Products.Drinks;

namespace Dishes.Products.Ingredients
{
    /// <summary>
    /// PekingCabbage
    /// </summary>
    /// <seealso cref="DefaultProduct" />
    /// <seealso cref="Dishes.Processes.ProcessesInterfaces.ICutProcess" />
    public class PekingCabbage : DefaultProduct, ICutProcess
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PekingCabbage"/> class.
        /// </summary>
        public PekingCabbage() : base(12, 10, 1, 100, 50)
        {
        }
    }
}