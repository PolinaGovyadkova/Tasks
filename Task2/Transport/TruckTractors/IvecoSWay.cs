using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.TruckTractors
{
    public class IvecoSWay : TruckTractor
    {
        public IvecoSWay(double maxWeight) : base(maxWeight)
        {
        }

        public override int FuelConsumption => 16;
    }
}
