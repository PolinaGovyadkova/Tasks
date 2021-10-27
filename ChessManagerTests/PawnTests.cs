using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChessManager.Tests
{
    [TestClass()]
    public class PawnTests
    {
        [TestMethod()]
        public void PawnTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IsValidMoveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IdentifyTest()
        {
            Assert.Fail();
        }

        private TypeOfPlayer randomColorOfPlayer()
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 2);
            if (value == 1) return TypeOfPlayer.White;
            else return TypeOfPlayer.Black;
        }

        private Piece randomPiece(TypeOfPlayer typeOfPlayer)
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 5);
            switch (value)
            {
                case 1: return new King(typeOfPlayer);
                case 2: return new Queen(typeOfPlayer);
                case 3: return new Rook(typeOfPlayer);
                case 4: return new Bishop(typeOfPlayer);
            }
            return new Bishop(typeOfPlayer);
        }

        [TestMethod()]
        public void CloneTestKing()
        {
            TypeOfPlayer typeOfPlayer = randomColorOfPlayer();
            // Arrange
            Pawn piece1 = new Pawn(typeOfPlayer);
            // Act
            var pieceCloned = piece1.Clone();
            pieceCloned = randomPiece(typeOfPlayer);
            var resultPiece = pieceCloned;

            // Assert

            Assert.AreNotEqual(piece1, resultPiece);
            //Assert.IsTrue(ComparePiece(piece1, resultPiece));
        }

        [TestMethod()]
        public void ClearEnPassantLiabilityTest()
        {
            Assert.Fail();
        }
    }
}