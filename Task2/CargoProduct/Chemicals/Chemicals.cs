namespace CargoProduct.Chemicals
{
    public abstract class Chemicals : Cargo
    {
        protected Chemicals(double payloadCapacity, double volume) : base(payloadCapacity, volume)
        {
        }

        public override double PayloadCapacity { get; set; }
        public override double Volume { get; set; }
    }
}