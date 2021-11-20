using Dishes.Abstract;
using Dishes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dishes.Warehouses
{
    public class WarehouseContainer : IWarehouse
    {
        private readonly IEnumerable<IWarehouse> _warehouses;
        public WarehouseContainer(IEnumerable<IWarehouse> wrehouses)
        {
            _warehouses = wrehouses;
        }

        public int Count => _warehouses.Count();

        public IEnumerable<IWarehouse> AllWarehouses()
        {
            return _warehouses;
        }

        public Product GetProduct(Product product)
        {
            throw new Exception("Failed to get the product");
        }

        public void AddProduct(Product product)
        {
            throw new Exception("Failed to add the product");
        }
    }
}