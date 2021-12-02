using ORM.Table;
using System.Collections.Generic;

namespace ORM.DAO
{
    /// <summary>
    /// IFunctional
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFunctional<T> where T : BaseTableElement
    {
        /// <summary>
        /// Reads the element.
        /// </summary>
        /// <returns></returns>
        List<T> ReadElement();

        /// <summary>
        /// Reads the element.
        /// </summary>
        /// <param name="idElement">The identifier element.</param>
        /// <returns></returns>
        T ReadElement(int idElement);

        /// <summary>
        /// Creates the element.
        /// </summary>
        /// <param name="obj">The object.</param>
        void CreateElement(T obj);

        /// <summary>
        /// Updates the element.
        /// </summary>
        /// <param name="idElement">The identifier element.</param>
        /// <param name="obj">The object.</param>
        void UpdateElement(int idElement, T obj);

        /// <summary>
        /// Deletes the element.
        /// </summary>
        /// <param name="idElement">The identifier element.</param>
        void DeleteElement(int idElement);
    }
}