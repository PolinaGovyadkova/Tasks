using Gauss.MatrixMethod;
using System;

namespace Gauss.Algorithm
{
    /// <summary>
    /// Linear System
    /// </summary>
    /// <seealso cref="Gauss.Algorithm.BaseGauss" />
    public class LinearSystem : BaseGauss
    {
        /// <summary>
        /// Gets or sets the vector x.
        /// </summary>
        /// <value>
        /// The vector x.
        /// </value>
        public Vector.Vector VectorX { get; set; }

        /// <summary>
        /// Gets the straight algorithm.
        /// </summary>
        /// <value>
        /// The straight algorithm.
        /// </value>
        protected override Action<int> StraightAlgorithm => StraightAlgorithmAction;

        /// <summary>
        /// Gets the reverse algorithm.
        /// </summary>
        /// <value>
        /// The reverse algorithm.
        /// </value>
        protected override Action<int> ReverseAlgorithm => ReverseAlgorithmAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinearSystem"/> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        public LinearSystem(Matrix matrix) => Matrix = matrix;

        /// <summary>
        /// Reverses the algorithm action.
        /// </summary>
        /// <param name="firstIndex">The first index.</param>
        private void ReverseAlgorithmAction(int firstIndex)
        {
            for (var rowBefore = firstIndex - 1; rowBefore >= 0; --rowBefore)
            {
                Matrix.RowMultiplied(rowBefore, firstIndex, Matrix[rowBefore, firstIndex]);
            }
        }

        /// <summary>
        /// Straights the algorithm action.
        /// </summary>
        /// <param name="firstIndex">The first index.</param>
        private void StraightAlgorithmAction(int firstIndex)
        {
            for (var rowAfter = firstIndex + 1; rowAfter < Matrix.RowCount; ++rowAfter)
            {
                Matrix.RowMultiplied(rowAfter, firstIndex, Matrix[rowAfter, firstIndex]);
            }
        }

        /// <summary>
        /// Directs the gaussian motion.
        /// </summary>
        protected void DirectGaussianMotion()
        {
            for (var row = 0; row < Matrix.RowCount; row++)
            {
                var mainIndex = Matrix.GetMainIndex(row, row);
                Matrix.SwapRows(row, mainIndex);
                Matrix.MultiplyRow(row, 1 / Matrix[row, row]);
                StraightAlgorithm?.Invoke(row);
            }
        }

        /// <summary>
        /// Gaussians the backward motion.
        /// </summary>
        protected void GaussianBackwardMotion()
        {
            for (var row = Matrix.RowCount - 1; row >= 0; --row)
            {
                Matrix.MultiplyRow(row, 1 / Matrix[row, row]);
                ReverseAlgorithm?.Invoke(row);
            }
        }

        /// <summary>
        /// Gausses the solve.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Gauss.GaussException"></exception>
        public override string GaussSolve()
        {
            try
            {
                DirectGaussianMotion();
                GaussianBackwardMotion();
                VectorX = new Vector.Vector(Matrix.LastColumn());
                var result = "Vector X:\n";
                for (var i = 0; i < VectorX.Count; i++)
                {
                    result += $"{Math.Round(VectorX[i], 5)}\n";
                }
                return result;
            }
            catch (Exception e)
            {
                throw new GaussException(e.Message);
            }
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => "Linear system";

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
            LinearSystem linearSystem = (LinearSystem)obj;
            return linearSystem != null && (VectorX == linearSystem.VectorX && Matrix == linearSystem.Matrix);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() => VectorX.GetHashCode() + GaussSolve().GetHashCode() + ReverseAlgorithm.GetHashCode() + StraightAlgorithm.GetHashCode() + GaussSolve().GetHashCode();
    }
}