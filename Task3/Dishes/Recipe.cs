using System;
using Dishes.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Dishes
{
    public class Recipe
    {
        public float Price { get; set; }
        public TimeSpan Time { get; set; }
        public string Name { get; set; }
        public Dictionary<Product, Process> ProductsProcesses;

        public Recipe()
        {
            ProductsProcesses = new Dictionary<Product, Process>();
        }

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

        public void AddProduct(Product product, Process process)
        {
            ProductsProcesses.Add(process.Update(product), process);
            CalculateTimeAndPrice();
        }

        public override bool Equals(object obj) => obj is Recipe recipe && recipe.ProductsProcesses == ProductsProcesses && recipe.Price == Price && recipe.Time == Time;

        public override int GetHashCode()
        {
            var hash = ProductsProcesses.Sum(elementProductsProcess => elementProductsProcess.Key.GetHashCode() + elementProductsProcess.Value.GetHashCode());
            return unchecked(Price.GetHashCode() + Time.GetHashCode() + hash + Name.GetHashCode());
        }

        public override string ToString()
        {
            return $"Dish  {Name} with {Price}";
        }
    }
}