using ChessManager;
using ChessManager.Enum;
using ChessManager.Pieces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessManagerTests1.Pieces
{
    [TestClass()]
    public class KnightTests : PieceTest
    {
        [TestMethod()]
        public override void ValidMovementTest()
        {
            TypeOfPlayer typeOfPlayer = RandomColorOfPlayer();
            board = new Board();
            piece = new Knight(typeOfPlayer);
            Chek(1, typeOfPlayer == TypeOfPlayer.White ? 0 : 7, piece, board);
            Chek(6, typeOfPlayer == TypeOfPlayer.White ? 0 : 7, piece, board);
        }

        [TestMethod()]
        public void CloneTest()
        {
            TypeOfPlayer typeOfPlayer = RandomColorOfPlayer();
            piece = new Knight(typeOfPlayer);
            var pieceCloned = piece.Clone();
            Assert.AreNotEqual(piece, pieceCloned);
        }
    }
}