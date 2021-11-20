using Dishes.Abstract;

namespace Dishes.Interfaces
{
    public interface IWarehouse
    {
        void AddProduct(Product product);
        Product GetProduct(Product product);
    }
}