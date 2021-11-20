using System;
using Dishes.Processes.BaseProcesses;

namespace Dishes.Processes.TypeProcesses
{
    public class CutProcessDefault : CutProcess
    {
        public CutProcessDefault() : base(new TimeSpan(0, 15, 10), 20)
        {
        }
    }
}