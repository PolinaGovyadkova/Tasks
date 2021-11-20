using Dishes;
using Dishes.Abstract;
using System;
using System.Collections.Generic;

namespace Library.People
{
    public class Chef
    {
        public Recipe MakeNewRecipe(Dictionary<List<Product>, Process> recipe)
        {
            var newRecipe = new Recipe();
            foreach (var property in recipe)
            {
                if (property.Value.Load < property.Key.Count) throw new Exception($"This device does not interfere with {property.Key.Count} ingredients");
                else
                {
                    foreach (var key in property.Key)
                    {
                        newRecipe.AddProduct(key, property.Value);
                    }
                }
            }
            return newRecipe;
        }

        public override bool Equals(object obj) => obj is Chef;

        public override int GetHashCode() => base.GetHashCode();

        public override string ToString() => $"Chef ";
    }
}