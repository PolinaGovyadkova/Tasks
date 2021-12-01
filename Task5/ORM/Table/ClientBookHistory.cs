using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Table
{
    public class ClientBookHistory : BaseTableElement
    {
        public DateTime ReceivingDate { get; set; }
        public int BookId { get; set; }
        public int ClientId { get; set; }
        public bool IsReturn { get; set; }
        public string BookCondition { get; set; }
        public override string ToString() => base.ToString() + string.Format($"ReceivingDate {ReceivingDate}  BookId {BookId}  ClientId {ClientId} IsReturn {IsReturn} BookCondition {BookCondition}");
    }
}
