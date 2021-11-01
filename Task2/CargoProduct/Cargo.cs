namespace CargoProduct
{
    public abstract class Cargo
    {
        protected Cargo(double payloadCapacity, double volume)
        {
            PayloadCapacity = payloadCapacity;
            Volume = volume;
        }

        public abstract double PayloadCapacity { get; set; }
        public abstract double Volume { get; set; }

        public override string ToString()
        {
            return $"Груз {GetType().Name} объёмом {Volume} и массой {PayloadCapacity}";
        }
    }
}