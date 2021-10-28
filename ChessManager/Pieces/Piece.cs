namespace ChessManager
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
      
    }
}