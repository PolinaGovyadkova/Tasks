namespace ChessManager
{
    public interface IView
    {
        void Show(string msg);

        object GetInputString();
    }
}