namespace WorkWithFile.Interfaces
{
    /// <summary>
    /// IFactoryContainer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFactoryContainer<T> where T : class
    {
        /// <summary>
        /// Adds the element.
        /// </summary>
        /// <param name="factoryName">Name of the factory.</param>
        /// <param name="factory">The factory.</param>
        void AddElement(string factoryName, IFactory<T> factory);

        /// <summary>
        /// Elements the remover.
        /// </summary>
        /// <param name="factoryName">Name of the factory.</param>
        void ElementRemover(string factoryName);
    }
}