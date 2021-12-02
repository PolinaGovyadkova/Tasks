namespace ORM.Table
{
    public class Book : BaseTableElement
    {
        public string Name { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }

        public override string ToString() => base.ToString() + string.Format($"Name {Name} GenreId {GenreId} AuthorId {AuthorId}");
    }
}