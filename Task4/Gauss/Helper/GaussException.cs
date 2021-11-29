using System;

namespace Gauss
{
    public class GaussException : Exception
    {
        public GaussException(string message)
            : base("No solution can be found: \r\n" + message)
        {
        }
    }
}