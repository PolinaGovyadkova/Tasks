using ChessManager.Enum;
using ChessManager.Interfaces;
using ChessManager.Visual;

namespace ChessManager.GameProcess
{
    public class Game
    {
        public string StartGame()
        {
            var game = new ChessGame(new View());
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

        private class ChessGame
        {
            public TypeOfPlayer BlackWhiteTurn;
            public readonly Board Board;
            private readonly IView _view;
            private readonly Visualization _visualization;

            public ChessGame(IView view)
            {
                Board = new Board();

                BlackWhiteTurn = TypeOfPlayer.Black;
                _view = view;
                _visualization = new Visualization(_view, Board);
            }

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

            public override int GetHashCode()
            {
                int hash = 0;
                var game = new ChessGame(new View());
                unchecked { hash += game.GetHashCode(); };
                return hash;
            }
            public override bool Equals(object obj)
            {
                return !(obj is ChessGame game);
            }
        }
    }
}