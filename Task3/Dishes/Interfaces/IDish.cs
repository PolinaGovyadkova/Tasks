namespace Dishes.Interfaces
{
    /// <summary>
    /// Dish interface
    /// </summary>
    public interface IDish
    {
        /// <summary>
        /// Gets or sets the recipe.
        /// </summary>
        /// <value>
        /// The recipe.
        /// </value>
        Recipe Recipe { get; set; }
        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        float Weight { get; set; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        float Size { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
    }
}