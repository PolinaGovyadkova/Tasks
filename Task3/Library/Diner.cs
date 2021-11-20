using Dishes;
using Dishes.Abstract;
using Library.People;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Diner
    {
        public Chef Chief { get; set; }
        public Manager Manager { get; set; }
        public Menu Menu { get; set; }

        public Diner() => Chief = new Chef();

        public List<Product> GetIngredientsByTemperature(int temperature)
        {
            var newList = new List<Product>();
            foreach (var t in Menu.Dishes)
            {
                newList.AddRange(t.Recipe.ProductsProcesses.Keys.Where(q => temperature > q.MinTemperature && temperature < q.MaxTemperature));
            }
            return newList;
        }

        public List<Order> GetOrdersByDate(DateTime startDate, DateTime endDate)
        {
            return Manager.Orders.FindAll(x => x.Date > startDate && x.Date < endDate);
        }

        public string CountIngredientsInDishes()
        {
            var ingredients = new List<Product>() { };
            foreach (var order in Manager.Orders)
            {
                ingredients.AddRange(order.Dishes.SelectMany(dish => dish.Recipe.ProductsProcesses.Keys));
            }
            var result = ingredients.GroupBy(item => item.GetType()).Select(item => new
            {
                Name = item.Key,
                Count = item.Count()
            })
                .OrderByDescending(item => item.Count)
                .ThenBy(item => item.GetType());
            var report = String.Join(Environment.NewLine, result
                .Select(item => item.Name).First());

            return report;
        }

        public int CountMethod(Process method)
        {
            var ProcessingMethods = Menu.Dishes.SelectMany(d => d.Recipe.ProductsProcesses.Values).ToList();

            return (ProcessingMethods.Where(pm => pm.GetType() == method.GetType())).Count();
        }

        public List<Process> Processes() => Menu.Dishes.SelectMany(d => d.Recipe.ProductsProcesses.Values).ToList();

        public List<Product> Products() => Menu.Dishes.SelectMany(d => d.Recipe.ProductsProcesses.Keys).ToList();

        public List<Process> MethodsByPrice() => Menu.Dishes.SelectMany(d => d.Recipe.ProductsProcesses.Values).OrderBy(pm => pm.Price).ToList();

        public double ExpensesByTypeAndTime(DateTime start, DateTime finish, Dish dish) => Manager.Orders.Where(o => o.Date >= start && o.Date <= finish).Aggregate<Order, double>(0, (current1, o) => o.Dishes.Where(f => dish == f).Aggregate(current1, (current, f) => current + dish.Price));

        public override bool Equals(object obj) => obj is Diner diner && diner.Chief == Chief && diner.Manager == Manager && diner.Menu == Menu;

        public override int GetHashCode() => unchecked(Manager.GetHashCode() + Chief.GetHashCode() + Menu.GetHashCode());

        public override string ToString() => $"Diner with {Manager}  {Chief} {Menu}";
    }
}