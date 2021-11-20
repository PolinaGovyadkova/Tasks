using Dishes.Abstract;

namespace Dishes.Interfaces
{
    /// <summary>
    /// Warehouse interface
    /// </summary>
    public interface IWarehouse
    {
        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="product">The product.</param>
        void AddProduct(Product product);
        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        Product GetProduct(Product product);
    }
}