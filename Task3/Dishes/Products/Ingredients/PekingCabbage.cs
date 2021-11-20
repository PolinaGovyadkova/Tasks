using Dishes.Abstract;
using Dishes.Processes.ProcessesInterfaces;

namespace Dishes.Products.Ingredients
{
    public class PekingCabbage : Product, ICutProcess
    {
        public PekingCabbage() : base(12, 10, 1, 100, 50)
        {
        }
    }
}