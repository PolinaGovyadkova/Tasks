using System;
using System.IO;

namespace ChessManager
{
    public class Visualization
    {
        private LoggerChess.Logger logger = new LoggerChess.Logger("Log.txt");
        private readonly IView _view;
        private readonly Board _board;

        public Visualization(IView view, Board board)
        {
            this._view = view;
            this._board = board;
        }

        public int ChoosePieceForPromotion()
        {
            _view.Show("Choose the promotion:");
            _view.Show("\n1 - Queen \n2 - Rook\n3 - Bishop\n4 - Knight");
            _view.Show("Your choice: ");
            var result = 0;
            try
            {
                result = Convert.ToInt32(_view.GetInputString());
                switch (result)
                {
                    case 1: logger.Log("Queen"); break;
                    case 2: logger.Log("Rook"); break;
                    case 3: logger.Log("Bishop"); break;
                    case 4: logger.Log("Knight"); break;
                }
                logger.Log(result.ToString());
            }
            catch (FormatException e) { _view.Show(e.ToString()); }
            catch (IOException e) { _view.Show(e.ToString()); };
            return result;
        }

        public string InputMove(TypeOfPlayer blackWhiteTurn)
        {
            try
            {
                _view.Show("Origin X: ");
                var fromColumnPosition = Convert.ToInt32(_view.GetInputString());
                logger.Log("From X" + fromColumnPosition.ToString());
                _view.Show("Origin Y: ");
                var fromRowPosition = Convert.ToInt32(_view.GetInputString());
                logger.Log("From Y" + fromRowPosition.ToString());
                _view.Show("Destination X: ");
                var toColumnPosition = Convert.ToInt32(_view.GetInputString());
                logger.Log("To X" + toColumnPosition.ToString());
                _view.Show("Destination Y: ");
                var toRowPosition = Convert.ToInt32(_view.GetInputString());
                logger.Log("To Y" + toRowPosition.ToString());

                return _board.Move(fromColumnPosition, fromRowPosition, toColumnPosition, toRowPosition, blackWhiteTurn);
            }
            catch (IOException e)
            {
                logger.Log(Convert.ToString(e));
                return Convert.ToString(e);
            }
            catch (FormatException e)
            {
                logger.Log(Convert.ToString(e));
                return "This is not a valid number.";
            }
        }

        public void PrintTurn(TypeOfPlayer blackWhiteTurn)
        {
            if (blackWhiteTurn == TypeOfPlayer.White)
            {
                _view.Show("White plays now...");
                logger.Log("White plays now...");
            }
            else
            {
                _view.Show("Black plays now...");
                logger.Log("Black plays now...");
            }
        }

        public void Print(TypeOfPlayer blackWhiteTurn)
        {
            if (_board.IsInCheck(blackWhiteTurn))
            {
                _view.Show("CHECK!");
            }
        }
    }
}