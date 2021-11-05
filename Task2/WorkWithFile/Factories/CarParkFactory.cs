using TransportCompany;

namespace WorkWithFile.Factories
{
    /// <summary>
    /// CarParkFactory
    /// </summary>
    /// <seealso cref="WorkWithFile.AbstractFactory&lt;TransportCompany.CarPark&gt;" />
    public class CarParkFactory : AbstractFactory<CarPark>
    {
        /// <summary>
        /// Create the element.
        /// </summary>
        /// <returns></returns>
        public override CarPark CreateElement() => new CarPark();
    }
}