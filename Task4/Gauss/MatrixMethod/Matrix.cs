using System;
using System.Collections.Generic;
using System.Linq;

namespace Gauss.MatrixMethod
{
    public class Matrix : IMatrix
    {
        private readonly double[,] _matrix;

        public int RowCount => _matrix.GetLength(0);
        public int ColumnCount => _matrix.GetLength(1);
        public double this[int row, int column] => _matrix[row, column];

        public Matrix(double[,] inputMatrix) => _matrix = inputMatrix;

        public Matrix(IEnumerable<IEnumerable<double>> matrix)
        {
            var enumerable = matrix.ToList();
            _matrix = new double[enumerable.Count(), enumerable.First().Count()];
            for (var i = 0; i < enumerable.Count(); i++)
            {
                for (var j = 0; j < enumerable.First().Count(); j++)
                {
                    _matrix[i, j] = enumerable.ElementAt(i).ElementAt(j);
                }
            }
        }

        public void MultiplyRow(int rowNumber, double number)
        {
            MatrixChecker.CheckRow(rowNumber, RowCount);
            for (var i = 0; i < ColumnCount; ++i)
            {
                _matrix[rowNumber, i] *= number;
            }
        }

        public void SwapRows(int rowFirst, int rowSecond)
        {
            MatrixChecker.CheckRow(rowFirst, RowCount);
            MatrixChecker.CheckRow(rowSecond, RowCount);
            if (rowFirst == rowSecond) return;
            var buffer = new double[ColumnCount];
            for (var i = 0; i < ColumnCount; i++)
            {
                buffer[i] = _matrix[rowFirst, i];
            }

            for (var i = 0; i < ColumnCount; i++)
            {
                _matrix[rowFirst, i] = _matrix[rowSecond, i];
                _matrix[rowSecond, i] = buffer[i];
            }
        }

        public int GetMainIndex(int searchIndex, int position)
        {
            MatrixChecker.CheckColumn(position, ColumnCount);
            MatrixChecker.CheckRow(searchIndex, RowCount);
            var resultIndex = searchIndex;
            var tempMaxElement = _matrix[searchIndex, position];
            for (var i = searchIndex + 1; i < RowCount; i++)
            {
                if (!(_matrix[i, position] > tempMaxElement))
                {
                    continue;
                }

                tempMaxElement = _matrix[i, position];
                resultIndex = i;
            }

            return resultIndex;
        }

        public void RowMultiplied(int toSubtract, int beSubtracted, double multiplier)
        {
            MatrixChecker.CheckRow(toSubtract, RowCount);
            MatrixChecker.CheckRow(beSubtracted, RowCount);
            for (var i = 0; i < ColumnCount; i++)
            {
                _matrix[toSubtract, i] -= _matrix[beSubtracted, i] * multiplier;
            }
        }

        public double[] LastColumn()
        {
            var result = new double[RowCount];
            for (var i = 0; i < RowCount; ++i)
            {
                result[i] = _matrix[i, RowCount];
            }

            return result;
        }

        public override string ToString() => $"Variables: {RowCount} and {ColumnCount}";
        public bool Equals(Matrix other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            for (var i = 0; i < RowCount; i++)
            {
                for (var j = 0; j < ColumnCount; j++)
                {
                    if (Math.Abs(_matrix[i, j] - other._matrix[i, j]) > 100 * double.Epsilon)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public override int GetHashCode() => _matrix.GetHashCode();
    }
}
