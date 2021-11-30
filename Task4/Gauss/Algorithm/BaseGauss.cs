using Gauss.MatrixMethod;
using System;

namespace Gauss.Algorithm
{
    /// <summary>
    /// BaseGauss
    /// </summary>
    public abstract class BaseGauss
    {
        /// <summary>
        /// Gets or sets the matrix.
        /// </summary>
        /// <value>
        /// The matrix.
        /// </value>
        public Matrix Matrix { get; set; }

        /// <summary>
        /// Gets the straight algorithm.
        /// </summary>
        /// <value>
        /// The straight algorithm.
        /// </value>
        protected abstract Action<int> StraightAlgorithm { get; }

        /// <summary>
        /// Gets the reverse algorithm.
        /// </summary>
        /// <value>
        /// The reverse algorithm.
        /// </value>
        protected abstract Action<int> ReverseAlgorithm { get; }

        /// <summary>
        /// Gausses the solve.
        /// </summary>
        /// <returns></returns>
        public abstract string GaussSolve();

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $@"Matrix {Matrix}";

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() != GetType())
                return false;
            BaseGauss baseGauss = (BaseGauss)obj;
            return baseGauss != null && (Matrix == baseGauss.Matrix && ReverseAlgorithm == baseGauss.ReverseAlgorithm && StraightAlgorithm == baseGauss.StraightAlgorithm);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() => unchecked(Matrix.GetHashCode() + StraightAlgorithm.GetHashCode() + ReverseAlgorithm.GetHashCode() + GaussSolve().GetHashCode());
    }
}