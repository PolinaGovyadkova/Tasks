using CargoProduct.Foods;

namespace WorkWithFile.Factories.CargoFactories
{
    /// <summary>
    /// FishFactory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="WorkWithFile.AbstractFactory&lt;CargoProduct.Foods.Fish&gt;" />
    public class FishFactory<T> : AbstractFactory<Fish>
    {
        /// <summary>
        /// Create the element.
        /// </summary>
        /// <returns></returns>
        public override Fish CreateElement() => new Fish();
    }
}