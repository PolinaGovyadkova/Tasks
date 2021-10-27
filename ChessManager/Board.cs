using System;

namespace ChessManager
{
    public class Board
    {
        private readonly Piece[,] _boardArray;

        public Board()
        {
            _boardArray = new Piece[8, 8];
            for (var i = 0; i < 8; i++)
            {
                _boardArray[i, 1] = new Pawn(TypeOfPlayer.White);
                _boardArray[i, 6] = new Pawn(TypeOfPlayer.Black);
            }
            _boardArray[0, 0] = new Rook(TypeOfPlayer.White);
            _boardArray[1, 0] = new Knight(TypeOfPlayer.White);
            _boardArray[2, 0] = new Bishop(TypeOfPlayer.White);
            _boardArray[3, 0] = new Queen(TypeOfPlayer.White);
            _boardArray[4, 0] = new King(TypeOfPlayer.White);
            _boardArray[5, 0] = new Bishop(TypeOfPlayer.White);
            _boardArray[6, 0] = new Knight(TypeOfPlayer.White);
            _boardArray[7, 0] = new Rook(TypeOfPlayer.White);
            _boardArray[0, 7] = new Rook(TypeOfPlayer.Black);
            _boardArray[1, 7] = new Knight(TypeOfPlayer.Black);
            _boardArray[2, 7] = new Bishop(TypeOfPlayer.Black);
            _boardArray[3, 7] = new Queen(TypeOfPlayer.Black);
            _boardArray[4, 7] = new King(TypeOfPlayer.Black);
            _boardArray[5, 7] = new Bishop(TypeOfPlayer.Black);
            _boardArray[6, 7] = new Knight(TypeOfPlayer.Black);
            _boardArray[7, 7] = new Rook(TypeOfPlayer.Black);
        }

        public Piece GetPiece(int x, int y) => _boardArray[x, y];

        public Board(Piece[,] boardArrayInput)
        {
            _boardArray = new Piece[8, 8];

            for (var x = 0; x < 8; x++)
            {
                for (var y = 0; y < 8; y++)
                {
                    if (boardArrayInput[x, y] != null)
                    {
                        _boardArray[x, y] = boardArrayInput[x, y].Clone();
                    }
                }
            }
        }

        public string Move(int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition, TypeOfPlayer blackWhiteTurn)
        {
            var checkResult = CheckMove(fromColumnPosition, fromRowPosition, toColumnPosition, toRowPosition, blackWhiteTurn, true);

            if (CheckValid(checkResult))
            {
                ApplyMove(fromColumnPosition, fromRowPosition, toColumnPosition, toRowPosition, checkResult);
                checkResult = null;
            }
            return checkResult;
        }

        private string CheckMove(int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition, TypeOfPlayer blackWhiteTurn, bool verifyCheck)
        {
            if (!CheckBounds(fromColumnPosition, fromRowPosition, toColumnPosition, toRowPosition)) { return "Values out of bounds!"; }

            if (fromColumnPosition == toColumnPosition && fromRowPosition == toRowPosition) { return "You can't move to the same position!"; }

            var movingPiece = _boardArray[fromColumnPosition, fromRowPosition];
            if (movingPiece == null) { return "There is no piece at (" + fromColumnPosition + "," + fromRowPosition + ")."; }

            if (movingPiece.PlayerColor != blackWhiteTurn) { return "The piece at (" + fromColumnPosition + "," + fromRowPosition + ") is not yours!"; }

            var targetPiece = _boardArray[toColumnPosition, toRowPosition];
            if ((targetPiece != null) && targetPiece.PlayerColor == blackWhiteTurn) { return "You can't kill your Pieces!"; }

            var validationResult = movingPiece.ValidMovement(this, fromColumnPosition, fromRowPosition, toColumnPosition, toRowPosition);
            if (validationResult == "INVALID") { return "The piece can't move to (" + toColumnPosition + "," + toRowPosition + ")"; }

            if (verifyCheck)
            {
                var testingBoard = new Board(_boardArray);
                testingBoard.ApplyMove(fromColumnPosition, fromRowPosition, toColumnPosition, toRowPosition, validationResult);
                if (testingBoard.IsInCheck(movingPiece.PlayerColor)) { return "You can't let the king in danger!"; }
            }

            return validationResult;
        }

        protected void ApplyMove(int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition, string checkResult)
        {
            _boardArray[toColumnPosition, toRowPosition] = _boardArray[fromColumnPosition, fromRowPosition];
            _boardArray[fromColumnPosition, fromRowPosition] = null;

            if (checkResult == "EN_PASSANT")
            {
                _boardArray[toColumnPosition, fromRowPosition] = null;
            }

            _boardArray[toColumnPosition, toRowPosition].Moved(this, fromColumnPosition, fromRowPosition, toColumnPosition, toRowPosition);
        }

        private static bool CheckValid(string checkResult) => checkResult == "VALID" || checkResult == "EN_PASSANT";

        private static bool CheckBounds(int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition)
        {
            if (fromColumnPosition < 0 || fromColumnPosition > 7) { return false; };
            if (fromRowPosition < 0 || fromRowPosition > 7) { return false; };
            if (toColumnPosition < 0 || toColumnPosition > 7) { return false; };
            if (toRowPosition < 0 || toRowPosition > 7) { return false; };
            return true;
        }

        public bool IsInCheck(TypeOfPlayer playerColor)
        {
            var kingX = -1;
            var kingY = -1;

            for (var x = 0; x < 8; x++)
            {
                for (var y = 0; y < 8; y++)
                {
                    if (_boardArray[x, y] != null && _boardArray[x, y].PlayerColor == playerColor && _boardArray[x, y] is King)
                    {
                        kingX = x;
                        kingY = y;
                        break;
                    }
                }
                if (kingX != -1) { break; }
            }

            for (var x = 0; x < 8; x++)
            {
                for (var y = 0; y < 8; y++)
                {
                    if (CheckValid(CheckMove(x, y, kingX, kingY, playerColor, false))) { return true; };
                }
            }

            return false;
        }

        public bool NoPossibleMove(TypeOfPlayer playerColor)
        {
            for (var fromColumnPosition = 0; fromColumnPosition < 8; fromColumnPosition++)
            {
                for (var fromRowPosition = 0; fromRowPosition < 8; fromRowPosition++)
                {
                    for (var toColumnPosition = 0; toColumnPosition < 8; toColumnPosition++)
                    {
                        for (var toRowPosition = 0; toRowPosition < 8; toRowPosition++)
                        {
                            if (CheckValid(CheckMove(fromColumnPosition, fromRowPosition, toColumnPosition, toRowPosition, playerColor, true))) { return false; };
                        }
                    }
                }
            }
            return true;
        }

        public void PrintBoard()
        {
            Console.WriteLine("Y\\X 0  1  2  3  4  5  6  7");
            for (var x = 0; x < 8; x++)
            {
                var line = x + " |";
                for (var y = 0; y < 8; y++)
                {
                    line += _boardArray[y, x] == null ? "  |" : _boardArray[y, x].IdentifyColor() + "|";
                }
                Console.WriteLine(line);
            }
        }

        public void ClearEnPassingAllows(TypeOfPlayer playerColor)
        {
            for (var x = 0; x < 8; x++)
            {
                for (var y = 0; y < 8; y++)
                {
                    if (
                        _boardArray[x, y] != null
                        && _boardArray[x, y].PlayerColor == playerColor
                        && (_boardArray[x, y] is Pawn)
                        )
                    {
                        ((Pawn)_boardArray[x, y]).ClearEnPassantLiability();
                    }
                }
            }
        }

        public bool CheckForPromotionAvaliable(TypeOfPlayer playerColor)
        {
            int y;
            y = playerColor == TypeOfPlayer.White ? 0 : 7; ;
            for (var x = 0; x < 8; x++)
            {
                if (
                        _boardArray[x, y] != null
                        && _boardArray[x, y].PlayerColor == playerColor
                        && (_boardArray[x, y] is Pawn)
                    )
                {
                    return true;
                }
            }
            return false;
        }

        public bool ApplyPromotion(int selectedPiece, TypeOfPlayer playerColor)
        {
            var y = playerColor == TypeOfPlayer.White ? 0 : 7;
            for (var x = 0; x < 8; x++)
            {
                if (_boardArray[x, y] != null && _boardArray[x, y].PlayerColor == playerColor && (_boardArray[x, y] is Pawn))
                {
                    if (selectedPiece == 1) { _boardArray[x, y] = new Queen(playerColor); }
                    else if (selectedPiece == 2) { _boardArray[x, y] = new Rook(playerColor); }
                    else if (selectedPiece == 3) { _boardArray[x, y] = new Bishop(playerColor); }
                    else if (selectedPiece == 4) { _boardArray[x, y] = new Knight(playerColor); }
                    else { return false; }
                }
            }
            return true;
        }
    }
}