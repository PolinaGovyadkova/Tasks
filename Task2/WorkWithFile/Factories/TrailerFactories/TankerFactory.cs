using Transport.Trailer;

namespace WorkWithFile.Factories.TrailerFactories
{
    /// <summary>
    /// TankerFactory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="WorkWithFile.AbstractFactory&lt;Transport.Trailer.Tanker&gt;" />
    public class TankerFactory<T> : AbstractFactory<Tanker>
    {
        /// <summary>
        /// Creates the element.
        /// </summary>
        /// <returns></returns>
        public override Tanker CreateElement() => new Tanker();
    }
}