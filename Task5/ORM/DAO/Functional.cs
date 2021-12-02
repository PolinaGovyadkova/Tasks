using ORM.Creator;
using ORM.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace ORM.DAO
{
    /// <summary>
    /// Functional
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="ORM.DAO.IFunctional&lt;T&gt;" />
    public class Functional<T> : IFunctional<T> where T : BaseTableElement
    {
        /// <summary>
        /// The SQL connection string
        /// </summary>
        private readonly SqlConnection _sqlConnectionString;
        /// <summary>
        /// The factory
        /// </summary>
        private readonly Factory _factory;
        /// <summary>
        /// The type
        /// </summary>
        private readonly Type _type;

        /// <summary>
        /// Initializes a new instance of the <see cref="Functional{T}"/> class.
        /// </summary>
        /// <param name="sqlConnectionString">The SQL connection string.</param>
        public Functional(SqlConnection sqlConnectionString)
        {
            _sqlConnectionString = sqlConnectionString;
            _factory = new Factory();
            _type = typeof(T);
        }

        /// <summary>
        /// Reads the element.
        /// </summary>
        /// <param name="idElement">The identifier element.</param>
        /// <returns></returns>
        public T ReadElement(int idElement)
        {
            _sqlConnectionString.Open();
            object newObject = null;
            var read = $"select * from [{_type.Name}] where id = @Id;";
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

        /// <summary>
        /// Creates the element.
        /// </summary>
        /// <param name="newObject">The new object.</param>
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
                            ? $"{((DateTime)property.GetValue(newObject)):yyyy.MM.dd}"
                            : $"{property.GetValue(newObject)}");

                    i++;
                }
            }
            Process(sqlCommand);
        }

        /// <summary>
        /// Updates the element.
        /// </summary>
        /// <param name="idElement">The identifier element.</param>
        /// <param name="newObject">The new object.</param>
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
                            ? $"{((DateTime)property.GetValue(newObject)):yyyy.MM.dd}"
                            : $"{property.GetValue(newObject)}");
            }

            sqlCommand.Parameters.AddWithValue($"{_type.Name}", _type.Name);
            sqlCommand.Parameters.AddWithValue("@Id", $"{idElement}");
            Process(sqlCommand);
        }

        /// <summary>
        /// Deletes the element.
        /// </summary>
        /// <param name="idElement">The identifier element.</param>
        public void DeleteElement(int idElement)
        {
            var delete = $"delete from [{_type.Name}] where Id = @Id;";
            var sqlCommand = new SqlCommand(delete, _sqlConnectionString);
            sqlCommand.Parameters.AddWithValue("@Id", $"{idElement}");
            Process(sqlCommand);
        }

        /// <summary>
        /// Reads the element.
        /// </summary>
        /// <returns></returns>
        public List<T> ReadElement()
        {
            _sqlConnectionString.Open();

            var sqlSelectCommand = $"select * FROM [{typeof(T).Name}]";
            var sqlCommand = new SqlCommand(sqlSelectCommand, _sqlConnectionString);
            var reader = sqlCommand.ExecuteReader();

            var list = new List<T>();
            var obj = _factory.NewObject<T>();

            var columnsNumber = reader.FieldCount;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    for (var i = 0; i < columnsNumber; i++)
                    {
                        var fieldName = reader.GetName(i);
                        var propInfo = obj.GetType().GetProperty(fieldName);

                        if (!(reader.GetValue(i) is DBNull))
                        {
                            propInfo?.SetValue(obj, reader.GetValue(i));
                        }
                    }

                    list.Add((T)obj);
                    obj = _factory.NewObject(typeof(T).FullName);
                }
            }

            _sqlConnectionString.Close();
            return list;
        }

        /// <summary>
        /// Processes the specified SQL command.
        /// </summary>
        /// <param name="sqlCommand">The SQL command.</param>
        /// <exception cref="ORM.DAO.SQLException"></exception>
        private void Process(IDbCommand sqlCommand)
        {
            try
            {
                _sqlConnectionString.Open();
                sqlCommand.ExecuteNonQuery();
                _sqlConnectionString.Close();
            }
            catch (Exception e)
            {
                throw new SQLException(e.Message);
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <returns></returns>
        private static string GetName(PropertyInfo property) => property.Name;

        /// <summary>
        /// Checkers the specified property.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <returns></returns>
        private static bool Checker(PropertyInfo property) => property != null && (GetName(property) != "Id" && property.PropertyType.BaseType != typeof(BaseTableElement));

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => _sqlConnectionString.GetHashCode() + _factory.GetHashCode() + _type.GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is Functional<T> functional && _sqlConnectionString == functional._sqlConnectionString && _factory == functional._factory && _type == functional._type;
    }
}