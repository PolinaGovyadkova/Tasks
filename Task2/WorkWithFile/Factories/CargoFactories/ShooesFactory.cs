using CargoProduct.Clothes;

namespace WorkWithFile.Factories.CargoFactories
{
    /// <summary>
    /// ShooesFactory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="WorkWithFile.AbstractFactory&lt;CargoProduct.Clothes.Shooes&gt;" />
    public class ShooesFactory<T> : AbstractFactory<Shooes>
    {
        /// <summary>
        /// Create the element.
        /// </summary>
        /// <returns></returns>
        public override Shooes CreateElement() => new Shooes();
    }
}