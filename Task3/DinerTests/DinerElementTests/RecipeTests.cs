using System.Collections.Generic;
using Dishes;
using Dishes.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DinerTests
{
    /// <summary>
    /// Recipe Test
    /// </summary>
    [TestClass()]
    public class RecipeTests
    {
        /// <summary>
        /// Calculates the time and price test.
        /// </summary>
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

        /// <summary>
        /// Adds the product test.
        /// </summary>
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