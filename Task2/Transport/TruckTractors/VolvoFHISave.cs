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