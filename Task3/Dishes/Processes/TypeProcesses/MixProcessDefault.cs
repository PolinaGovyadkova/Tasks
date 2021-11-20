using System;
using Dishes.Processes.BaseProcesses;

namespace Dishes.Processes.TypeProcesses
{
    public class MixProcessDefault : MixProcess
    {
        public MixProcessDefault() : base(new TimeSpan(0, 6, 10), 3)
        {
        }
    }
}