using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Table;

namespace CRUD
{
    public interface IFunctional<T> where T : BaseTableElement
    {
        T ReadElement(int idElement);
        void CreateElement(T obj);
        void UpdateElement(int idElement, T obj);
        void DeleteElement(int idElement);
    }
}
