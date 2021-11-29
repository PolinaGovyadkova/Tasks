using Gauss.MatrixMethod;
using System;
using System.Threading.Tasks;

namespace Gauss.Algorithm
{
    public class DistributedLinearSystem : LinearSystem
    {
        protected override Action<int> StraightAlgorithm => StraightAlgorithmAction;
        protected override Action<int> ReverseAlgorithm => ReverseAlgorithmAction;

        public DistributedLinearSystem(Matrix matrix) : base(matrix)
        {
        }

        private void StraightAlgorithmAction(int firstIndex)
        {
            Parallel.For(firstIndex + 1, Matrix.RowCount, i =>
            {
                Matrix.RowMultiplied(i, firstIndex, Matrix[i, firstIndex]);
            });
        }

        private void ReverseAlgorithmAction(int firstIndex)
        {
            Parallel.For(0, firstIndex, i =>
            {
                Matrix.RowMultiplied(i, firstIndex, Matrix[i, firstIndex]);
            });
        }

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

        public override string ToString() => "Distributed system";
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() != GetType())
                return false;
            DistributedLinearSystem distributedLinearSystem = (DistributedLinearSystem)obj;
            return distributedLinearSystem != null && (VectorX == distributedLinearSystem.VectorX && Matrix == distributedLinearSystem.Matrix);
        }

        public override int GetHashCode() => unchecked(Matrix.GetHashCode() + StraightAlgorithm.GetHashCode() + ReverseAlgorithm.GetHashCode() + GaussSolve().GetHashCode());
    }
}