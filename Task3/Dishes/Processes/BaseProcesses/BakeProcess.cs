using System;
using Dishes.Abstract;
using Dishes.Processes.ProcessesInterfaces;

namespace Dishes.Processes.BaseProcesses
{
    /// <summary>
    /// BakeProcess
    /// </summary>
    /// <seealso cref="Dishes.Abstract.Process" />
    public abstract class BakeProcess : Process
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
        public override int SizeCoefficient { get; set; } = 2;
        /// <summary>
        /// Gets or sets the weight coefficient.
        /// </summary>
        /// <value>
        /// The weight coefficient.
        /// </value>
        public override int WeightCoefficient { get; set; } = 2;

        /// <summary>
        /// Initializes a new instance of the <see cref="BakeProcess"/> class.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="price">The price.</param>
        protected BakeProcess(TimeSpan time, float price) : base(new TimeSpan(0,20,10), 10)
        {
        }
        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">This product is not intended for baking</exception>
        public override Product Update(Product product)
        {
          
            if (product is IBakeProcess)
            {
                product.Size += SizeCoefficient;
                product.Weight += WeightCoefficient;
                return product;
            }
            else
            {
                throw new Exception("This product is not intended for baking ");
            }
        }
    }
}