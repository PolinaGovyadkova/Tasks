using ChessManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ChessManager.Enum;
using ChessManager.Pieces;

namespace ChessManagerTests1.Pieces
{
    /// <summary>
    /// PieceTest
    /// </summary>
    /// <seealso cref="ChessManagerTests1.Pieces.IPieceTest" />
    public abstract class PieceTest : IPieceTest
    {
        /// <summary>
        /// The piece
        /// </summary>
        public Piece piece;
        /// <summary>
        /// The board
        /// </summary>
        public Board board;

        /// <summary>
        /// Cheks the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="piece">The piece.</param>
        /// <param name="board">The board.</param>
        public void Chek(int x, int y, Piece piece, Board board)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    try
                    {
                        Assert.AreEqual(piece.ValidMovement(board, x, y, i, j), "VALID");
                    }
                    catch
                    {
                        Assert.AreEqual(piece.ValidMovement(board, x, y, i, j), "INVALID");
                    }
                }
            }
        }

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
        /// Randoms the piece.
        /// </summary>
        /// <param name="typeOfPlayer">The type of player.</param>
        /// <returns></returns>
        public Piece RandomPiece(TypeOfPlayer typeOfPlayer)
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

        /// <summary>
        /// Valids the movement test.
        /// </summary>
        public abstract void ValidMovementTest();
    }
}