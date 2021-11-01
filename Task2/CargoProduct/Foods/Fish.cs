using System.Collections.Generic;

namespace CargoProduct.Foods
{
    public class Fish : Food, ITemperature
    {
        public Fish(double payloadCapacity, double volume) : base(payloadCapacity, volume)
        {
        }

        public List<int> Temperature => new List<int> { -25, -24, -23, -22, -21, -20, -19, -18, -17, -16, -15 };
    }
}