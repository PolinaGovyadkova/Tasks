using System;
using Dishes.Abstract;
using Dishes.Interfaces;

namespace Dishes.Processes.BaseProcesses
{
    /// <summary>
    /// AddProcess
    /// </summary>
    /// <seealso cref="Dishes.Abstract.Process" />
    public class AddProcess : Process
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddProcess"/> class.
        /// </summary>
        public AddProcess() : base(new TimeSpan(0,10,0), 0)
        {
        }

        /// <summary>
        /// Gets or sets the load.
        /// </summary>
        /// <value>
        /// The load.
        /// </value>
        public override int Load { get; set; } = 10;

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">This product is not intended to be added</exception>
        public override Product Update (Product product)
        {
            return product is IAddProcess ? product : throw new Exception("This product is not intended to be added");
        }
    }
}