using System;
using System.Collections.Generic;
using System.Linq;

namespace Gauss.MatrixMethod
{
    /// <summary>
    /// Matrix
    /// </summary>
    /// <seealso cref="Gauss.MatrixMethod.IMatrix" />
    public class Matrix : IMatrix
    {
        /// <summary>
        /// The matrix
        /// </summary>
        private readonly double[,] _matrix;

        /// <summary>
        /// Gets the row count.
        /// </summary>
        /// <value>
        /// The row count.
        /// </value>
        public int RowCount => _matrix.GetLength(0);

        /// <summary>
        /// Gets the column count.
        /// </summary>
        /// <value>
        /// The column count.
        /// </value>
        public int ColumnCount => _matrix.GetLength(1);

        /// <summary>
        /// Gets the <see cref="System.Double"/> with the specified row.
        /// </summary>
        /// <value>
        /// The <see cref="System.Double"/>.
        /// </value>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <returns></returns>
        public double this[int row, int column] => _matrix[row, column];

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="inputMatrix">The input matrix.</param>
        public Matrix(double[,] inputMatrix) => _matrix = inputMatrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
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

        /// <summary>
        /// Multiplies the row.
        /// </summary>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="number">The number.</param>
        public void MultiplyRow(int rowNumber, double number)
        {
            MatrixChecker.CheckRow(rowNumber, RowCount);
            for (var i = 0; i < ColumnCount; ++i)
            {
                _matrix[rowNumber, i] *= number;
            }
        }

        /// <summary>
        /// Swaps the rows.
        /// </summary>
        /// <param name="rowFirst">The row first.</param>
        /// <param name="rowSecond">The row second.</param>
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

        /// <summary>
        /// Gets the index of the main.
        /// </summary>
        /// <param name="searchIndex">Index of the search.</param>
        /// <param name="position">The position.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Rows the multiplied.
        /// </summary>
        /// <param name="toSubtract">To subtract.</param>
        /// <param name="beSubtracted">The be subtracted.</param>
        /// <param name="multiplier">The multiplier.</param>
        public void RowMultiplied(int toSubtract, int beSubtracted, double multiplier)
        {
            MatrixChecker.CheckRow(toSubtract, RowCount);
            MatrixChecker.CheckRow(beSubtracted, RowCount);
            for (var i = 0; i < ColumnCount; i++)
            {
                _matrix[toSubtract, i] -= _matrix[beSubtracted, i] * multiplier;
            }
        }

        /// <summary>
        /// Lasts the column.
        /// </summary>
        /// <returns></returns>
        public double[] LastColumn()
        {
            var result = new double[RowCount];
            for (var i = 0; i < RowCount; ++i)
            {
                result[i] = _matrix[i, RowCount];
            }

            return result;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"Variables: {RowCount} and {ColumnCount}";

        /// <summary>
        /// Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public bool Equals(Matrix other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            for (var i = 0; i < RowCount; i++)
            {
                for (var j = 0; j < ColumnCount; j++)
                {
                    if (Math.Abs(_matrix[i, j] - other._matrix[i, j]) > 100 * double.Epsilon) return false;
                    
                }
            }
            return true;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() => unchecked(RowCount.GetHashCode() + ColumnCount.GetHashCode() + _matrix.GetHashCode());
    }
}