using Dishes;
using Dishes.Abstract;
using Dishes.Processes;
using Dishes.Products.Ingredients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Diner;
using Diner.People;
using Dishes.Processes.TypeProcesses;

namespace DinerTests
{
    /// <summary>
    /// Diner Tests
    /// </summary>
    [TestClass()]
    public class DinerTests
    {
        /// <summary>
        /// Loads the exception test.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void LoadExceptionTest()
        {
            var products = new List<Product>() { 
                TestHelper.RandomProduct(), 
                TestHelper.RandomProduct(), 
                TestHelper.RandomProduct(), 
                TestHelper.RandomProduct(), 
                TestHelper.RandomProduct(), 
                TestHelper.RandomProduct(), 
                TestHelper.RandomProduct(), 
                TestHelper.RandomProduct(), 
                TestHelper.RandomProduct(), 
                TestHelper.RandomProduct(), 
                TestHelper.RandomProduct(), 
                TestHelper.RandomProduct(), 
                TestHelper.RandomProduct(), 
                TestHelper.RandomProduct(), 
                TestHelper.RandomProduct(), 
                TestHelper.RandomProduct(), 
                TestHelper.RandomProduct(), 
                TestHelper.RandomProduct(), 
                TestHelper.RandomProduct()
            };
            var recipe = new Dictionary<List<Product>, Process>
            {
                {products, TestHelper.RandomProcess(products)}
            };

            Assert.AreEqual(products.Count, TestHelper.CreateDiner(recipe).GetIngredientsByTemperature(6).Count);
        }

        /// <summary>
        /// Gets the ingredients by temperature test.
        /// </summary>
        [TestMethod()]
        public void GetIngredientsByTemperatureTest()
        {
            var products = new List<Product>() { TestHelper.RandomProduct(), TestHelper.RandomProduct() };
            var recipe = new Dictionary<List<Product>, Process>
            {
                {products, TestHelper.RandomProcess(products)}
            };

            Assert.AreEqual(products.Count, TestHelper.CreateDiner(recipe).GetIngredientsByTemperature(4).Count);
        }
        /// <summary>
        /// Gets the orders by date test.
        /// </summary>
        [TestMethod()]
        public void GetOrdersByDateTest()
        {
            var products = new List<Product>() { TestHelper.RandomProduct() };
            var recipe = new Dictionary<List<Product>, Process>
            {
                {products, TestHelper.RandomProcess(products)}
            };

            Assert.AreEqual(1, TestHelper.CreateDiner(recipe).GetOrdersByDate(new DateTime(2019, 8, 10), new DateTime(2022, 8, 18)).Count);
        }

        /// <summary>
        /// Counts the ingredients in dishes test.
        /// </summary>
        [TestMethod()]
        public void CountIngredientsInDishesTest()
        {
            var products = new List<Product>() {  new Tomato(), new PekingCabbage() };
            var recipe = new Dictionary<List<Product>, Process>
            {
                {products, new CutProcessDefault()}
            };

            Product product = new Tomato();
            Assert.AreEqual(product.GetType().ToString(), TestHelper.CreateDiner(recipe).CountIngredientsInDishes());
        }

        /// <summary>
        /// Counts the method test.
        /// </summary>
        [TestMethod()]
        public void CountMethodTest()
        {
            var products = new List<Product>() { TestHelper.RandomProduct() };
            var products1 = new List<Product>() { TestHelper.RandomProduct() };
            var process = TestHelper.RandomProcess(products);
            var process1 = TestHelper.RandomProcess(products1);
            var recipe = new Dictionary<List<Product>, Process>
            {
                {products, process},
                {products1, process1}
            };
            var processesCount = new List<Process>(){process, process1};
            Assert.AreEqual(processesCount.Count, TestHelper.CreateDiner(recipe).CountMethod(process));
        }

        /// <summary>
        /// Processeses the test.
        /// </summary>
        [TestMethod()]
        public void ProcessesTest()
        {
            var products = new List<Product>() { TestHelper.RandomProduct(), TestHelper.RandomProduct(), TestHelper.RandomProduct(), TestHelper.RandomProduct() };
            var products1 = new List<Product>() { TestHelper.RandomProduct(), TestHelper.RandomProduct(), TestHelper.RandomProduct(), TestHelper.RandomProduct() };
            var products2 = new List<Product>() { TestHelper.RandomProduct() };
            var randomProcess = TestHelper.RandomProcess(products);
            var randomProcess1 = TestHelper.RandomProcess(products1);
            var randomProcess2 = TestHelper.RandomProcess(products2);
            var recipe = new Dictionary<List<Product>, Process>
            {
                {products, randomProcess},
                {products1, randomProcess1},
                {products2, randomProcess2}
            };
            var processes = new List<Product>();
            foreach (var element in recipe.Keys)
            {
                processes.AddRange(element);
            }
            Assert.AreEqual(processes.Count, TestHelper.CreateDiner(recipe).Processes().Count);
        }

        /// <summary>
        /// Productses the test.
        /// </summary>
        [TestMethod()]
        public void ProductsTest()
        {
            var products = new List<Product>() { TestHelper.RandomProduct(), TestHelper.RandomProduct(), TestHelper.RandomProduct(), TestHelper.RandomProduct() };
            var products1 = new List<Product>() { TestHelper.RandomProduct(), TestHelper.RandomProduct(), TestHelper.RandomProduct(), TestHelper.RandomProduct() };
            var randomProcess = TestHelper.RandomProcess(products);
            var randomProcess1 = TestHelper.RandomProcess(products1);
            var recipe = new Dictionary<List<Product>, Process>
            {
                {products, randomProcess},
                {products1, randomProcess1},
            };
            var newProducts = new List<Product>();
            foreach (var element in recipe.Keys)
            {
                newProducts.AddRange(element);
            }
            Assert.AreEqual(newProducts.Count, TestHelper.CreateDiner(recipe).Products().Count);
        }


        /// <summary>
        /// Methodses the by price test.
        /// </summary>
        [TestMethod()]
        public void MethodsByPriceTest()
        {
            var products = new List<Product>() { TestHelper.RandomProduct(), TestHelper.RandomProduct(), TestHelper.RandomProduct() };
            var products1 = new List<Product>() { TestHelper.RandomProduct(), TestHelper.RandomProduct()};
            var products2 = new List<Product>() { TestHelper.RandomProduct() };
            var randomProcess = TestHelper.RandomProcess(products);
            var randomProcess1 = TestHelper.RandomProcess(products1);
            var randomProcess2 = TestHelper.RandomProcess(products2);
            var recipe = new Dictionary<List<Product>, Process>
            {
                {products, randomProcess},
                {products1, randomProcess1},
                {products2, randomProcess2}
            };
            
            var processingMethods = new List<Process>
            {
                {randomProcess},
                {randomProcess},
                {randomProcess},
                {randomProcess1},
                {randomProcess1},
                { randomProcess2},
            };
            CollectionAssert.AreEqual(TestHelper.CreateDiner(recipe).MethodsByPrice(), processingMethods);
        }

        /// <summary>
        /// Expenseses the by type and time test.
        /// </summary>
        [TestMethod()]
        public void ExpensesByTypeAndTimeTest()
        {
            var menu = new Menu();
            var firstClient = new Client(0);
            var secondClient = new Client(1);
            var thirdClient = new Client(2);
            var manager = new Manager();
            var diner = new Eatery();
            var products = new List<Product>() { new Tomato(), new Tomato(), new PekingCabbage() };
            var recipe = new Dictionary<List<Product>, Process>
            {
                {products, new CutProcessDefault()}
            };
            var dishRecipe = diner.Chief.MakeNewRecipe(recipe);
            var firstDish = new Dish(dishRecipe, "FirstTestRecipe");
            var secondDish = new Dish(dishRecipe, "SecondTestRecipe");
            var thirdDish = new Dish(dishRecipe, "ThirdTestRecipe");
            menu.Dishes.Add(firstDish);
            menu.Dishes.Add(secondDish);
            menu.Dishes.Add(thirdDish);
            diner.Menu = menu;
            manager.TakeOrder(new DateTime(2020, 10, 12), firstClient, menu);
            manager.TakeOrder(new DateTime(2020, 10, 12), secondClient, menu);
            manager.TakeOrder(new DateTime(2026, 10, 12), thirdClient, menu);
            diner.Manager = manager;

            Assert.AreEqual(102, diner.ExpensesByTypeAndTime(new DateTime(2000, 03, 03), new DateTime(2025, 03, 03), secondDish));
        }
    }
}