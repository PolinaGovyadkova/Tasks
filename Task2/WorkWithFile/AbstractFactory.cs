using WorkWithFile.Interfaces;

namespace WorkWithFile
{
    /// <summary>
    /// AbstractFactory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="WorkWithFile.Interfaces.IFactory&lt;T&gt;" />
    public abstract class AbstractFactory<T> : IFactory<T> where T : class
    {
        /// <summary>
        /// Creates the element.
        /// </summary>
        /// <returns></returns>
        public abstract T CreateElement();
    }
}