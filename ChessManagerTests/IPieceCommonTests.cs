using ChessManager;

namespace ChessManagerTests
{
    public interface IPieceCommonTests
    {
        void MovedTaste(Board board, int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition);
    }
}