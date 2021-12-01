using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Table
{
    public class BaseTableElement
    {
        public int Id { get; set; }
        public override string ToString() => string.Format($"Id: {Id}\n");
    }
}
