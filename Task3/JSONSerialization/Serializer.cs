
using System;
using System.Collections;
using System.Collections.Generic;
using Library;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dishes.Abstract;
using Dishes.Interfaces;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace JSONSerialization
{
    public class Serializer : ISerializer<Diner>
    {
        private const string Path = @"Diner.json";
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects, ContractResolver = new DictionaryAsArrayResolver() };

        public void Write(Diner diner)
        {
            string jsonString = JsonConvert.SerializeObject(diner, Settings);
            File.WriteAllText(Path, jsonString);
        }

        public Diner Read()
        {
            var json = JsonConvert.DeserializeObject(File.ReadAllText(Path), Settings);
            return (Diner)json;

        }
        
        private class DictionaryAsArrayResolver : DefaultContractResolver
        {
            protected override JsonContract CreateContract(Type objectType)
            {
                return objectType.GetInterfaces().Any(i => i == typeof(IDictionary) ||
                                                           (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDictionary<,>))) ? base.CreateArrayContract(objectType) : base.CreateContract(objectType);
            }
        }
    }
}