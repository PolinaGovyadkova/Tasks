using Dishes;
using Dishes.Abstract;
using System;
using System.Collections.Generic;

namespace Diner.People
{
    /// <summary>
    /// Eatery Chef
    /// </summary>
    public class Chef
    {
        /// <summary>
        /// Makes the new recipe.
        /// </summary>
        /// <param name="recipe">The recipe.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">This device does not interfere with {property.Key.Count} ingredients</exception>
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

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is Chef;

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"Chef ";
    }
}