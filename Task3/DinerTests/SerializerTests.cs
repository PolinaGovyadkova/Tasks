using System;
using System.Collections.Generic;
using Dishes;
using Dishes.Abstract;
using Dishes.Processes.TypeProcesses;
using Dishes.Products.Ingredients;
using JSONSerialization;
using Library;
using Library.People;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DinerTests
{
    [TestClass()]
    public class SerializerTests
    {
        [TestMethod()]
        public void WriteAndReadTest()
        {
            var menu = new Menu();
            var firstClient = new Client(0);
            var secondClient = new Client(1);
            var thirdClient = new Client(2);
            var manager = new Manager();
            var diner = new Diner();
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
            ISerializer<Diner> dinerSerialize = new Serializer();
           
            Diner diner1 = dinerSerialize.Read();
            dinerSerialize.Write(diner1);
            Assert.AreEqual(diner1.ToString(), diner.ToString());
        }
    }
}