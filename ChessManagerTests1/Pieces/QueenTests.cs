using ChessManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessManagerTests1.Pieces
{
    [TestClass()]
    public class QueenTests : PieceTest
    {
        [TestMethod()]
        public override void ValidMovementTest()
        {
            TypeOfPlayer typeOfPlayer = RandomColorOfPlayer();
            board = new Board();
            piece = new Queen(typeOfPlayer);
            Chek(3, typeOfPlayer == TypeOfPlayer.White ? 0 : 7, piece, board);
        }

        [TestMethod()]
        public void CloneTest()
        {
            TypeOfPlayer typeOfPlayer = RandomColorOfPlayer();
            piece = new Queen(typeOfPlayer);
            var pieceCloned = piece.Clone();
            Assert.AreNotEqual(piece, pieceCloned);
        }
    }
}