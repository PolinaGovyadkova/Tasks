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