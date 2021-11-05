using System.Collections.Generic;
using Transport.BaseElements;

namespace TransportCompany
{
    /// <summary>
    /// TransportSearchEngine
    /// </summary>
    public class TransportSearchEngine
    {
        /// <summary>
        /// Find the semitrailer by characteristics.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="payload">The payload.</param>
        /// <param name="volume">The volume.</param>
        /// <returns></returns>
        public List<T> FindSemitrailerByCharacteristics<T>(double payload, double volume)
            where T : Semitrailer
        {
            var transports = FindSemitrailerByType<T>();
            return transports.FindAll(element => element.PayloadCapacity == payload && element.Volume == volume);
        }

        /// <summary>
        /// Find the type of the semitrailer by.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> FindSemitrailerByType<T>()
            where T : Semitrailer
        {
            var transports = new List<T>();
            foreach (var element in transports)
                if (element is T trailer)
                    transports.Add(trailer);
            return transports;
        }
    }
}