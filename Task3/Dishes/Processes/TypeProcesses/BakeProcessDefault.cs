using System;
using Dishes.Processes.BaseProcesses;

namespace Dishes.Processes.TypeProcesses
{
    /// <summary>
    /// BakeProcessDefault
    /// </summary>
    /// <seealso cref="Dishes.Processes.BaseProcesses.BakeProcess" />
    public class BakeProcessDefault : BakeProcess
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BakeProcessDefault"/> class.
        /// </summary>
        public BakeProcessDefault() : base(new TimeSpan(0, 25, 10), 30)
        {
        }
    }
}