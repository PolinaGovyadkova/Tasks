using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Table;

namespace ORM.Creator
{
    public interface IFactory
    {
        object NewObject<T>() where T : BaseTableElement;
        object NewObject(string fullName);
    }
}
