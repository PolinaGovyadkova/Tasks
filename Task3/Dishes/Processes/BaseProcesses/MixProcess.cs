using System;
using Dishes.Abstract;
using Dishes.Processes.ProcessesInterfaces;

namespace Dishes.Processes.BaseProcesses
{
    /// <summary>
    /// MixProcess
    /// </summary>
    /// <seealso cref="Dishes.Abstract.Process" />
    public abstract class MixProcess : Process
    {
        /// <summary>
        /// Gets or sets the load.
        /// </summary>
        /// <value>
        /// The load.
        /// </value>
        public override int Load { get; set; } = 10;
        /// <summary>
        /// Initializes a new instance of the <see cref="MixProcess"/> class.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="price">The price.</param>
        protected MixProcess(TimeSpan time, float price) : base(new TimeSpan(0, 20, 10), 3)
        {
        }

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">this product is not intended for mixing</exception>
        public override Product Update(Product product)
        {
            if (product is IMixProcess)
            {
                product.Size = product.Size;
                product.Weight += product.Weight;
                return product;
            }
            else
            {
                throw new Exception("this product is not intended for mixing");
            }
           
        }
    }
}