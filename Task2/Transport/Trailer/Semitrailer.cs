using CargoProduct;

namespace Transport.Trailer
{
    public abstract class Semitrailer : ITransport
    {
        protected Semitrailer(double payloadCapacity, double volume)
        {
            PayloadCapacity = payloadCapacity;
            Volume = volume;
        }

        protected Cargo CurrentCargo;
        private const int BasePayloadCapacity = 200;
        public double PayloadCapacity { get; set; }
        public double Volume { get; set; }
        public double FreeWeight => PayloadCapacity - CurrentCargo?.PayloadCapacity ?? PayloadCapacity;
        public double FreeVolume => Volume - CurrentCargo?.Volume ?? Volume;

        public Cargo Cargo
        {
            get => CurrentCargo;
            set => CurrentCargo = value;
        }

        public double TotalWeight => BasePayloadCapacity + CurrentCargo?.PayloadCapacity ?? BasePayloadCapacity;

        public override string ToString()
        {
            return $"Полуприцеп {GetType().Name} с грузоподъёмностью {PayloadCapacity} и вместимым объёмом {Volume}";
        }
    }
}