using System;
using Dishes.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Dishes
{
    /// <summary>
    /// Recipe
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public float Price { get; set; }
        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public TimeSpan Time { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// The products processes
        /// </summary>
        public Dictionary<Product, Process> ProductsProcesses;

        /// <summary>
        /// Initializes a new instance of the <see cref="Recipe"/> class.
        /// </summary>
        public Recipe()
        {
            ProductsProcesses = new Dictionary<Product, Process>();
        }

        /// <summary>
        /// Calculates the time and price.
        /// </summary>
        public void CalculateTimeAndPrice()
        {
            var time = new TimeSpan();
            float price = 0;
            foreach (var ingredient in ProductsProcesses)
            {
                price += ingredient.Value.Price + ingredient.Key.Price;
                time += ingredient.Value.Time;
            }
            Price = price;
            Time = time;
        }

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="process">The process.</param>
        public void AddProduct(Product product, Process process)
        {
            ProductsProcesses.Add(process.Update(product), process);
            CalculateTimeAndPrice();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is Recipe recipe && recipe.ProductsProcesses == ProductsProcesses && recipe.Price == Price && recipe.Time == Time;

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            var hash = ProductsProcesses.Sum(elementProductsProcess => elementProductsProcess.Key.GetHashCode() + elementProductsProcess.Value.GetHashCode());
            return unchecked(Price.GetHashCode() + Time.GetHashCode() + hash + Name.GetHashCode());
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"Dish  {Name} with {Price}";
        }
    }
}