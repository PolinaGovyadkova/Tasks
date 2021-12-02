using ORM.Table;

namespace ORM.Creator
{
    public interface IFactory
    {
        object NewObject<T>() where T : BaseTableElement;

        object NewObject(string fullName);
    }
}