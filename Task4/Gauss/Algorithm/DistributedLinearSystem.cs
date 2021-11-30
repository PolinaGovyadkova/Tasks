using Gauss.MatrixMethod;
using System;
using System.Threading.Tasks;

namespace Gauss.Algorithm
{
    /// <summary>
    /// Distributed Linear System
    /// </summary>
    /// <seealso cref="Gauss.Algorithm.LinearSystem" />
    public class DistributedLinearSystem : LinearSystem
    {
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
        /// Initializes a new instance of the <see cref="DistributedLinearSystem"/> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        public DistributedLinearSystem(Matrix matrix) : base(matrix)
        {
        }

        /// <summary>
        /// Straights the algorithm action.
        /// </summary>
        /// <param name="firstIndex">The first index.</param>
        private void StraightAlgorithmAction(int firstIndex)
        {
            Parallel.For(firstIndex + 1, Matrix.RowCount, i =>
            {
                Matrix.RowMultiplied(i, firstIndex, Matrix[i, firstIndex]);
            });
        }

        /// <summary>
        /// Reverses the algorithm action.
        /// </summary>
        /// <param name="firstIndex">The first index.</param>
        private void ReverseAlgorithmAction(int firstIndex)
        {
            Parallel.For(0, firstIndex, i =>
            {
                Matrix.RowMultiplied(i, firstIndex, Matrix[i, firstIndex]);
            });
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
        /// Directs the gaussian motion.
        /// </summary>
        private new void DirectGaussianMotion()
        {
            for (var row = 0; row < Matrix.RowCount; row++)
            {
                var mainIndex = Matrix.GetMainIndex(row, row);
                Matrix.SwapRows(row, mainIndex);
                Matrix.MultiplyRow(row, 1 / Matrix[row, row]);
                StraightAlgorithm.Invoke(row);
            }
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => "Distributed system";

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
            DistributedLinearSystem distributedLinearSystem = (DistributedLinearSystem)obj;
            return distributedLinearSystem != null && (VectorX == distributedLinearSystem.VectorX && Matrix == distributedLinearSystem.Matrix);
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