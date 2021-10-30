using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProduct
{
    public abstract class Cargo
    {
        public abstract double PayloadCapacity { get; set; }
        public abstract double Volume { get; set; }
    }
}
