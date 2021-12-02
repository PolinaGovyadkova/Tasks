using System;

namespace ORM.Table
{
    public class Client : BaseTableElement
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthYear { get; set; }

        public override string ToString() => base.ToString() + string.Format($"FullName {FullName} Gender {Gender} BirthDate {BirthYear}");
    }
}