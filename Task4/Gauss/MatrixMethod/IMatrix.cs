namespace Gauss.MatrixMethod
{
    /// <summary>
    /// IMatrix
    /// </summary>
    public interface IMatrix
    {
        /// <summary>
        /// Gets the row count.
        /// </summary>
        /// <value>
        /// The row count.
        /// </value>
        int RowCount { get; }

        /// <summary>
        /// Gets the column count.
        /// </summary>
        /// <value>
        /// The column count.
        /// </value>
        int ColumnCount { get; }
    }
}