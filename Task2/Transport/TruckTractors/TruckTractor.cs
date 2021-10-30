using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.TruckTractors
{
    public abstract class TruckTractor
    {
        public TruckTractor(double maxWeight) => MaxWeight = maxWeight;
        public double MaxWeight { get; set; }
        public abstract int FuelConsumption { get; }
    }
}
