using System;
using ChessManager.Enum;

namespace ChessManager.Pieces
{
    public class Knight : Piece
    {
        public Knight(TypeOfPlayer playerColor) : base(playerColor)
        {
        }

        public override string ValidMovement(Board board, int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition) =>
            (Math.Abs(fromColumnPosition - toColumnPosition) == 1 && Math.Abs(fromRowPosition - toRowPosition) == 2)
            || (Math.Abs(fromColumnPosition - toColumnPosition) == 2 && Math.Abs(fromRowPosition - toRowPosition) == 1)
                ? "VALID"
                : "INVALID";

        public override string IdentifyColor() => PlayerColor == TypeOfPlayer.White ? "Wk" : "Bk";

        public override Piece Clone() => new Knight(PlayerColor);
    }
}