using CargoProduct.BaseCargo;
using System.Collections.Generic;

namespace CargoProduct.Foods
{
    /// <summary>
    /// Milk
    /// </summary>
    /// <seealso cref="CargoProduct.BaseCargo.Food" />
    public class Milk : Food
    {
        /// <summary>
        /// Gets the temperature.
        /// </summary>
        /// <value>
        /// The temperature.
        /// </value>
        public override List<int> Temperature => new List<int> { 3, 4, 5 };
    }
}