using System.Collections.Generic;
using Dishes.Abstract;
using Dishes.Interfaces;
using Dishes.Processes.BaseProcesses;
using Dishes.Processes.TypeProcesses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DinerTests.Processes.BaseProcesses
{
    /// <summary>
    /// All Updates Tests
    /// </summary>
    [TestClass()]
    public class AllUpdatesTest
    {
        /// <summary>
        /// Updates tests.
        /// </summary>
        [TestMethod()]
        public void UpdateTest()
        {
            Product productRandom = TestHelper.RandomProduct();
            var productList = new List<Product>() { productRandom };
            Process process = TestHelper.RandomProcess(productList);
            foreach (var product in productList)
            {
                var updatedProduct = process.Update(product);
                product.Weight += process.WeightCoefficient;
                product.Size += process.SizeCoefficient;
                Assert.AreEqual(product.Weight, updatedProduct.Weight);
                Assert.AreEqual(product.Size, updatedProduct.Size);
            }
        }
    }
}