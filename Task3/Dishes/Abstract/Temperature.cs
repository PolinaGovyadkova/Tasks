using Dishes.Interfaces;

namespace Dishes.Abstract
{
    public abstract class Temperature : ITemperature
    {
        public int MaxTemperature { get; set; }
        public int MinTemperature { get; set; }
        public override bool Equals(object obj) => obj is Temperature temperature && temperature.MinTemperature == MinTemperature && temperature.MinTemperature == MinTemperature;
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => $"Min Temperature {MinTemperature} and Max Temperature {MaxTemperature}";
    }
}