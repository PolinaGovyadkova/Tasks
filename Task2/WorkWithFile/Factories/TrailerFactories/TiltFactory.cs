using Transport.Trailer;

namespace WorkWithFile.Factories.TrailerFactories
{
    /// <summary>
    /// TiltFactoryTiltFactory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="WorkWithFile.AbstractFactory&lt;Transport.Trailer.Tilt&gt;" />
    public class TiltFactory<T> : AbstractFactory<Tilt>
    {
        /// <summary>
        /// Creates the element.
        /// </summary>
        /// <returns></returns>
        public override Tilt CreateElement() => new Tilt();
    }
}