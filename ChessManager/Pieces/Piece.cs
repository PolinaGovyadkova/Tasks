using ChessManager.Enum;
using ChessManager.Interfaces;

namespace ChessManager.Pieces
{
    /// <summary>
    /// Piece
    /// </summary>
    /// <seealso cref="ChessManager.Interfaces.IPiece" />
    public abstract class Piece : IPiece
    {
        /// <summary>
        /// The player piece color
        /// </summary>
        public TypeOfPlayer PlayerColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="Piece"/> class.
        /// </summary>
        /// <param name="playerColor">Color of the player.</param>
        protected Piece(TypeOfPlayer playerColor) => this.PlayerColor = playerColor;

        /// <summary>
        /// Iterates over the board to check if this piece can move from (fromColumnPosition,fromRowPosition) to (toColumnPosition,toRowPosition).
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="fromColumnPosition">From column position.</param>
        /// <param name="fromRowPosition">From row position.</param>
        /// <param name="toColumnPosition">To column position.</param>
        /// <param name="toRowPosition">To row position.</param>
        /// <returns></returns>
        public abstract string ValidMovement(Board board, int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition);

        /// <summary>
        /// Tells the piece that it was moved from (fromColumnPosition,fromRowPosition) to (toColumnPosition,toRowPosition).
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="fromColumnPosition">From column position.</param>
        /// <param name="fromRowPosition">From row position.</param>
        /// <param name="toColumnPosition">To column position.</param>
        /// <param name="toRowPosition">To row position.</param>
        public virtual void Moved(Board board, int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition)
        {
        }

        /// <summary>
        /// Returns the string that identify the piece on the board.
        /// </summary>
        /// <returns></returns>
        public abstract string IdentifyColor();

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        public abstract Piece Clone();
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is Piece piece && piece.PlayerColor == PlayerColor;
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => unchecked(PlayerColor.GetHashCode());
    }
}