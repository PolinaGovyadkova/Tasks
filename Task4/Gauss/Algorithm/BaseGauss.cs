using Gauss.MatrixMethod;
using System;

namespace Gauss.Algorithm
{
    public abstract class BaseGauss
    {
        public Matrix Matrix { get; set; }
        protected abstract Action<int> StraightAlgorithm { get; }
        protected abstract Action<int> ReverseAlgorithm { get; }

        public abstract string GaussSolve();
        public override string ToString() => $@"Matrix {Matrix}";
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() != GetType())
                return false;
            BaseGauss baseGauss = (BaseGauss)obj;
            return baseGauss != null && (Matrix == baseGauss.Matrix && ReverseAlgorithm == baseGauss.ReverseAlgorithm && StraightAlgorithm == baseGauss.StraightAlgorithm);
        }
        public override int GetHashCode() => unchecked(Matrix.GetHashCode() + StraightAlgorithm.GetHashCode() + ReverseAlgorithm.GetHashCode() + GaussSolve().GetHashCode());
    }
}