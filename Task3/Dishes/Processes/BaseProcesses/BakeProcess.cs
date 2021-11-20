using System;
using Dishes.Abstract;
using Dishes.Processes.ProcessesInterfaces;

namespace Dishes.Processes.BaseProcesses
{
    public abstract class BakeProcess : Process
    {
        public override int Load { get; set; } = 10;

        protected BakeProcess(TimeSpan time, float price) : base(new TimeSpan(0,20,10), 10)
        {
        }
        public override Product Update(Product product)
        {
          
            if (product is IBakeProcess)
            {
                product.Size += 2;
                product.Weight += 2;
                return product;
            }
            else
            {
                throw new Exception("This product is not intended for baking ");
            }
        }
    }
}