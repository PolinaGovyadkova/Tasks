using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProduct.Fuels
{
    public abstract class Fuel : Cargo
    {
        public Fuel(double payloadCapacity, double volume)
        {
            PayloadCapacity = payloadCapacity;
            Volume = volume;
        }
        public override double PayloadCapacity { get; set; }
        public override double Volume { get; set; }
    }
}
