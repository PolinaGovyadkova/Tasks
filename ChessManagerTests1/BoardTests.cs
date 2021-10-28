using System;
using ChessManager;
using ChessManager.Enum;
using ChessManager.Pieces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessManagerTests1
{
    /// <summary>
    /// BoardTests
    /// </summary>
    [TestClass()]
    public class BoardTests
    {
        /// <summary>
        /// The piece
        /// </summary>
        private Piece _piece;
        /// <summary>
        /// The board
        /// </summary>
        private Board _board = new Board();

        /// <summary>
        /// Randoms the color of player.
        /// </summary>
        /// <returns></returns>
        public TypeOfPlayer RandomColorOfPlayer()
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 2);
            return value == 1 ? TypeOfPlayer.White : TypeOfPlayer.Black;
        }

        /// <summary>
        /// Checks the move test.
        /// </summary>
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

        /// <summary>
        /// Determines whether [is in check test].
        /// </summary>
        [TestMethod()]
        public void IsInCheckTest()
        {
            Assert.IsFalse(_board.IsInCheck(RandomColorOfPlayer()));
        }

        /// <summary>
        /// Noes the possible move test.
        /// </summary>
        [TestMethod()]
        public void NoPossibleMoveTest()
        {
            Assert.IsFalse(_board.NoPossibleMove(RandomColorOfPlayer()));
        }

        /// <summary>
        /// Checks for promotion avaliable test.
        /// </summary>
        [TestMethod()]
        public void CheckForPromotionAvaliableTest()
        {
            Assert.IsFalse(_board.CheckForPromotionAvaliable(RandomColorOfPlayer()));
        }

        /// <summary>
        /// Applies the promotion test.
        /// </summary>
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