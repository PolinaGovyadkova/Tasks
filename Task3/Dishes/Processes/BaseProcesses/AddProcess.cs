using System;
using Dishes.Abstract;
using Dishes.Interfaces;

namespace Dishes.Processes.BaseProcesses
{
    public class AddProcess : Process
    {
        public AddProcess() : base(new TimeSpan(0,10,0), 0)
        {
        }

        public override int Load { get; set; } = 10;

        public override Product Update (Product product)
        {
            if (product is IAddProcess)
            {
                return product;
            }
            else
            {
                throw new Exception("This product is not intended to be added");
            }
        }
    }
}