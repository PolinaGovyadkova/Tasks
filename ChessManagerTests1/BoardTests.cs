using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChessManager.Tests
{
    [TestClass()]
    public class BoardTests
    {
        private Piece _piece;
        private Board _board = new Board();

        public TypeOfPlayer RandomColorOfPlayer()
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 2);
            return value == 1 ? TypeOfPlayer.White : TypeOfPlayer.Black;
        }

        [TestMethod()]
        public void CheckMoveTest()
        {
            bool flag = true;
            Random rnd = new Random();
            int value1 = rnd.Next(0, 8);
            int value2 = rnd.Next(0, 8);
            int value3 = rnd.Next(0, 8);
            int value4 = rnd.Next(0, 8);
            string[] array = new string[]
            {
                "Values out of bounds!",
                "You can't move to the same position!",
                "You can't kill your Pieces!",
                "The piece is not yours!",
                "There is no piece.!",
                "You can't let the king in danger!",
                "The piece can't move"
            };
            string resultString = _board.CheckMove(value1, value2, value3, value4, RandomColorOfPlayer(), true);
            for (int i = 0; i < array.Length; i++)
                switch (resultString)
                {
                    case "Values out of bounds!": flag = false; break;
                    case "You can't move to the same position!": flag = false; break;
                    case "You can't kill your Pieces!": flag = false; break;
                    case "The piece is not yours!": flag = false; break;
                    case "There is no piece.!": flag = false; break;
                    case "You can't let the king in danger!": flag = false; break;
                    case "The piece can't move": flag = false; break;
                    default: flag = true; break;
                }

            if (flag == false) Assert.IsNotNull(resultString);
            else
            {
                foreach (var t in array)
                {
                    Assert.AreNotEqual(resultString, t);
                }
            }
        }

        [TestMethod()]
        public void IsInCheckTest()
        {
            Assert.IsFalse(_board.IsInCheck(RandomColorOfPlayer()));
        }

        [TestMethod()]
        public void NoPossibleMoveTest()
        {
            Assert.IsFalse(_board.NoPossibleMove(RandomColorOfPlayer()));
        }

        [TestMethod()]
        public void CheckForPromotionAvaliableTest()
        {
            Assert.IsFalse(_board.CheckForPromotionAvaliable(RandomColorOfPlayer()));
        }

        [TestMethod()]
        public void ApplyPromotionTest()
        {
            for (int i = 0; i < 8; i++)
            {
                Assert.IsTrue(_board.ApplyPromotion(i, RandomColorOfPlayer()));
            }
        }
    }
}