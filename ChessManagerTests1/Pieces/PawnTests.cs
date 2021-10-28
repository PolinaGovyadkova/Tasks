using ChessManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessManagerTests1.Pieces
{
    [TestClass()]
    public class PawnTests : PieceTest
    {
        [TestMethod()]
        public override void ValidMovementTest()
        {
            TypeOfPlayer typeOfPlayer = RandomColorOfPlayer();
            board = new Board();
            piece = new Pawn(typeOfPlayer);
            for (var i = 0; i < 8; i++)
            {
                Chek(i, typeOfPlayer == TypeOfPlayer.White ? 1 : 6, piece, board);
            }
        }

        [TestMethod()]
        public void CloneTest()
        {
            TypeOfPlayer typeOfPlayer = RandomColorOfPlayer();
            Pawn piece1 = new Pawn(typeOfPlayer);
            var pieceCloned = piece1.Clone();
            pieceCloned = RandomPiece(typeOfPlayer);
            var resultPiece = pieceCloned;
            Assert.AreNotEqual(piece1, resultPiece);
        }
    }
}