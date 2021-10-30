using CargoProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public abstract class Semitrailer
    {
        public Semitrailer(double payloadCapacity, double volume)
        {
            PayloadCapacity = payloadCapacity;
            Volume = volume;
        }
        protected Cargo currentCargo;
        private const int basePayloadCapacity = 200;
        public double PayloadCapacity { get; set; }
        public double Volume { get; set; }
        public double FreeWeight => currentCargo is null ? PayloadCapacity : PayloadCapacity - currentCargo.PayloadCapacity;
        public double FreeVolume => currentCargo is null ? Volume : Volume - currentCargo.Volume;
        public Cargo Cargo
        {
            get => currentCargo;
            set => currentCargo = value;
        }
        public double TotalWeight => currentCargo is null ? basePayloadCapacity : basePayloadCapacity + currentCargo.PayloadCapacity;
    }
}
