using System;

namespace ORM
{
    public class SQLException : Exception
    {
        public SQLException(string message)
            : base("Sql query error: \r\n" + message)
        {
        }

    }
}
