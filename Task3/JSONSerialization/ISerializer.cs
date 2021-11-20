namespace JSONSerialization
{
    /// <summary>
    /// Serializer interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISerializer<T>
    {
        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <returns></returns>
        T Read();

        /// <summary>
        /// Writes the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        void Write(T obj);
    }
}