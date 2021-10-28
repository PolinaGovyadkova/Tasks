using System;
using ChessManager.Enum;

namespace ChessManager.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(TypeOfPlayer playerColor) : base(playerColor)
        {
        }

        public override string ValidMovement(Board board, int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition)
        {
            if (Math.Abs(fromColumnPosition - toColumnPosition) != Math.Abs(fromRowPosition - toRowPosition))
            {
                return "INVALID";
            }

            var stepBeforeX = toColumnPosition > fromColumnPosition ? toColumnPosition - 1 : toColumnPosition + 1;
            var stepBeforeY = toRowPosition > fromRowPosition ? toRowPosition - 1 : toRowPosition + 1;

            var pieceStepBefore = board.GetPiece(stepBeforeX, stepBeforeY);

            return pieceStepBefore == this ? "VALID" :
                pieceStepBefore == null ? ValidMovement(board, fromColumnPosition, fromRowPosition, stepBeforeX, stepBeforeY) : "INVALID";
        }

        public override string IdentifyColor() => PlayerColor == TypeOfPlayer.White ? "WB" : "BB";

        public override Piece Clone() => new Bishop(PlayerColor);
    }
}