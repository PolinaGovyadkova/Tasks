using System;
using ChessManager.Enum;

namespace ChessManager.Pieces
{
    public class Queen : Piece
    {
        public Queen(TypeOfPlayer playerColor) : base(playerColor)
        {
        }

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

            if (pieceStepBefore == this)
            {
                return "VALID";
            }

            return pieceStepBefore == null ? ValidMovement(board, fromColumnPosition, fromRowPosition, stepBeforeX, stepBeforeY) : "INVALID";
        }

        public override string IdentifyColor() => PlayerColor == TypeOfPlayer.White ? "WQ" : "BQ";

        public override Piece Clone() => new Queen(PlayerColor);
    }
}