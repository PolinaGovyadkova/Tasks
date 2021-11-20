using System;
using System.Collections.Generic;
using System.Linq;

namespace Diner.People
{
    /// <summary>
    /// Eatery Maneger
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// The orders
        /// </summary>
        public List<Order> Orders = new List<Order>();

        /// <summary>
        /// Takes the order.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="client">The client.</param>
        /// <param name="menu">The menu.</param>
        public void TakeOrder(DateTime date, Client client, Menu menu)
        {
            var order = new Order(date, client.Id);

            foreach (var i in client.DishName)
            {
                for (var j = 0; j < menu.Dishes.Count; j++)
                {
                    if (i == j)
                    {
                        order.AddDish(menu.Dishes.ElementAt(i));
                        Orders.Add(order);
                    }
                }
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is Manager manager && manager.Orders == Orders;

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            var hash = Orders.Sum(order => order.GetHashCode());
            return unchecked(hash);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"Manager with {Orders} ";
        }
    }
}