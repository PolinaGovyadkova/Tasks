using Dishes.Abstract;
using Dishes.Processes.ProcessesInterfaces;

namespace Dishes.Products.Ingredients
{
    public class Tomato : Product, ICutProcess, IBakeProcess, IRoastingProcess
    {
        public Tomato() : base(15, 10, 5, 1000, 20)
        {
        }
    }
}