using System;
using System.Collections.Generic;
using System.Linq;
using Diner.People;
using Dishes;
using Dishes.Abstract;

namespace Diner
{
    /// <summary>
    /// Eatery
    /// </summary>
    public class Eatery
    {
        /// <summary>
        /// Gets or sets the chief.
        /// </summary>
        /// <value>
        /// The chief.
        /// </value>
        public Chef Chief { get; set; }
        /// <summary>
        /// Gets or sets the manager.
        /// </summary>
        /// <value>
        /// The manager.
        /// </value>
        public Manager Manager { get; set; }
        /// <summary>
        /// Gets or sets the menu.
        /// </summary>
        /// <value>
        /// The menu.
        /// </value>
        public Menu Menu { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Eatery"/> class.
        /// </summary>
        public Eatery() => Chief = new Chef();

        /// <summary>
        /// Gets the ingredients by temperature.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <returns></returns>
        public List<Product> GetIngredientsByTemperature(int temperature)
        {
            var newList = new List<Product>();
            foreach (var t in Menu.Dishes)
            {
                newList.AddRange(t.Recipe.ProductsProcesses.Keys.Where(q => temperature > q.MinTemperature && temperature < q.MaxTemperature));
            }
            return newList;
        }

        /// <summary>
        /// Gets the orders by date.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        public List<Order> GetOrdersByDate(DateTime startDate, DateTime endDate)
        {
            return Manager.Orders.FindAll(x => x.Date > startDate && x.Date < endDate);
        }

        /// <summary>
        /// Counts the ingredients in dishes.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Counts the method.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        public int CountMethod(Process method)
        {
            var ProcessingMethods = Menu.Dishes.SelectMany(d => d.Recipe.ProductsProcesses.Values).ToList();

            return (ProcessingMethods.Where(pm => pm.GetType() == method.GetType())).Count();
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        /// <returns></returns>
        public List<Process> Processes() => Menu.Dishes.SelectMany(d => d.Recipe.ProductsProcesses.Values).ToList();

        /// <summary>
        /// Products this instance.
        /// </summary>
        /// <returns></returns>
        public List<Product> Products() => Menu.Dishes.SelectMany(d => d.Recipe.ProductsProcesses.Keys).ToList();

        /// <summary>
        /// Methods the by price.
        /// </summary>
        /// <returns></returns>
        public List<Process> MethodsByPrice() => Menu.Dishes.SelectMany(d => d.Recipe.ProductsProcesses.Values).OrderBy(pm => pm.Price).ToList();

        /// <summary>
        /// Expenses the by type and time.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="finish">The finish.</param>
        /// <param name="dish">The dish.</param>
        /// <returns></returns>
        public double ExpensesByTypeAndTime(DateTime start, DateTime finish, Dish dish) => Manager.Orders.Where(o => o.Date >= start && o.Date <= finish).Aggregate<Order, double>(0, (current1, o) => o.Dishes.Where(f => dish == f).Aggregate(current1, (current, f) => current + dish.Price));

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is Eatery diner && diner.Chief == Chief && diner.Manager == Manager && diner.Menu == Menu;

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => unchecked(Manager.GetHashCode() + Chief.GetHashCode() + Menu.GetHashCode());

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"Diner with {Manager}  {Chief} {Menu}";
    }
}