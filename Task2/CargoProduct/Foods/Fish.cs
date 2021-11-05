using CargoProduct.BaseCargo;
using System.Collections.Generic;

namespace CargoProduct.Foods
{
    /// <summary>
    /// Fish
    /// </summary>
    /// <seealso cref="CargoProduct.BaseCargo.Food" />
    public class Fish : Food
    {
        /// <summary>
        /// Gets the temperature.
        /// </summary>
        /// <value>
        /// The temperature.
        /// </value>
        public override List<int> Temperature => new List<int> { -25, -24, -23, -22, -21, -20, -19, -18, -17, -16, -15 };
    }
}