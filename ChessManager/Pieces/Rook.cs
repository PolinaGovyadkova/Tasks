using ChessManager.Enum;

namespace ChessManager.Pieces
{
    /// <summary>
    /// Rook piece
    /// </summary>
    /// <seealso cref="ChessManager.Pieces.Piece" />
    public class Rook : Piece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rook"/> class.
        /// </summary>
        /// <param name="playerColor">Color of the player.</param>
        public Rook(TypeOfPlayer playerColor) : base(playerColor)
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

            if (Equals(pieceStepBefore, this)) { return "VALID"; }
            if (pieceStepBefore == null) { return ValidMovement(board, fromColumnPosition, fromRowPosition, stepBeforeX, stepBeforeY); }
            return "INVALID";
        }

        /// <summary>
        /// Returns the string that identify the piece on the board.
        /// </summary>
        /// <returns></returns>
        public override string IdentifyColor() => PlayerColor == TypeOfPlayer.White ? "WR" : "BR";

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        public override Piece Clone() => new Rook(PlayerColor);
    }
}