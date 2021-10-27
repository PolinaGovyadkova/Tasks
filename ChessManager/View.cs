using System;

namespace ChessManager
{
    public class View : IView
    {
        public void Show(string msg) => Console.Write(msg);

        public object GetInputString() => Console.ReadLine();
    }
}