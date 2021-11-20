using System;
using Dishes.Processes.BaseProcesses;

namespace Dishes.Processes.TypeProcesses
{
    /// <summary>
    /// CutProcessDefault
    /// </summary>
    /// <seealso cref="Dishes.Processes.BaseProcesses.CutProcess" />
    public class CutProcessDefault : CutProcess
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CutProcessDefault"/> class.
        /// </summary>
        public CutProcessDefault() : base(new TimeSpan(0, 15, 10), 20)
        {
        }
    }
}