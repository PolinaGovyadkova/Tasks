using Dishes.Abstract;
using Dishes.Processes.ProcessesInterfaces;
using Dishes.Products.Drinks;

namespace Dishes.Products.Ingredients
{
    /// <summary>
    /// Tomato
    /// </summary>
    /// <seealso cref="DefaultProduct" />
    /// <seealso cref="Dishes.Processes.ProcessesInterfaces.ICutProcess" />
    /// <seealso cref="Dishes.Processes.ProcessesInterfaces.IBakeProcess" />
    /// <seealso cref="Dishes.Processes.ProcessesInterfaces.IRoastingProcess" />
    public class Tomato : DefaultProduct, ICutProcess, IBakeProcess, IRoastingProcess
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tomato"/> class.
        /// </summary>
        public Tomato() : base(15, 10, 3, 1000, 20)
        {
        }
    }
}