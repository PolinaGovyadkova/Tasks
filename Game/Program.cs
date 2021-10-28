using System;

namespace Game
{
    /// <summary>
    /// Program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Main(string[] args)
        {
            ChessManager.GameProcess.ChessGame game = new ChessManager.GameProcess.ChessGame();
            Console.WriteLine(game.StartGame());
        }
    }
}