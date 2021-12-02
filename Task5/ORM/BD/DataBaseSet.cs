using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataBaseConnection;
using ORM.DAO;
using ORM.Table;

namespace ORM.BD
{
    /// <summary>
    /// Set Data Base
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="DataBaseConnection.ConnectionString" />
    /// <seealso cref="System.Collections.Generic.IEnumerable&lt;T&gt;" />
    public class DataBaseSet<T> : ConnectionString, IEnumerable<T> where T : BaseTableElement
    {
        /// <summary>
        /// The base methods
        /// </summary>
        private readonly Functional<T> _baseMethods;
        /// <summary>
        /// The list model
        /// </summary>
        private readonly List<T> _listModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataBaseSet{T}"/> class.
        /// </summary>
        public DataBaseSet()
        {
            _baseMethods = new Functional<T>(GetConnection());
            _listModel = _baseMethods.ReadElement();
        }

        /// <summary>
        /// Reads the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public T Read(int id) => _baseMethods.ReadElement(id);

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(T item)
        {
            _baseMethods.CreateElement(item);
            _listModel.Add(item);
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>
        public void Update(int id, T item)
        {
            _baseMethods.UpdateElement(id, item);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            _baseMethods.DeleteElement(id);
            _listModel.Remove(_listModel.FirstOrDefault(o => o.Id == id));
        }

        /// <summary>
        /// Возвращает перечислитель, выполняющий перебор элементов в коллекции.
        /// </summary>
        /// <returns>
        /// Перечислитель, который можно использовать для итерации по коллекции.
        /// </returns>
        public IEnumerator<T> GetEnumerator() => _listModel.GetEnumerator();

        /// <summary>
        /// Возвращает перечислитель, который осуществляет итерацию по коллекции.
        /// </summary>
        /// <returns>
        /// Объект <see cref="T:System.Collections.IEnumerator" />, который используется для прохода по коллекции.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is DataBaseSet<T>;
    }
}
