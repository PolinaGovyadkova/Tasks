using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.TruckTractors
{
    public class VolvoFHISave : TruckTractor
    {
        public VolvoFHISave(double maxWeight) : base(maxWeight)
        {
        }

        public override int FuelConsumption => 6;
    }
}
