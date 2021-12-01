using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataBaseConnection;
using ORM.DAO;
using ORM.Table;

namespace ORM
{
    public class DataBaseSet<T> where T : BaseTableElement
    {
        private readonly Functional<T> _baseMethods;
        private readonly List<T> _listModel;

        public DataBaseSet()
        {
            var sqlConnection = new SqlConnection();
            _baseMethods = new Functional<T>(sqlConnection);
            _listModel = _baseMethods.ReadElement();
        }

        public T Read(int id) => _baseMethods.ReadElement(id);

        public void Add(T item)
        {
            _baseMethods.CreateElement(item);
            _listModel.Add(item);
        } 
        public void Update(int id, T item)
        {
            _baseMethods.UpdateElement(id, item);
        }
        public void Delete(int id)
        {
            _baseMethods.DeleteElement(id);
            _listModel.Remove(_listModel.FirstOrDefault(o => o.Id == id));
        }
       
    }
}
