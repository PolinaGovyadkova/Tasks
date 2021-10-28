using ChessManager.Enum;
using ChessManager.Interfaces;

namespace ChessManager.Pieces
{
    public abstract class Piece : IPiece
    {
        public TypeOfPlayer PlayerColor;

        protected Piece(TypeOfPlayer playerColor) => this.PlayerColor = playerColor;

        public abstract string ValidMovement(Board board, int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition);

        public virtual void Moved(Board board, int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition)
        {
        }

        public abstract string IdentifyColor();

        public abstract Piece Clone();
        public override bool Equals(object obj) => obj is Piece piece && piece.PlayerColor == PlayerColor;
        public override int GetHashCode() => unchecked(PlayerColor.GetHashCode());
    }
}