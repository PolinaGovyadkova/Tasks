namespace Dishes.Interfaces
{
    public interface IDish
    {
        Recipe Recipe { get; set; }
        float Weight { get; set; }
        float Size { get; set; }
        string Name { get; set; }
    }
}