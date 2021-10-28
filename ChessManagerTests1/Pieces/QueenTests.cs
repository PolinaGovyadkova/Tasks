using ChessManager;
using ChessManager.Enum;
using ChessManager.Pieces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessManagerTests1.Pieces
{
    /// <summary>
    /// QueenTests
    /// </summary>
    /// <seealso cref="ChessManagerTests1.Pieces.PieceTest" />
    [TestClass()]
    public class QueenTests : PieceTest
    {
        /// <summary>
        /// Valids the movement test.
        /// </summary>
        [TestMethod()]
        public override void ValidMovementTest()
        {
            TypeOfPlayer typeOfPlayer = RandomColorOfPlayer();
            board = new Board();
            piece = new Queen(typeOfPlayer);
            Chek(3, typeOfPlayer == TypeOfPlayer.White ? 0 : 7, piece, board);
        }

        /// <summary>
        /// Clones the test.
        /// </summary>
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