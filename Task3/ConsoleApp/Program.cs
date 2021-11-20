using Dishes;
using Dishes.Abstract;
using Dishes.Processes;
using Dishes.Products.Ingredients;
using Library;
using Library.People;
using System;
using System.Collections.Generic;
using Dishes.Processes.TypeProcesses;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Product product = new PekingCabbage();
            Process process = new CutProcessDefault();
            Console.WriteLine(product.Size);
            var menu = new Menu();
            var client = new Client(1);
            var cliet1 = new Client(0);
            var manager = new Manager();

            var recipe = new Dictionary<List<Product>, Process>
            {
                {new List<Product>() {new Tomato(), new PekingCabbage()}, new CutProcessDefault()},
                {new List<Product>() {new Tomato()}, new CutProcessDefault()}
            };

            var recipe1 = new Dictionary<List<Product>, Process>
            {
                {new List<Product>() {new PekingCabbage(), new Meet(), new Meet(), new Meet(), new Meet()}, new CutProcessDefault()}
            };

            var diner = new Diner();
            var dishRecipe = diner.Chief.MakeNewRecipe(recipe);
            var dishRecipe1 = diner.Chief.MakeNewRecipe(recipe1);
            

            var dish = new Dish(dishRecipe, "PekingCabbage with Tomato");
            var dish1 = new Dish(dishRecipe1, "Meet with PekingCabbage");
            menu.Dishes.Add(dish);
            menu.Dishes.Add(dish1);
            diner.Menu = menu;

            manager.TakeOrder(new DateTime(2020, 10, 12), client, menu);
            manager.TakeOrder(new DateTime(2021, 11, 11), cliet1, menu);
            diner.Manager = manager;
            var productTemp = diner.GetIngredientsByTemperature(5);
            var date = diner.GetOrdersByDate(new DateTime(2020, 10, 12), new DateTime(2021, 11, 11));

            var ingrcount = diner.CountIngredientsInDishes();
            
            var count = diner.CountMethod(process);
          
                foreach (var t in dish1.Recipe.ProductsProcesses.Keys)
                {
                    Console.WriteLine(t.Size);
                }
                

            
            Console.WriteLine(count + " count");
            Console.WriteLine("\n _______________________");

            Console.WriteLine(ingrcount + " is popular");

            foreach (var k in date)
            {
                Console.WriteLine(k + " date");
            }
            foreach (var t in productTemp)
            {
                Console.WriteLine(t.GetType());
            }
            Console.WriteLine("\n _______________________");
            foreach (var element in manager.Orders)
            {
                foreach (var t in element.Dishes)
                {
                    Console.WriteLine(t.Name);
                    Console.WriteLine("Рецепт");
                    t.Recipe.CalculateTimeAndPrice();
                    Console.WriteLine("Time " + t.Recipe.Time);
                    Console.WriteLine("Price " + t.Recipe.Price);
                    foreach (var key in t.Recipe.ProductsProcesses)
                    {
                        Console.WriteLine();
                        Console.WriteLine(key.Key + " " + key.Value);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}