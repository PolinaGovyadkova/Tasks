using Dishes.Interfaces;

namespace Dishes
{
    /// <summary>
    /// Dish
    /// </summary>
    /// <seealso cref="Dishes.Interfaces.IDish" />
    public class Dish : IDish
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dish"/> class.
        /// </summary>
        /// <param name="recipe">The recipe.</param>
        /// <param name="name">The name.</param>
        public Dish(Recipe recipe, string name)
        {
            Name = name;
            Recipe = recipe;
        }

        /// <summary>
        /// Gets or sets the recipe.
        /// </summary>
        /// <value>
        /// The recipe.
        /// </value>
        public Recipe Recipe { get; set; }
        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public float Price => Recipe.Price;
        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        public float Weight { get; set; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public float Size { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is Dish dish && dish.Recipe == Recipe && dish.Price == Price && dish.Weight == Weight && dish.Size == Size && dish.Name == Name;

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return unchecked(Recipe.GetHashCode() + Price.GetHashCode() + Weight.GetHashCode() + Size.GetHashCode() + Name.GetHashCode());
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