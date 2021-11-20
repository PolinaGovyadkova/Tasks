using System;
using Dishes.Abstract;
using Dishes.Processes.ProcessesInterfaces;

namespace Dishes.Processes.BaseProcesses
{
    public abstract class CutProcess : Process
    {
        public override int Load { get; set; } = 10;

        protected CutProcess(TimeSpan time, float price) : base(new TimeSpan(0, 20, 10), 20)
        {
        }

        public int ResizeCoefficient { get; set; } = 13;

        public override Product Update(Product product)
        {
            if (product is ICutProcess)
            {
                product.Size = ResizeCoefficient;
                return product;
            }
            else
            {
                throw new Exception("This product is not intended for slicing");
            }
        }
    }
}