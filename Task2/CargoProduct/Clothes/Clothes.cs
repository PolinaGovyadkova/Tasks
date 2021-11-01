namespace CargoProduct
{
    public abstract class Clothes : Cargo
    {
        protected Clothes(double payloadCapacity, double volume) : base(payloadCapacity, volume)
        {
        }

        public override double PayloadCapacity { get; set; }
        public override double Volume { get; set; }
    }
}