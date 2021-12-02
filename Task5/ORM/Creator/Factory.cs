using ORM.Table;
using System;
using static System.Activator;
using static System.Reflection.Assembly;

namespace ORM.Creator
{
    /// <summary>
    /// Factory
    /// </summary>
    /// <seealso cref="ORM.Creator.IFactory" />
    public class Factory : IFactory
    {
        /// <summary>
        /// Creates new object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public object NewObject<T>() where T : BaseTableElement => CreateInstance<T>();

        /// <summary>
        /// Creates new object.
        /// </summary>
        /// <param name="fullName">The full name.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public object NewObject(string fullName) => CreateInstanceFrom(GetExecutingAssembly().Location, GetExecutingAssembly().GetType(fullName).FullName ?? throw new InvalidOperationException()).Unwrap();


        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => base.GetHashCode();
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is Factory;
    }
}