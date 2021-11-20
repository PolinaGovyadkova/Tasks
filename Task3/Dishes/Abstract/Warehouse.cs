using Dishes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dishes.Abstract
{
    /// <summary>
    /// Warehouse
    /// </summary>
    /// <seealso cref="Dishes.Interfaces.IWarehouse" />
    public abstract class Warehouse : IWarehouse
    {
        /// <summary>
        /// Gets or sets the maximum temperature.
        /// </summary>
        /// <value>
        /// The maximum temperature.
        /// </value>
        private int MaxTemperature { get; set; } = 1000;
        /// <summary>
        /// Gets or sets the minimum temperature.
        /// </summary>
        /// <value>
        /// The minimum temperature.
        /// </value>
        private int MinTemperature { get; set; } = -1000;
        /// <summary>
        /// The products
        /// </summary>
        public List<Product> Products = new List<Product>();

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <exception cref="System.Exception">Failed to add the product</exception>
        public void AddProduct(Product product)
        {
            if (product != null && product.MaxTemperature <= MaxTemperature && product.MinTemperature >= MinTemperature) Products.Add(product);
            else throw new Exception("Failed to add the product");
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Failed to get the product</exception>
        public Product GetProduct(Product product)
        {
            foreach (var elementProduct in Products.Where(elementProduct => elementProduct == product))
            {
                return elementProduct;
            }

            throw new Exception("Failed to get the product");
        }
    }
}