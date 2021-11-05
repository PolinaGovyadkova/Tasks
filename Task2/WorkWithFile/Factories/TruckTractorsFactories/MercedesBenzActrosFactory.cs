using Transport.TruckTractors;

namespace WorkWithFile.Factories.TruckTractorsFactories
{
    /// <summary>
    /// MercedesBenzActrosFactory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="WorkWithFile.AbstractFactory&lt;Transport.TruckTractors.MercedesBenzActros&gt;" />
    public class MercedesBenzActrosFactory<T> : AbstractFactory<MercedesBenzActros>
    {
        /// <summary>
        /// Create the element.
        /// </summary>
        /// <returns></returns>
        public override MercedesBenzActros CreateElement() => new MercedesBenzActros();
    }
}