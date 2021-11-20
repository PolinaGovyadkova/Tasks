using System.Collections.Generic;
using Dishes;
using Dishes.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DinerTests
{
    [TestClass()]
    public class RecipeTests
    {
        [TestMethod()]
        public void CalculateTimeAndPriceTest()
        {
            var recipe = new Recipe();
            var product = TestHelper.RandomProduct();
            var products = new List<Product>() { product };
            var process = TestHelper.RandomProcess(products);
            var processesAndProducts = new Dictionary<Product, Process>
            {
                {product, process}
            };
            recipe.AddProduct(product, process);

            Assert.AreEqual(process.Price + product.Price, recipe.Price);
            Assert.AreEqual(process.Time, recipe.Time);
        }

        [TestMethod()]
        public void AddProductTest()
        {
            var recipe = new Recipe();
            var product = TestHelper.RandomProduct();
            var products = new List<Product>(){ product };
            var process = TestHelper.RandomProcess(products);
            var processesAndProducts = new Dictionary<Product, Process>
            {
                {product, process}
            };
            recipe.AddProduct(product, process);

            CollectionAssert.AreEqual(processesAndProducts, recipe.ProductsProcesses);
        }

    }
}