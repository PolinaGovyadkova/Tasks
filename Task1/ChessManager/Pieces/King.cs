using System;

namespace ChessManager
{
    public class King : Piece
    {
        public King(TypeOfPlayer playerColor) : base(playerColor)
        {
        }

        public override string ValidMovement(Board board, int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition) => Math.Abs(fromColumnPosition - toColumnPosition) <= 1 && Math.Abs(fromRowPosition - toRowPosition) <= 1 ? "VALID" : "INVALID";

        public override string IdentifyColor() => PlayerColor == TypeOfPlayer.White ? "WK" : "BK";

        public override Piece Clone() => new King(PlayerColor);
    }
}