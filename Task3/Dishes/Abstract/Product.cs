using Dishes.Interfaces;

namespace Dishes.Abstract
{
    public abstract class Product :Temperature, IProduct
    {
        protected Product(float price, int maxTemperature, int minTemperature, float size, float weight)
        {
            Price = price;
            Size = size;
            Weight = weight;
            MaxTemperature = maxTemperature;
            MinTemperature = minTemperature;
        }

        public float Size { get; set; }
        public float Weight { get; set; }
        public float Price { get; set; }
        public override bool Equals(object obj) => obj is Product product && product.Size == Size && product.Weight == Weight && product.Price == Price;
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => GetType().Name;
    }
}