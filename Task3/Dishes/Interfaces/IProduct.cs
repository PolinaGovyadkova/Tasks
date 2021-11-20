namespace Dishes.Interfaces
{
    public interface IProduct : ITemperature
    {
        float Size { get; set; }
        float Weight { get; set; }
        float Price { get; set; }
    }
}