using Dishes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Order
    {
        private float _summaryPrice;
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Dish> Dishes = new List<Dish>();

        public Order(DateTime date, int id)
        {
            _summaryPrice = 0;
            Id = id;
            Date = date;
        }

        public void AddDish(Dish dish)
        {
            Dishes.Add(dish);
            CalculatePrice();
        }

        public void CalculatePrice()
        {
            foreach (var dish in Dishes)
            {
                _summaryPrice += dish.Price;
            }
        }

        public float GetPrice()
        {
            CalculatePrice();
            return _summaryPrice;
        }

        public override bool Equals(object obj) => obj is Order order && order.Date == Date && order.Dishes == Dishes;

        public override int GetHashCode()
        {
            var hash = Dishes.Sum(dishes => dishes.GetHashCode());
            return unchecked(Date.GetHashCode() + hash);
        }

        public override string ToString() => $"Order contain {Dishes} on {Date}";
    }
}