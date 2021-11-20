using Dishes.Abstract;
using Dishes.Processes.ProcessesInterfaces;

namespace Dishes.Products.Ingredients
{
    public class Meet : Product, IRoastingProcess, ICutProcess
    {
        public Meet() : base(200, 5, 3, 400, 60)
        {
        }
    }
}