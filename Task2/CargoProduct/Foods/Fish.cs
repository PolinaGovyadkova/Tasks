using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProduct.Foods
{
    public class Fish : Food, ITemperature
    {
        public Fish(double payloadCapacity, double volume) : base(payloadCapacity, volume)
        {
        }
        public int[] Temperature => new int[] { -25, -24, -23, -22, -21, -20, -19, -18, -17, -16, -15 };
    }
}
