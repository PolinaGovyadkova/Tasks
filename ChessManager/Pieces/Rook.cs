using ChessManager.Enum;

namespace ChessManager.Pieces
{
    public class Rook : Piece
    {
        public Rook(TypeOfPlayer playerColor) : base(playerColor)
        {
        }

        public override string ValidMovement(Board board, int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition)
        {
            if ((fromColumnPosition == toColumnPosition) && (fromRowPosition == toRowPosition)) { return "VALID"; }
            if ((fromColumnPosition - toColumnPosition != 0) && (fromRowPosition - toRowPosition != 0)) { return "INVALID"; }

            int stepBeforeX;
            int stepBeforeY;
            if (toColumnPosition > fromColumnPosition) { stepBeforeX = toColumnPosition - 1; stepBeforeY = toRowPosition; }
            else if (fromColumnPosition > toColumnPosition) { stepBeforeX = toColumnPosition + 1; stepBeforeY = toRowPosition; }
            else if (toRowPosition > fromRowPosition) { stepBeforeX = toColumnPosition; stepBeforeY = toRowPosition - 1; }
            else if (fromRowPosition > toRowPosition) { stepBeforeX = toColumnPosition; stepBeforeY = toRowPosition + 1; }
            else { stepBeforeX = toColumnPosition; stepBeforeY = toRowPosition; }

            var pieceStepBefore = board.GetPiece(stepBeforeX, stepBeforeY);

            if (pieceStepBefore == this) { return "VALID"; }
            if (pieceStepBefore == null) { return ValidMovement(board, fromColumnPosition, fromRowPosition, stepBeforeX, stepBeforeY); }
            return "INVALID";
        }

        public override string IdentifyColor() => PlayerColor == TypeOfPlayer.White ? "WR" : "BR";

        public override Piece Clone() => new Rook(PlayerColor);
    }
}