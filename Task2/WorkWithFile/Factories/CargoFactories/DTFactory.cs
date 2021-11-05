using CargoProduct.Fuels;

namespace WorkWithFile.Factories.CargoFactories
{
    /// <summary>
    /// DTFactory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="WorkWithFile.AbstractFactory&lt;CargoProduct.Fuels.DT&gt;" />
    public class DTFactory<T> : AbstractFactory<DT>
    {
        /// <summary>
        /// Create the element.
        /// </summary>
        /// <returns></returns>
        public override DT CreateElement() => new DT();
    }
}