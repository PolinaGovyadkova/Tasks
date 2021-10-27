using System;
using System.Threading;

namespace Game
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ChessManager.Game game = new ChessManager.Game();
            Console.WriteLine(game.StartGame());
            try
            {
                Thread.Sleep(5000);
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("newThread cannot go to sleep - " +
                                  "interrupted by main thread.");
            }
        }
    }
}