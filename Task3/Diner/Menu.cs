using Dishes;
using System.Collections.Generic;
using System.Linq;

namespace Diner
{
    /// <summary>
    /// Menu
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Gets or sets the dishes.
        /// </summary>
        /// <value>
        /// The dishes.
        /// </value>
        public List<Dish> Dishes { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        public Menu() => Dishes = new List<Dish>();

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is Menu menu && menu.Dishes == Dishes;

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            var hash = Dishes.Sum(dshes => dshes.GetHashCode());
            return unchecked(hash);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"Menu with dish id {Dishes}";
    }
}