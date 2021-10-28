using System;
using ChessManager.Enum;

namespace ChessManager.Pieces
{
    public class Pawn : Piece
    {
        private readonly int _direction;
        private bool _neverMoved;
        private bool _liableOfCaptureByEnPassant;

        public Pawn(TypeOfPlayer playerColor) : base(playerColor)
        {
            if (playerColor == TypeOfPlayer.Black) { _direction = -1; }
            else { _direction = 1; };

            _neverMoved = true;
            _liableOfCaptureByEnPassant = false;
        }

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

        public override string IdentifyColor() => PlayerColor == TypeOfPlayer.White ? "WP" : "BP";

        public override void Moved(Board board, int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition)
        {
            _neverMoved = false;

            if (Math.Abs(fromRowPosition - toRowPosition) == 2)
            {
                _liableOfCaptureByEnPassant = true;
            }
        }

        public override Piece Clone()
        {
            var newPawn = new Pawn(PlayerColor);
            newPawn.SetAttributes(_neverMoved, _liableOfCaptureByEnPassant);
            return newPawn;
        }

        protected void SetAttributes(bool neverMoved, bool liableOfCaptureByEnPassant)
        {
            this._neverMoved = neverMoved;
            this._liableOfCaptureByEnPassant = liableOfCaptureByEnPassant;
        }

        public void ClearEnPassantLiability() => _liableOfCaptureByEnPassant = false;
    }
}