namespace CargoProduct.Foods
{
    public abstract class Food : Cargo
    {
        protected Food(double payloadCapacity, double volume) : base(payloadCapacity, volume)
        {
        }

        public override double PayloadCapacity { get; set; }
        public override double Volume { get; set; }
    }
}