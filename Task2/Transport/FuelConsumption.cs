using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public class FuelConsumption 
    {
        public TruckTractor TruckTractor { get; set; }
        public Semitrailer Semitrailer { get; set; }
        private const double extraRate = 1.9;
        public FuelConsumption(TruckTractor truckTractor, Semitrailer semitrailer)
        {
            TruckTractor = truckTractor;
            Semitrailer = semitrailer;
        }
        public double FuelConsumptionValue => TruckTractor.FuelConsumption + Semitrailer.TotalWeight / 1000 * extraRate;

    }
}
