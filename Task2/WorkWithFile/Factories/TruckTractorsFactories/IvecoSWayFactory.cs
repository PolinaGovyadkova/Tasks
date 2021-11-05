using Transport.TruckTractors;

namespace WorkWithFile.Factories.TruckTractorsFactories
{
    /// <summary>
    /// IvecoSWayFactory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="WorkWithFile.AbstractFactory&lt;Transport.TruckTractors.IvecoSWay&gt;" />
    public class IvecoSWayFactory<T> : AbstractFactory<IvecoSWay>
    {
        /// <summary>
        /// Create the element.
        /// </summary>
        /// <returns></returns>
        public override IvecoSWay CreateElement() => new IvecoSWay();
    }
}