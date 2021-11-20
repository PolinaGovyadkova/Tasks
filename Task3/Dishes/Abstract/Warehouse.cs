using Dishes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dishes.Abstract
{
    public abstract class Warehouse : IWarehouse
    {
        private int MaxTemperature { get; set; } = 1000;
        private int MinTemperature { get; set; } = -1000;
        public List<Product> Products = new List<Product>();

        public void AddProduct(Product product)
        {
            if (product != null && product.MaxTemperature <= MaxTemperature && product.MinTemperature >= MinTemperature) Products.Add(product);
            else throw new Exception("Failed to add the product");
        }

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