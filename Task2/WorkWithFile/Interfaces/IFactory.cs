namespace WorkWithFile.Interfaces
{
    /// <summary>
    /// IFactory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFactory<out T> where T : class
    {
        /// <summary>
        /// Creates the element.
        /// </summary>
        /// <returns></returns>
        T CreateElement();
    }
}