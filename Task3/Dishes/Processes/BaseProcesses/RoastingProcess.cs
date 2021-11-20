using System;
using Dishes.Abstract;
using Dishes.Processes.ProcessesInterfaces;

namespace Dishes.Processes.BaseProcesses
{
    /// <summary>
    /// RoastingProcess
    /// </summary>
    /// <seealso cref="Dishes.Abstract.Process" />
    public abstract class RoastingProcess : Process
    {
        /// <summary>
        /// Gets or sets the load.
        /// </summary>
        /// <value>
        /// The load.
        /// </value>
        public override int Load { get; set; } = 10;
        /// <summary>
        /// Gets or sets the size coefficient.
        /// </summary>
        /// <value>
        /// The size coefficient.
        /// </value>
        public override int SizeCoefficient { get; set; } = 9;
        /// <summary>
        /// Gets or sets the weight coefficient.
        /// </summary>
        /// <value>
        /// The weight coefficient.
        /// </value>
        public override int WeightCoefficient { get; set; } = 5;
        /// <summary>
        /// Initializes a new instance of the <see cref="RoastingProcess"/> class.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="price">The price.</param>
        protected RoastingProcess(TimeSpan time, float price) : base(new TimeSpan(0, 30, 10), 30)
        {
        }

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">this product is not intended for roasting</exception>
        public override Product Update (Product product)
        {
            if (product is IRoastingProcess)
            {
                product.Size += SizeCoefficient;
                product.Weight += WeightCoefficient;
                return product;
            }
            else throw new Exception("this product is not intended for roasting");
        }
    }
}