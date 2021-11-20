
using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Diner;
using Dishes.Abstract;
using Dishes.Interfaces;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace JSONSerialization
{
    /// <summary>
    /// Serializer
    /// </summary>
    /// <seealso cref="Eatery" />
    public class Serializer : ISerializer<Eatery>
    {
        /// <summary>
        /// The path
        /// </summary>
        private const string Path = @"Diner.json";
        /// <summary>
        /// The settings
        /// </summary>
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects, ContractResolver = new DictionaryAsArrayResolver() };

        /// <summary>
        /// Writes the specified diner.
        /// </summary>
        /// <param name="diner">The diner.</param>
        public void Write(Eatery diner)
        {
            string jsonString = JsonConvert.SerializeObject(diner, Settings);
            File.WriteAllText(Path, jsonString);
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <returns></returns>
        public Eatery Read()
        {
            var json = JsonConvert.DeserializeObject(File.ReadAllText(Path), Settings);
            return (Eatery)json;

        }

        /// <summary>
        /// Dictionary As Array Resolver
        /// </summary>
        /// <seealso cref="Newtonsoft.Json.Serialization.DefaultContractResolver" />
        private class DictionaryAsArrayResolver : DefaultContractResolver
        {
            /// <summary>
            /// Determines which contract type is created for the given type.
            /// </summary>
            /// <param name="objectType">Type of the object.</param>
            /// <returns>
            /// A <see cref="T:Newtonsoft.Json.Serialization.JsonContract" /> for the given type.
            /// </returns>
            protected override JsonContract CreateContract(Type objectType)
            {
                return objectType.GetInterfaces().Any(i => i == typeof(IDictionary) ||
                                                           (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDictionary<,>))) ? base.CreateArrayContract(objectType) : base.CreateContract(objectType);
            }
        }
    }
}