using System;
using ChessManager.Enum;

namespace ChessManager.Pieces
{
    /// <summary>
    /// Bishop piece
    /// </summary>
    /// <seealso cref="ChessManager.Pieces.Piece" />
    public class Bishop : Piece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bishop"/> class.
        /// </summary>
        /// <param name="playerColor">Color of the player.</param>
        public Bishop(TypeOfPlayer playerColor) : base(playerColor)
        {
        }

        /// <summary>
        /// Iterates over the board to check if this piece can move from (fromColumnPosition,fromRowPosition) to (toColumnPosition,toRowPosition).
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="fromColumnPosition">From column position.</param>
        /// <param name="fromRowPosition">From row position.</param>
        /// <param name="toColumnPosition">To column position.</param>
        /// <param name="toRowPosition">To row position.</param>
        /// <returns></returns>
        public override string ValidMovement(Board board, int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition)
        {
            if (Math.Abs(fromColumnPosition - toColumnPosition) != Math.Abs(fromRowPosition - toRowPosition))
            {
                return "INVALID";
            }

            var stepBeforeX = toColumnPosition > fromColumnPosition ? toColumnPosition - 1 : toColumnPosition + 1;
            var stepBeforeY = toRowPosition > fromRowPosition ? toRowPosition - 1 : toRowPosition + 1;

            var pieceStepBefore = board.GetPiece(stepBeforeX, stepBeforeY);

            return Equals(pieceStepBefore, this) ? "VALID" :
                pieceStepBefore == null ? ValidMovement(board, fromColumnPosition, fromRowPosition, stepBeforeX, stepBeforeY) : "INVALID";
        }

        /// <summary>
        /// Returns the string that identify the piece on the board.
        /// </summary>
        /// <returns></returns>
        public override string IdentifyColor() => PlayerColor == TypeOfPlayer.White ? "WB" : "BB";

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        public override Piece Clone() => new Bishop(PlayerColor);
    }
}