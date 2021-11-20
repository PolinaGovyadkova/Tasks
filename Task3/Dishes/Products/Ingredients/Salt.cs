using Dishes.Abstract;
using Dishes.Processes.ProcessesInterfaces;

namespace Dishes.Products.Ingredients
{
    public class Salt : Product, IMixProcess
    {
        public Salt() : base(3, 25, 5, 35, 20)
        {
        }
    }
}