using ORM.Table;

namespace ORM.Creator
{
    /// <summary>
    /// IFactory
    /// </summary>
    public interface IFactory
    {
        /// <summary>
        /// Creates new object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        object NewObject<T>() where T : BaseTableElement;

        /// <summary>
        /// Creates new object.
        /// </summary>
        /// <param name="fullName">The full name.</param>
        /// <returns></returns>
        object NewObject(string fullName);
    }
}