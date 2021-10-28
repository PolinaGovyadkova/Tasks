using ChessManager;
using ChessManager.Enum;
using ChessManager.Pieces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessManagerTests1.Pieces
{
    [TestClass()]
    public class RookTests : PieceTest
    {
        [TestMethod()]
        public override void ValidMovementTest()
        {
            TypeOfPlayer typeOfPlayer = RandomColorOfPlayer();
            board = new Board();
            piece = new Rook(typeOfPlayer);
            Chek(0, typeOfPlayer == TypeOfPlayer.White ? 0 : 7, piece, board);
            Chek(7, typeOfPlayer == TypeOfPlayer.White ? 0 : 7, piece, board);
        }

        [TestMethod()]
        public void CloneTest()
        {
            TypeOfPlayer typeOfPlayer = RandomColorOfPlayer();
            piece = new Rook(typeOfPlayer);
            var pieceCloned = piece.Clone();
            Assert.AreNotEqual(piece, pieceCloned);
        }
    }
}