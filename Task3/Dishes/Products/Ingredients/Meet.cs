using Dishes.Abstract;
using Dishes.Processes.ProcessesInterfaces;
using Dishes.Products.Drinks;

namespace Dishes.Products.Ingredients
{
    /// <summary>
    /// Meet
    /// </summary>
    /// <seealso cref="DefaultProduct" />
    /// <seealso cref="Dishes.Processes.ProcessesInterfaces.IRoastingProcess" />
    /// <seealso cref="Dishes.Processes.ProcessesInterfaces.ICutProcess" />
    public class Meet : DefaultProduct, IRoastingProcess, ICutProcess
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Meet"/> class.
        /// </summary>
        public Meet() : base(200, 5, 3, 400, 60)
        {
        }
    }
}