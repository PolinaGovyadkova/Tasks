using ChessManager.Enum;
using ChessManager.Interfaces;
using ChessManager.Visual;

namespace ChessManager.GameProcess
{
    /// <summary>
    /// ChessGame
    /// </summary>
    public class ChessGame
    {
        /// <summary>
        /// Creates a new chess game.
        /// </summary>
        /// <returns></returns>
        public string StartGame()
        {
            var game = new Game(new View());
            while (!game.Board.NoPossibleMove(game.BlackWhiteTurn))
            {
                game.PlayTurn();
                game.ChangeTurn();
            }

            game.Board.PrintBoard();
            game.PlayTurn();
            if (game.Board.IsInCheck(game.BlackWhiteTurn))
            {
                return game.BlackWhiteTurn == TypeOfPlayer.White ? "BLACK WINS!" : "WHITE WINS!";
            }
            return "This game is over!";
        }

        /// <summary>
        /// Game
        /// </summary>
        private class Game
        {
            /// <summary>
            /// The black white turn
            /// </summary>
            public TypeOfPlayer BlackWhiteTurn;
            /// <summary>
            /// The board
            /// </summary>
            public readonly Board Board;
            /// <summary>
            /// The view
            /// </summary>
            private readonly IView _view;
            /// <summary>
            /// The visualization
            /// </summary>
            private readonly Visualization _visualization;

            /// <summary>
            /// Initializes a new instance of the <see cref="ChessGame"/> class.
            /// </summary>
            /// <param name="view">The view.</param>
            public Game(IView view)
            {
                Board = new Board();

                BlackWhiteTurn = TypeOfPlayer.Black;
                _view = view;
                _visualization = new Visualization(_view, Board);
            }

            /// <summary>
            /// Pawns the promotion.
            /// </summary>
            private void PawnPromotion()
            {
                if (Board.CheckForPromotionAvaliable(BlackWhiteTurn))
                {
                    Board.PrintBoard();
                    var selectedPiece = _visualization.ChoosePieceForPromotion();

                    while (!Board.ApplyPromotion(selectedPiece, BlackWhiteTurn))
                    {
                        selectedPiece = _visualization.ChoosePieceForPromotion();
                    }
                }
            }

            /// <summary>
            /// Changes the turn.
            /// </summary>
            public void ChangeTurn()
            {
                switch (BlackWhiteTurn)
                {
                    case TypeOfPlayer.White:
                        Board.ClearEnPassingAllows(TypeOfPlayer.Black);
                        PawnPromotion();
                        BlackWhiteTurn = TypeOfPlayer.Black;
                        break;

                    case TypeOfPlayer.Black:
                        Board.ClearEnPassingAllows(TypeOfPlayer.White);
                        PawnPromotion();
                        BlackWhiteTurn = TypeOfPlayer.White;
                        break;
                }
            }

            /// <summary>
            /// Start the next turn.
            /// </summary>
            public void PlayTurn()
            {
                Board.PrintBoard();
                _visualization.Print(BlackWhiteTurn);
                _visualization.PrintTurn(BlackWhiteTurn);

                while (true)
                {
                    var moveResult = _visualization.InputMove(BlackWhiteTurn);
                    if (moveResult != null)
                    {
                        Board.PrintBoard();
                        _view.Show(moveResult);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            /// <summary>
            /// Returns a hash code for this instance.
            /// </summary>
            /// <returns>
            /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public override int GetHashCode()
            {
                int hash = 0;
                var game = new Game(new View());
                unchecked { hash += game.GetHashCode(); }

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
                return !(obj is ChessGame game);
            }
        }
    }
}