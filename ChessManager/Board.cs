using System;
using ChessManager.Enum;
using ChessManager.Pieces;

namespace ChessManager
{
    /// <summary>
    /// Board
    /// </summary>
    public class Board
    {
        /// <summary>
        /// The board array
        /// </summary>
        private readonly Piece[,] _boardArray;

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class.
        /// </summary>
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

        /// <summary>
        /// Getter method of the board elements.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public Piece GetPiece(int x, int y) => _boardArray[x, y];

        /// <summary>
        /// Board constructor for simulating scenarios. Creates a copy of a board.
        /// </summary>
        /// <param name="boardArrayInput">The board array input.</param>
        public Board(Piece[,] boardArrayInput)
        {
            // Creating the board;
            _boardArray = new Piece[8, 8];
            // Setting up the board;
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

        /// <summary>
        /// Check the move from (x1,y1) to (x2,y2) and execute if possible.
        /// </summary>
        /// <param name="fromColumnPosition">From column position.</param>
        /// <param name="fromRowPosition">From row position.</param>
        /// <param name="toColumnPosition">To column position.</param>
        /// <param name="toRowPosition">To row position.</param>
        /// <param name="blackWhiteTurn">The black white turn.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Check if the move from (x1,y1) to (x2,y2) is possible.
        /// </summary>
        /// <param name="fromColumnPosition">From column position.</param>
        /// <param name="fromRowPosition">From row position.</param>
        /// <param name="toColumnPosition">To column position.</param>
        /// <param name="toRowPosition">To row position.</param>
        /// <param name="blackWhiteTurn">The black white turn.</param>
        /// <param name="verifyCheck">if set to <c>true</c> [verify check].</param>
        /// <returns></returns>
        public string CheckMove(int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition, TypeOfPlayer blackWhiteTurn, bool verifyCheck)
        {

            if (!CheckBounds(fromColumnPosition, fromRowPosition, toColumnPosition, toRowPosition)) { return "Values out of bounds!"; }

            if (fromColumnPosition == toColumnPosition && fromRowPosition == toRowPosition) { return "You can't move to the same position!"; }

            var movingPiece = _boardArray[fromColumnPosition, fromRowPosition];
            if (movingPiece == null) { return "There is no piece."; }

            if (movingPiece.PlayerColor != blackWhiteTurn) { return "The piece is not yours!"; }

            var targetPiece = _boardArray[toColumnPosition, toRowPosition];
            if ((targetPiece != null) && targetPiece.PlayerColor == blackWhiteTurn) { return "You can't kill your Pieces!"; }

            var validationResult = movingPiece.ValidMovement(this, fromColumnPosition, fromRowPosition, toColumnPosition, toRowPosition);
            if (validationResult == "INVALID") { return "The piece can't move"; }

            if (verifyCheck)
            {
                var testingBoard = new Board(_boardArray);
                testingBoard.ApplyMove(fromColumnPosition, fromRowPosition, toColumnPosition, toRowPosition, validationResult);
                if (testingBoard.IsInCheck(movingPiece.PlayerColor)) { return "You can't let the king in danger!"; }
            }

            return validationResult;
        }

        /// <summary>
        /// Move the piece from (x1,y1) to (x2,y2).
        /// </summary>
        /// <param name="fromColumnPosition">From column position.</param>
        /// <param name="fromRowPosition">From row position.</param>
        /// <param name="toColumnPosition">To column position.</param>
        /// <param name="toRowPosition">To row position.</param>
        /// <param name="checkResult">The check result.</param>
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

        /// <summary>
        /// Checks the valid.
        /// </summary>
        /// <param name="checkResult">The check result.</param>
        /// <returns></returns>
        private static bool CheckValid(string checkResult) => checkResult == "VALID" || checkResult == "EN_PASSANT";

        /// <summary>
        /// Check if the given coordinates are valid.
        /// </summary>
        /// <param name="fromColumnPosition">From column position.</param>
        /// <param name="fromRowPosition">From row position.</param>
        /// <param name="toColumnPosition">To column position.</param>
        /// <param name="toRowPosition">To row position.</param>
        /// <returns></returns>
        private static bool CheckBounds(int fromColumnPosition, int fromRowPosition, int toColumnPosition, int toRowPosition)
        {
            if (fromColumnPosition < 0 || fromColumnPosition > 7) { return false; }

            if (fromRowPosition < 0 || fromRowPosition > 7) { return false; }

            if (toColumnPosition < 0 || toColumnPosition > 7) { return false; }

            if (toRowPosition < 0 || toRowPosition > 7) { return false; }

            return true;
        }

        /// <summary>
        /// Check if the king is safe from attacks.
        /// </summary>
        /// <param name="playerColor">Color of the player.</param>
        /// <returns>
        ///   <c>true</c> if [is in check] [the specified player color]; otherwise, <c>false</c>.
        /// </returns>
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
                    if (CheckValid(CheckMove(x, y, kingX, kingY, playerColor, false))) { return true; }
                }
            }

            return false;
        }

        /// <summary>
        /// Check if the player have a possible move.
        /// </summary>
        /// <param name="playerColor">Color of the player.</param>
        /// <returns></returns>
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
                            if (CheckValid(CheckMove(fromColumnPosition, fromRowPosition, toColumnPosition, toRowPosition, playerColor, true))) { return false; }
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Prints the board to the player.
        /// </summary>
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

        /// <summary>
        /// Clears the condition of the pawns (that belongs to the team passed by parameter) that flags that they are liable to be captured by "En Passant" move.
        /// </summary>
        /// <param name="playerColor">Color of the player.</param>
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

        /// <summary>
        /// Check if some Pawn (that belongs to the team passed by parameter) has reached the final line.
        /// </summary>
        /// <param name="playerColor">Color of the player.</param>
        /// <returns></returns>
        public bool CheckForPromotionAvaliable(TypeOfPlayer playerColor)
        {
            int y;
            y = playerColor == TypeOfPlayer.White ? 0 : 7;
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

        /// <summary>
        /// Promotes the Pawn that reached the final line to the piece selected by the user.
        /// </summary>
        /// <param name="selectedPiece">The selected piece.</param>
        /// <param name="playerColor">Color of the player.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            var hash = 0;
            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    unchecked { hash += _boardArray[i, j].GetHashCode(); }
                }
            }
            return hash;
        }
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Board board)
            {
                for (var i = 0; i < 8; i++)
                {
                    for (var j = 0; j < 8; j++)
                    {
                        if (_boardArray[i, j] != board._boardArray[i, j])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}