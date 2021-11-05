using Transport.Trailer;

namespace WorkWithFile.Factories.TrailerFactories
{
    /// <summary>
    /// ContainerFactory
    /// </summary>
    /// <seealso cref="WorkWithFile.AbstractFactory&lt;Transport.Trailer.Container&gt;" />
    public class ContainerFactory : AbstractFactory<Container>
    {
        /// <summary>
        /// Creates the element.
        /// </summary>
        /// <returns></returns>
        public override Container CreateElement() => new Container();
    }
}