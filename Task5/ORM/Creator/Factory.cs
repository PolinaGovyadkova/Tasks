using ORM.Table;
using System;
using static System.Activator;
using static System.Reflection.Assembly;

namespace ORM.Creator
{
    public class Factory : IFactory
    {
        public object NewObject<T>() where T : BaseTableElement => CreateInstance<T>();

        public object NewObject(string fullName) => CreateInstanceFrom(GetExecutingAssembly().Location, GetExecutingAssembly().GetType(fullName).FullName ?? throw new InvalidOperationException()).Unwrap();
    }
}