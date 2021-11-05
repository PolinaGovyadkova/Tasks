using Transport.Trailer;

namespace WorkWithFile.Factories.TrailerFactories
{
    /// <summary>
    /// RefrigeratedFactory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="WorkWithFile.AbstractFactory&lt;Transport.Trailer.Refrigerated&gt;" />
    public class RefrigeratedFactory<T> : AbstractFactory<Refrigerated>
    {
        /// <summary>
        /// Creates the element.
        /// </summary>
        /// <returns></returns>
        public override Refrigerated CreateElement() => new Refrigerated();
    }
}