using Dishes.Abstract;
using Dishes.Interfaces;

namespace Dishes.Products.Drinks
{
    public class Water : Product, IAddProcess
    {
        public Water() : base(200, 15, 5, 50, 10)
        {
        }
    }
}