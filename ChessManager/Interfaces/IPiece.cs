namespace ChessManager
{
    internal interface IPiece
    {
        void Moved(Board board, int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition);
    }
}