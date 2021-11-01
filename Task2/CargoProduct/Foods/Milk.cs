using System.Collections.Generic;

namespace CargoProduct.Foods
{
    public class Milk : Food, ITemperature
    {
        public Milk(double payloadCapacity, double volume) : base(payloadCapacity, volume)
        {
        }

        public List<int> Temperature => new List<int> { 3, 4, 5 };
    }
}