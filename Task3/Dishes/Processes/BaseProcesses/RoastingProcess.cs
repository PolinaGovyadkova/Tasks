using System;
using Dishes.Abstract;
using Dishes.Processes.ProcessesInterfaces;

namespace Dishes.Processes.BaseProcesses
{
    public abstract class RoastingProcess : Process
    {
        public override int Load { get; set; } = 10;

        protected RoastingProcess(TimeSpan time, float price) : base(new TimeSpan(0, 30, 10), 30)
        {
        }

        public override Product Update (Product product)
        {
            if (product is IRoastingProcess)
            {
                product.Size += 9;
                product.Weight += 5;
                return product;
            }
            else throw new Exception("this product is not intended for roasting");
        }
    }
}