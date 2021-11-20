using System;
using Dishes.Processes.BaseProcesses;

namespace Dishes.Processes.TypeProcesses
{
    public class BakeProcessDefault : BakeProcess
    {
        public BakeProcessDefault() : base(new TimeSpan(0, 25, 10), 30)
        {
        }
    }
}