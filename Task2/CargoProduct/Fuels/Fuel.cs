namespace CargoProduct.Fuels
{
    public abstract class Fuel : Cargo
    {
        protected Fuel(double payloadCapacity, double volume) : base(payloadCapacity, volume)
        {
        }

        public override double PayloadCapacity { get; set; }
        public override double Volume { get; set; }
    }
}