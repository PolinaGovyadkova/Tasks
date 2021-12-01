using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ORM.Table;

namespace CRUD
{
    public class Functional<T> : IFunctional<T> where T : BaseTableElement
    {
        private SqlConnection _sqlConnectionString;

        public Functional(SqlConnection sqlConnectionString)
        {
            _sqlConnectionString = sqlConnectionString;
        }

        public T ReadElement(int idElement)
        {
            throw new NotImplementedException();
        }

        public void CreateElement(T obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateElement(int idElement, T obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteElement(int idElement)
        {
            throw new NotImplementedException();
        }
    }
}
