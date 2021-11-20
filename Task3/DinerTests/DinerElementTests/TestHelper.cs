using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diner;
using Diner.People;
using Dishes;
using Dishes.Abstract;
using Dishes.Processes;
using Dishes.Processes.ProcessesInterfaces;
using Dishes.Processes.TypeProcesses;
using Dishes.Products.Drinks;
using Dishes.Products.Ingredients;

namespace DinerTests
{
    /// <summary>
    /// Test Helper
    /// </summary>
    public static class TestHelper
    {

        /// <summary>
        /// Randoms the item.
        /// </summary>
        /// <returns></returns>
        public static int RandomItem()
        {
            var rnd = new Random();
            var value = rnd.Next(0, 17);
            return value;
        }

        /// <summary>
        /// Randoms the product.
        /// </summary>
        /// <returns></returns>
        public static Product RandomProduct()
        {
            switch (RandomItem())
            {
                case 1: return new PekingCabbage();
                case 2: return new Meet();
                case 3: return new GarlicSauce();
                case 4: return new Salt();
                default: return new Tomato();
            }
        }


        /// <summary>
        /// Randoms the process.
        /// </summary>
        /// <param name="products">The products.</param>
        /// <returns></returns>
        public static Process RandomProcess(List<Product> products)
        {
            foreach (var t in products)
            {
                switch (t)
                {
                    case IRoastingProcess _:
                        return new RoastingProcessRare();

                    case IMixProcess _:
                        return new MixProcessDefault();

                    default:
                        return new CutProcessDefault();
                }
            }

            return null;
        }

        /// <summary>
        /// Creates the diner.
        /// </summary>
        /// <param name="recipe">The recipe.</param>
        /// <returns></returns>
        public static Eatery CreateDiner(Dictionary<List<Product>, Process> recipe)
        {
            var menu = new Menu();
            var firstClient = new Client(0);
            var manager = new Manager();
            var diner = new Eatery();

            var dishRecipe = diner.Chief.MakeNewRecipe(recipe);
            var firstDish = new Dish(dishRecipe, "Recipe");
            menu.Dishes.Add(firstDish);
            diner.Menu = menu;
            manager.TakeOrder(new DateTime(2020, 10, 12), firstClient, menu);
            diner.Manager = manager;
            return diner;
        }

    }
}
