using ChessManager;
using ChessManager.Enum;
using ChessManager.Pieces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessManagerTests1.Pieces
{
    /// <summary>
    /// PawnTests
    /// </summary>
    /// <seealso cref="ChessManagerTests1.Pieces.PieceTest" />
    [TestClass()]
    public class PawnTests : PieceTest
    {
        /// <summary>
        /// Valids the movement test.
        /// </summary>
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

        /// <summary>
        /// Clones the test.
        /// </summary>
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