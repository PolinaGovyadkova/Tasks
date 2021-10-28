using System;
using ChessManager.Enum;

namespace ChessManager.Pieces
{
    /// <summary>
    /// Queen piece
    /// </summary>
    /// <seealso cref="ChessManager.Pieces.Piece" />
    public class Queen : Piece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Queen"/> class.
        /// </summary>
        /// <param name="playerColor">Color of the player.</param>
        public Queen(TypeOfPlayer playerColor) : base(playerColor)
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
            var kingMovement = "None";
            if ((fromColumnPosition - toColumnPosition == 0) || (fromRowPosition - toRowPosition == 0))
            {
                kingMovement = "Rook";
            }

            if (Math.Abs(fromColumnPosition - toColumnPosition) == Math.Abs(fromRowPosition - toRowPosition))
            {
                kingMovement = "Bishop";
            }

            if (kingMovement == "None")
            {
                return "INVALID";
            }

            int stepBeforeX;
            int stepBeforeY;

            if (kingMovement == "Rook")
            {
                if (toColumnPosition > fromColumnPosition)
                {
                    stepBeforeX = toColumnPosition - 1;
                    stepBeforeY = toRowPosition;
                }
                else
                {
                    if (fromColumnPosition > toColumnPosition)
                    {
                        stepBeforeX = toColumnPosition + 1;
                        stepBeforeY = toRowPosition;
                    }
                    else if (toRowPosition > fromRowPosition)
                    {
                        stepBeforeX = toColumnPosition;
                        stepBeforeY = toRowPosition - 1;
                    }
                    else if (fromRowPosition > toRowPosition)
                    {
                        stepBeforeX = toColumnPosition;
                        stepBeforeY = toRowPosition + 1;
                    }
                    else
                    {
                        stepBeforeX = toColumnPosition;
                        stepBeforeY = toRowPosition;
                    }
                }
            }
            else
            {
                stepBeforeX = toColumnPosition > fromColumnPosition ? toColumnPosition - 1 : toColumnPosition + 1;
                stepBeforeY = toRowPosition > fromRowPosition ? toRowPosition - 1 : toRowPosition + 1;
            }

            var pieceStepBefore = board.GetPiece(stepBeforeX, stepBeforeY);

            if (Equals(pieceStepBefore, this))
            {
                return "VALID";
            }

            return pieceStepBefore == null ? ValidMovement(board, fromColumnPosition, fromRowPosition, stepBeforeX, stepBeforeY) : "INVALID";
        }

        /// <summary>
        /// Returns the string that identify the piece on the board.
        /// </summary>
        /// <returns></returns>
        public override string IdentifyColor() => PlayerColor == TypeOfPlayer.White ? "WQ" : "BQ";

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        public override Piece Clone() => new Queen(PlayerColor);
    }
}