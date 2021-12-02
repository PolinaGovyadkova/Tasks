namespace ORM.Table
{
    public class Author : BaseTableElement
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public override string ToString() => base.ToString() + string.Format($"Name {Name} Surname {Surname} Patronymic {Patronymic}");
    }
}