using WorkWithFile.FactoryContainers;

namespace WorkWithFile.Interfaces
{
    /// <summary>
    /// IBaseRepository
    /// </summary>
    public interface IBaseRepository
    {
        /// <summary>
        /// Adds the element.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <param name="repository">The repository.</param>
        void AddElement(string elementName, IRepository repository);

        /// <summary>
        /// Gets the factory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        AbstractFactoryRepository<T> GetFactory<T>(string typeName) where T : class;
    }
}