using System.Collections.Generic;
using WorkWithFile.Interfaces;

namespace WorkWithFile.FactoryContainers
{
    /// <summary>
    /// AbstractFactoryRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="WorkWithFile.Interfaces.IRepository" />
    /// <seealso cref="WorkWithFile.Interfaces.IFactoryContainer&lt;T&gt;" />
    public abstract class AbstractFactoryRepository<T> : IRepository, IFactoryContainer<T> where T : class
    {
        /// <summary>
        /// The factories
        /// </summary>
        private readonly Dictionary<string, IFactory<T>> _factories;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractFactoryRepository{T}"/> class.
        /// </summary>
        protected AbstractFactoryRepository() => _factories = new Dictionary<string, IFactory<T>>();

        /// <summary>
        /// Add the element.
        /// </summary>
        /// <param name="factoryName">Name of the factory.</param>
        /// <param name="factory">The factory.</param>
        public void AddElement(string factoryName, IFactory<T> factory) => _factories.Add(factoryName, factory);

        /// <summary>
        /// Element the remover.
        /// </summary>
        /// <param name="factoryName">Name of the factory.</param>
        public void ElementRemover(string factoryName) => _factories.Remove(factoryName);

        /// <summary>
        /// Get the <see cref="IFactory{T}"/> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="IFactory{T}"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public IFactory<T> this[string key] => _factories[key];
    }
}