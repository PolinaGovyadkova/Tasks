using System.Linq;

namespace Gauss.Vector
{
    /// <summary>
    /// Vector
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// The answers
        /// </summary>
        private readonly double[] _answers;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> class.
        /// </summary>
        /// <param name="answers">The answers.</param>
        public Vector(double[] answers) => _answers = answers;

        /// <summary>
        /// Gets the <see cref="System.Double"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="System.Double"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public double this[int index] => _answers[index];

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count => _answers.Length;

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{GetType().Name}. Count: {Count}";

        /// <summary>
        /// Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public bool Equals(Vector other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return _answers.Except(other._answers).Any() == false;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() => _answers.GetHashCode();
    }
}