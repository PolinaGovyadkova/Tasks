namespace Transport.TruckTractors
{
    public abstract class TruckTractor : ITransport
    {
        protected TruckTractor(double maxWeight) => PayloadCapacity = maxWeight;

        public abstract int FuelConsumption { get; }
        public double PayloadCapacity { get; set; }
    }
}