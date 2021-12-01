using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using ORM.Creator;
using ORM.Table;

namespace ORM.DAO
{
    public class Functional<T> : IFunctional<T> where T : BaseTableElement
    {
        private readonly SqlConnection _sqlConnectionString;
        private readonly Factory _factory;
        private readonly Type _type;

        public Functional(SqlConnection sqlConnectionString)
        {
            _sqlConnectionString = sqlConnectionString;
            _factory = new Factory();
            _type = typeof(T);
        } 

        public T ReadElement(int idElement)
        {
            _sqlConnectionString.Open();
            object newObject = null;
            var read = $"read * from [{_type.Name}] where id = @Id;";
            SqlDataReader reader;
            using (var sqlCommand = new SqlCommand(read, _sqlConnectionString))
            {
                sqlCommand.Parameters.AddWithValue("@Id", $"{idElement}");
                reader = sqlCommand.ExecuteReader();
            }
            if (reader.HasRows)
            {
                reader.Read();
                if (_factory != null) newObject = _factory.NewObject<T>();

                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var information = typeof(T).GetProperty(reader.GetName(i));
                    information?.SetValue(newObject, reader.GetValue(i));
                }
            }

            _sqlConnectionString.Close();
            return newObject as T;
        }

        public void CreateElement(T newObject)
        {
            var name = new List<string>();
            var create = $"insert into [{_type.Name}] (";
            foreach (var property in typeof(T).GetProperties()) 
            {
                if (Checker(property))
                {
                    create += $"[{GetName(property)}],";
                    name.Add($"{GetName(property)}");
                }
            }
            create = create.Remove(create.Length - 1) + ") values (";
            foreach (var property in typeof(T).GetProperties())
            {
                if (Checker(property))
                {
                    var propValue = property.GetValue(newObject);
                    create += $"@{GetName(property)},";
                }
            }

            create = create.Remove(create.Length - 1) + ");";
            var sqlCommand = new SqlCommand(create, _sqlConnectionString);
            var i = 0;
            foreach (var property in _type.GetProperties())
            {
                if (Checker(property))
                {
                    sqlCommand.Parameters.AddWithValue($"@{name[i]}",
                        property.PropertyType == typeof(DateTime)
                            ? $"{((DateTime) property.GetValue(newObject)):yyyy.MM.dd}"
                            : $"{property.GetValue(newObject)}");

                    i++;
                }
            }
            Process(sqlCommand);
        }
        public void UpdateElement(int idElement, T newObject)
        {
            var update = $"update {_type.Name} SET ";
            foreach (var info in _type.GetProperties().Where(Checker))
            {
                update += $"{GetName(info)} = @{GetName(info)},";
            }
            update = update.Remove(update.Length - 1) + $" where Id = @Id;";
            var sqlCommand = new SqlCommand(update, _sqlConnectionString);
            foreach (var property in _type.GetProperties())
            {
                if (Checker(property))
                    sqlCommand.Parameters.AddWithValue($"@{GetName(property)}",
                        property.PropertyType == typeof(DateTime)
                            ? $"{((DateTime) property.GetValue(newObject)):yyyy.MM.dd}"
                            : $"{property.GetValue(newObject)}");
            }

            sqlCommand.Parameters.AddWithValue($"{_type.Name}", _type.Name);
            sqlCommand.Parameters.AddWithValue("@Id", $"{idElement}");
            Process(sqlCommand);
        }

        public void DeleteElement(int idElement)
        {
            var delete = $"delete from [{_type.Name}] where Id = @Id;";
            var sqlCommand = new SqlCommand(delete, _sqlConnectionString);
            sqlCommand.Parameters.AddWithValue("@Id", $"{idElement}");
            Process(sqlCommand);

        }
        public List<T> ReadElement()
        {
            var allElements = new List<T>();
            try
            {
                _sqlConnectionString.Open();
                var readAll = $"read * from [{_type.Name}]";
                var sqlCommand = new SqlCommand(readAll, _sqlConnectionString);
                var reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (_factory != null)
                        {
                            object newObject = (BaseTableElement)_factory.NewObject(_type.FullName);
                            for (var i = 0; i < reader.FieldCount; i++)
                            {
                                var information = newObject.GetType().GetProperty(reader.GetName(i));
                                if (!(reader.GetValue(i) is DBNull)) information?.SetValue(newObject, reader.GetValue(i));
                            }

                            allElements.Add(newObject as T);
                        }
                    }
                }
                _sqlConnectionString.Close();
                return allElements;
            }
            catch
            {
                throw new Exception("Sql query error.");
            }
        }


        private void Process(IDbCommand sqlCommand)
        {
            try
            {
                _sqlConnectionString.Open();
                sqlCommand.ExecuteNonQuery();
                _sqlConnectionString.Close();
            }
            catch (Exception)
            {
                throw new Exception("Sql query error.");
            }
        }

        private static string GetName(PropertyInfo property) => property.Name;
        private static bool Checker(PropertyInfo property) => property != null && (GetName(property) != "Id" && property.PropertyType.BaseType != typeof(BaseTableElement));
    }
}
