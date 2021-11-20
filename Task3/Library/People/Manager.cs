using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.People
{
    public class Manager
    {
        public List<Order> Orders = new List<Order>();

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

        public override bool Equals(object obj) => obj is Manager manager && manager.Orders == Orders;

        public override int GetHashCode()
        {
            var hash = Orders.Sum(order => order.GetHashCode());
            return unchecked(hash);
        }

        public override string ToString()
        {
            return $"Manager with {Orders} ";
        }
    }
}