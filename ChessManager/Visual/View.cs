using System;
using ChessManager.Interfaces;

namespace ChessManager.Visual
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ChessManager.Interfaces.IView" />
    public class View : IView
    {
        /// <summary>
        /// Shows the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public void Show(string msg) => Console.Write(msg);

        /// <summary>
        /// Gets the input string.
        /// </summary>
        /// <returns></returns>
        public object GetInputString() => Console.ReadLine();
    }
}