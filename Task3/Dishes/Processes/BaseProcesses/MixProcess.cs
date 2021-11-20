using System;
using Dishes.Abstract;
using Dishes.Processes.ProcessesInterfaces;

namespace Dishes.Processes.BaseProcesses
{
    public abstract class MixProcess : Process
    {
        public override int Load { get; set; } = 10;

        protected MixProcess(TimeSpan time, float price) : base(new TimeSpan(0, 20, 10), 3)
        {
        }

        public override Product Update(Product product)
        {
            if (product is IMixProcess)
            {
                product.Size = product.Size;
                product.Weight = product.Weight;
                return product;
            }
            else
            {
                throw new Exception("this product is not intended for mixing");
            }
           
        }
    }
}