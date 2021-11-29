using Gauss.MatrixMethod;
using System;

namespace Gauss.Algorithm
{
    public class LinearSystem : BaseGauss
    {
        public Vector.Vector VectorX { get; set; }

        protected override Action<int> StraightAlgorithm => StraightAlgorithmAction;
        protected override Action<int> ReverseAlgorithm => ReverseAlgorithmAction;

        public LinearSystem(Matrix matrix) => Matrix = matrix;

        private void ReverseAlgorithmAction(int firstIndex)
        {
            for (var rowBefore = firstIndex - 1; rowBefore >= 0; --rowBefore)
            {
                Matrix.RowMultiplied(rowBefore, firstIndex, Matrix[rowBefore, firstIndex]);
            }
        }

        private void StraightAlgorithmAction(int firstIndex)
        {
            for (var rowAfter = firstIndex + 1; rowAfter < Matrix.RowCount; ++rowAfter)
            {
                Matrix.RowMultiplied(rowAfter, firstIndex, Matrix[rowAfter, firstIndex]);
            }
        }

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

        protected void GaussianBackwardMotion()
        {
            for (var row = Matrix.RowCount - 1; row >= 0; --row)
            {
                Matrix.MultiplyRow(row, 1 / Matrix[row, row]);
                ReverseAlgorithm?.Invoke(row);
            }
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

        public override string ToString() => "Linear system";
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() != GetType())
                return false;
            LinearSystem linearSystem = (LinearSystem)obj;
            return linearSystem != null && (VectorX == linearSystem.VectorX && Matrix == linearSystem.Matrix);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}