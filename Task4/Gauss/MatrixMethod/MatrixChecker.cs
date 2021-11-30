using System;

namespace Gauss.MatrixMethod
{
    /// <summary>
    /// MatrixChecker
    /// </summary>
    public static class MatrixChecker
    {
        /// <summary>
        /// Checks the row.
        /// </summary>
        /// <param name="rowFirst">The row first.</param>
        /// <param name="rowCount">The row count.</param>
        /// <exception cref="System.InvalidOperationException">Row number cannot be <0 or > row count</exception>
        public static void CheckRow(int rowFirst, int rowCount)
        {
            if (rowFirst < 0 || rowFirst > rowCount)
                throw new InvalidOperationException("Row number cannot be <0 or > row count");
        }

        /// <summary>
        /// Checks the column.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="columnCount">The column count.</param>
        /// <exception cref="System.InvalidOperationException">Column number cannot be < 0 or > column count</exception>
        public static void CheckColumn(int position, int columnCount)
        {
            if (position < 0 || position > columnCount)
                throw new InvalidOperationException("Column number cannot be < 0 or > column count");
        }
    }
}