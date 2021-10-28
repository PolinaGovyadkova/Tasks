namespace ChessManager.Interfaces
{
    /// <summary>
    /// View interfase
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Shows the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        void Show(string msg);

        /// <summary>
        /// Gets the input string.
        /// </summary>
        /// <returns></returns>
        object GetInputString();
    }
}