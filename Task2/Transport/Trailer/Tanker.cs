using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public class Tanker : Semitrailer
    {
        public Tanker(double payloadCapacity, double volume) : base(payloadCapacity, volume)
        {
        }
    }
}
