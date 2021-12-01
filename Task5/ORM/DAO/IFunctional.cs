using System.Collections.Generic;
using ORM.Table;

namespace ORM.DAO
{
    public interface IFunctional<T> where T : BaseTableElement
    {
        List<T> ReadElement();
        T ReadElement(int idElement);
        void CreateElement(T obj);
        void UpdateElement(int idElement, T obj);
        void DeleteElement(int idElement);
    }
}
