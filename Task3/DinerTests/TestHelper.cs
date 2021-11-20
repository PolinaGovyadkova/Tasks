using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dishes;
using Dishes.Abstract;
using Dishes.Processes;
using Dishes.Processes.ProcessesInterfaces;
using Dishes.Processes.TypeProcesses;
using Dishes.Products.Drinks;
using Dishes.Products.Ingredients;
using Library;
using Library.People;

namespace DinerTests
{
    public static class TestHelper
    {

        public static int RandomItem()
        {
            var rnd = new Random();
            var value = rnd.Next(0, 17);
            return value;
        }

        public static Product RandomProduct()
        {
            switch (RandomItem())
            {
                case 1: return new PekingCabbage();
                case 2: return new Meet();
                case 3: return new GarlicSauce();
                case 4: return new Water();
                case 5: return new Salt();
                default: return new Tomato();
            }
        }


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

        public static Diner CreateDiner(Dictionary<List<Product>, Process> recipe)
        {
            var menu = new Menu();
            var firstClient = new Client(0);
            var manager = new Manager();
            var diner = new Diner();

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
