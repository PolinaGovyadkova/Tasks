using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProduct.Foods
{
    public class Milk : Food, ITemperature
    {
        public Milk(double payloadCapacity, double volume) : base(payloadCapacity, volume)
        {
        }
        public int[] Temperature => new int[] { 3, 4, 5 };
    }
}
