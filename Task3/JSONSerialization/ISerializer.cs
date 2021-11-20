namespace JSONSerialization
{
    public interface ISerializer<T>
    {
        T Read();

        void Write(T obj);
    }
}