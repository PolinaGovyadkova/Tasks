using System;
using ChessManager.Interfaces;

namespace ChessManager.Visual
{
    public class View : IView
    {
        public void Show(string msg) => Console.Write(msg);

        public object GetInputString() => Console.ReadLine();
    }
}