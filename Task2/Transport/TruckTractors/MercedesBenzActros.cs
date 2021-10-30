using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.TruckTractors
{
    public class MercedesBenzActros : TruckTractor
    {
        public MercedesBenzActros(double maxWeight) : base(maxWeight)
        {
        }
        public override int FuelConsumption => 26;
    }
}
