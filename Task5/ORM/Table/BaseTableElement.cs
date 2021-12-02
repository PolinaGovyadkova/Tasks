namespace ORM.Table
{
    public class BaseTableElement
    {
        public int Id { get; set; }

        public override string ToString() => string.Format($"Id: {Id}\n");
    }
}