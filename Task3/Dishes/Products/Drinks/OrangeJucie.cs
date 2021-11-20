using Dishes.Abstract;
using Dishes.Interfaces;

namespace Dishes.Products.Drinks
{
    public class OrangeJucie : Product, IAddProcess
    {
        public OrangeJucie() : base(5, 15, 10, 10, 10)
        {
        }
    }
}