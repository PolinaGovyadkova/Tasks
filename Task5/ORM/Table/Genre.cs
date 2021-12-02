namespace ORM.Table
{
    public class Genre : BaseTableElement
    {
        public string Name { get; set; }

        public override string ToString() => base.ToString() + string.Format($"Name {Name}");
    }
}