namespace ChessManager.Interfaces
{
    public interface IView
    {
        void Show(string msg);

        object GetInputString();
    }
}