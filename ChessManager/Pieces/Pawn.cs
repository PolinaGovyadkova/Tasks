using System;
using ChessManager.Enum;

namespace ChessManager.Pieces
{
    /// <summary>
    /// Pawn piece
    /// </summary>
    /// <seealso cref="ChessManager.Pieces.Piece" />
    public class Pawn : Piece
    {
        /// <summary>
        /// The direction
        /// </summary>
        private readonly int _direction;
        /// <summary>
        /// The never moved
        /// </summary>
        private bool _neverMoved;
        /// <summary>
        /// The liable of capture by en passant
        /// </summary>
        private bool _liableOfCaptureByEnPassant;

        /// <summary>
        /// Initializes a new instance of the <see cref="Pawn"/> class.
        /// </summary>
        /// <param name="playerColor">Color of the player.</param>
        public Pawn(TypeOfPlayer playerColor) : base(playerColor)
        {
            if (playerColor == TypeOfPlayer.Black) { _direction = -1; }
            else { _direction = 1; }

            _neverMoved = true;
            _liableOfCaptureByEnPassant = false;
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
            if (fromColumnPosition == toColumnPosition)
            {
                if (toRowPosition == fromRowPosition + _direction)
                {
                    return board.GetPiece(toColumnPosition, toRowPosition) == null ? "VALID" : "INVALID";
                }
                if ((toRowPosition == fromRowPosition + 2 * _direction) && _neverMoved)
                {
                    return (board.GetPiece(toColumnPosition, toRowPosition) == null) && (board.GetPiece(toColumnPosition, toRowPosition - _direction) == null)
                        ? "VALID"
                        : "INVALID";
                }
            }
            else if ((Math.Abs(fromColumnPosition - toColumnPosition) == 1) && (toRowPosition == fromRowPosition + _direction))
            {
                if (board.GetPiece(toColumnPosition, toRowPosition) != null) { return "VALID"; }
                else if (board.GetPiece(toColumnPosition, fromRowPosition) is Pawn && board.GetPiece(toColumnPosition, fromRowPosition).PlayerColor != this.PlayerColor && ((Pawn)board.GetPiece(toColumnPosition, fromRowPosition))._liableOfCaptureByEnPassant)
                {
                    return "EN_PASSANT";
                }
            }

            return "INVALID";
        }

        /// <summary>
        /// Returns the string that identify the piece on the board.
        /// </summary>
        /// <returns></returns>
        public override string IdentifyColor() => PlayerColor == TypeOfPlayer.White ? "WP" : "BP";

        /// <summary>
        /// Moveds the specified board.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="fromColumnPosition">From column position.</param>
        /// <param name="fromRowPosition">From row position.</param>
        /// <param name="toColumnPosition">To column position.</param>
        /// <param name="toRowPosition">To row position.</param>
        public override void Moved(Board board, int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition)
        {
            _neverMoved = false;

            if (Math.Abs(fromRowPosition - toRowPosition) == 2)
            {
                _liableOfCaptureByEnPassant = true;
            }
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        public override Piece Clone()
        {
            var newPawn = new Pawn(PlayerColor);
            newPawn.SetAttributes(_neverMoved, _liableOfCaptureByEnPassant);
            return newPawn;
        }

        /// <summary>
        /// Sets the attributes.
        /// </summary>
        /// <param name="neverMoved">if set to <c>true</c> [never moved].</param>
        /// <param name="liableOfCaptureByEnPassant">if set to <c>true</c> [liable of capture by en passant].</param>
        protected void SetAttributes(bool neverMoved, bool liableOfCaptureByEnPassant)
        {
            this._neverMoved = neverMoved;
            this._liableOfCaptureByEnPassant = liableOfCaptureByEnPassant;
        }

        /// <summary>
        /// Clears the en passant liability.
        /// </summary>
        public void ClearEnPassantLiability() => _liableOfCaptureByEnPassant = false;
    }
}