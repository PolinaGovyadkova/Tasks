using System.Collections.Generic;
using WorkWithFile.FactoryContainers;
using WorkWithFile.Interfaces;

namespace WorkWithFile
{
    /// <summary>
    /// BaseRepository
    /// </summary>
    /// <seealso cref="WorkWithFile.Interfaces.IBaseRepository" />
    public class BaseRepository : IBaseRepository
    {
        /// <summary>
        /// The repositories
        /// </summary>
        private readonly Dictionary<string, IRepository> _repositories = new Dictionary<string, IRepository>();

        /// <summary>
        /// Add the element.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <param name="repository">The repository.</param>
        public void AddElement(string elementName, IRepository repository) => _repositories.Add(elementName, repository);

        /// <summary>
        /// Get the factory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        public AbstractFactoryRepository<T> GetFactory<T>(string typeName) where T : class => _repositories[typeName] as AbstractFactoryRepository<T>;
    }
}