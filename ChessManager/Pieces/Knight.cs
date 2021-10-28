using System;
using ChessManager.Enum;

namespace ChessManager.Pieces
{
    /// <summary>
    /// Knight piece
    /// </summary>
    /// <seealso cref="ChessManager.Pieces.Piece" />
    public class Knight : Piece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Knight" /> class.
        /// </summary>
        /// <param name="playerColor">Color of the player.</param>
        public Knight(TypeOfPlayer playerColor) : base(playerColor)
        {
        }

        /// <summary>
        ///  Iterates over the board to check if this piece can move from (fromColumnPosition,fromRowPosition) to (toColumnPosition,toRowPosition).
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="fromColumnPosition">From column position.</param>
        /// <param name="fromRowPosition">From row position.</param>
        /// <param name="toColumnPosition">To column position.</param>
        /// <param name="toRowPosition">To row position.</param>
        /// <returns></returns>
        public override string ValidMovement(Board board, int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition) =>
            (Math.Abs(fromColumnPosition - toColumnPosition) == 1 && Math.Abs(fromRowPosition - toRowPosition) == 2)
            || (Math.Abs(fromColumnPosition - toColumnPosition) == 2 && Math.Abs(fromRowPosition - toRowPosition) == 1)
                ? "VALID"
                : "INVALID";

        /// <summary>
        /// Returns the string that identify the piece on the board.
        /// </summary>
        /// <returns></returns>
        public override string IdentifyColor() => PlayerColor == TypeOfPlayer.White ? "Wk" : "Bk";

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        public override Piece Clone() => new Knight(PlayerColor);
    }
}