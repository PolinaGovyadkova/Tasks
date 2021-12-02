using System;

namespace Gauss
{
    /// <summary>
    /// Gauss Exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class GaussException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GaussException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        public GaussException(string message)
            : base("No solution can be found: \r\n" + message)
        {
        }
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() != GetType())
                return false;
            GaussException baseGauss = (GaussException)obj;
            return baseGauss != null;
        }
        public override int GetHashCode() => unchecked(base.GetHashCode());
    }
}