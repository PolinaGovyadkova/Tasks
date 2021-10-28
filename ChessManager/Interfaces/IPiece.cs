namespace ChessManager.Interfaces
{
    /// <summary>
    /// Piece interfase
    /// </summary>
    internal interface IPiece
    {
        /// <summary>
        /// Moves the specified board.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="fromColumnPosition">From column position.</param>
        /// <param name="fromRowPosition">From row position.</param>
        /// <param name="toColumnPosition">To column position.</param>
        /// <param name="toRowPosition">To row position.</param>
        void Moved(Board board, int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition);
    }
}