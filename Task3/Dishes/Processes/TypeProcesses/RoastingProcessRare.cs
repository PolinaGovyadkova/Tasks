using System;
using Dishes.Processes.BaseProcesses;

namespace Dishes.Processes.TypeProcesses
{
    public class RoastingProcessRare : RoastingProcess
    {
        public RoastingProcessRare() : base(new TimeSpan(0, 12, 10), 30)
        {
        }
    }
}