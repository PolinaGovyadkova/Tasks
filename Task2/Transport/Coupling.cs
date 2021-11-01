using Transport.Trailer;
using Transport.TruckTractors;

namespace Transport
{
    public class Coupling
    {
        public TruckTractor TruckTractor { get; set; }
        public Semitrailer Semitrailer { get; set; }
        private const double arg = 1.9;

        public Coupling(TruckTractor truckTractor, Semitrailer semitrailer)
        {
            TruckTractor = truckTractor;
            Semitrailer = semitrailer;
        }

        public double FuelConsumptionValue => TruckTractor.FuelConsumption + Semitrailer.TotalWeight / 1000 * arg;

        public override string ToString() => $"Автопоезд {TruckTractor} с расходом топлива {FuelConsumptionValue}";
    }
}