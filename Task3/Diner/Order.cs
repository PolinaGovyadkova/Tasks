using Dishes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Diner
{
    /// <summary>
    /// Order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// The summary price
        /// </summary>
        private float _summaryPrice;
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; set; }
        /// <summary>
        /// The dishes
        /// </summary>
        public List<Dish> Dishes = new List<Dish>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="id">The identifier.</param>
        public Order(DateTime date, int id)
        {
            _summaryPrice = 0;
            Id = id;
            Date = date;
        }

        /// <summary>
        /// Adds the dish.
        /// </summary>
        /// <param name="dish">The dish.</param>
        public void AddDish(Dish dish)
        {
            Dishes.Add(dish);
            CalculatePrice();
        }

        /// <summary>
        /// Calculates the price.
        /// </summary>
        public void CalculatePrice()
        {
            foreach (var dish in Dishes)
            {
                _summaryPrice += dish.Price;
            }
        }

        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <returns></returns>
        public float GetPrice()
        {
            CalculatePrice();
            return _summaryPrice;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is Order order && order.Date == Date && order.Dishes == Dishes;

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            var hash = Dishes.Sum(dishes => dishes.GetHashCode());
            return unchecked(Date.GetHashCode() + hash);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"Order contain {Dishes} on {Date}";
    }
}