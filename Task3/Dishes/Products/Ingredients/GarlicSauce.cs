using Dishes.Abstract;
using Dishes.Processes.ProcessesInterfaces;

namespace Dishes.Products.Ingredients
{
    public class GarlicSauce : Product, IMixProcess
    {
        public GarlicSauce() : base(4, 12, 8, 15, 20)
        {
        }
    }
}