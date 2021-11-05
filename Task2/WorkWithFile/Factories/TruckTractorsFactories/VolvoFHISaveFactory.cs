using Transport.TruckTractors;

namespace WorkWithFile.Factories.TruckTractorsFactories
{
    /// <summary>
    ///VolvoFHISaveFactory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="WorkWithFile.AbstractFactory&lt;Transport.TruckTractors.VolvoFHISave&gt;" />
    public class VolvoFHISaveFactory<T> : AbstractFactory<VolvoFHISave>
    {
        /// <summary>
        /// Create the element.
        /// </summary>
        /// <returns></returns>
        public override VolvoFHISave CreateElement() => new VolvoFHISave();
    }
}