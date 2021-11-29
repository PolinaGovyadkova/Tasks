namespace ClientSrever
{
    public abstract class Network
    {
        protected const int Port = 8888;

        protected const string ServerIp = "127.0.0.1";

        protected abstract void Dispouse();

        protected abstract bool SetListener();
    }
}