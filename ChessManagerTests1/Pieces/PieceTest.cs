using ChessManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChessManagerTests1.Pieces
{
    public abstract class PieceTest : IPieceTest
    {
        public Piece piece;
        public Board board;

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

        public TypeOfPlayer RandomColorOfPlayer()
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 2);
            return value == 1 ? TypeOfPlayer.White : TypeOfPlayer.Black;
        }

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

        public abstract void ValidMovementTest();
    }
}