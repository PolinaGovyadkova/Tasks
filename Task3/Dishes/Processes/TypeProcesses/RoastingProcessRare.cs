using System;
using Dishes.Processes.BaseProcesses;

namespace Dishes.Processes.TypeProcesses
{
    /// <summary>
    /// RoastingProcessRare
    /// </summary>
    /// <seealso cref="Dishes.Processes.BaseProcesses.RoastingProcess" />
    public class RoastingProcessRare : RoastingProcess
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoastingProcessRare"/> class.
        /// </summary>
        public RoastingProcessRare() : base(new TimeSpan(0, 12, 10), 30)
        {
        }
    }
}