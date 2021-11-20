using System;
using Dishes.Processes.BaseProcesses;

namespace Dishes.Processes.TypeProcesses
{
    /// <summary>
    /// MixProcessDefault
    /// </summary>
    /// <seealso cref="Dishes.Processes.BaseProcesses.MixProcess" />
    public class MixProcessDefault : MixProcess
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MixProcessDefault"/> class.
        /// </summary>
        public MixProcessDefault() : base(new TimeSpan(0, 6, 10), 3)
        {
        }
    }
}