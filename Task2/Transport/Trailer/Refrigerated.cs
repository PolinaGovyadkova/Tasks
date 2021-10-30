using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Trailer
{
    public class Refrigerated : Semitrailer
    {
        public Refrigerated(double payloadCapacity, double volume) : base(payloadCapacity, volume)
        {
        }
    }
}
