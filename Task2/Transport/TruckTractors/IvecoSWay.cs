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