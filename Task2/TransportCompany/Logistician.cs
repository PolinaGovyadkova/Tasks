using CargoProduct.BaseCargo;
using CargoProduct.Interfaces;
using System;
using System.Linq;
using Transport.BaseElements;
using Transport.Trailer;

namespace TransportCompany
{
    /// <summary>
    /// Logistician
    /// </summary>
    /// <seealso cref="TransportCompany.IWorker" />
    public class Logistician : IWorker
    {
        /// <summary>
        /// The car park
        /// </summary>
        private readonly CarPark _carPark;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logistician"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="surName">Name of the sur.</param>
        /// <param name="carPark">The car park.</param>
        public Logistician(string name, string surName, CarPark carPark)
        {
            Name = name;
            Surname = surName;
            _carPark = carPark;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        public string Surname { get; set; }

        /// <summary>
        /// Remove all cargo.
        /// </summary>
        /// <param name="coupling">The coupling.</param>
        public void RemoveAllCargo(Coupling coupling) => coupling.Semitrailer.Cargo = null;

        /// <summary>
        /// Removes the part cargo.
        /// </summary>
        /// <param name="coupling">The coupling.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="volume">The volume.</param>
        public void RemovePartCargo(Coupling coupling, double weight, double volume)
        {
            coupling.Semitrailer.Cargo.PayloadCapacity -= weight;
            coupling.Semitrailer.Cargo.Volume -= volume;
        }

        /// <summary>
        /// Adds the cargo.
        /// </summary>
        /// <param name="coupling">The coupling.</param>
        /// <param name="cargo">The cargo.</param>
        /// <exception cref="System.Exception">
        /// Не совпадают типы грузов
        /// or
        /// Груз не может быть догружен из-за массы/объёма
        /// </exception>
        public void AddCargo(Coupling coupling, Cargo cargo)
        {
            foreach (var element in _carPark.Couplings.Where(element => ReferenceEquals(element, coupling)))
                if (coupling.Semitrailer.Cargo is null)
                {
                    switch (coupling.Semitrailer)
                    {
                        case Tanker _ when cargo is Fuel:
                        case Refrigerated _ when cargo is ITemperature:
                            coupling.Semitrailer.Cargo = cargo;
                            break;

                        default:
                            coupling.Semitrailer.Cargo = cargo;
                            break;
                    }
                }
                else
                {
                    if (!Equals(coupling.Semitrailer.Cargo, cargo)) throw new Exception("Не совпадают типы грузов");
                    if (coupling.Semitrailer.FreeVolume >= cargo.Volume &&
                        coupling.Semitrailer.FreeWeight >= cargo.PayloadCapacity)
                    {
                        if (coupling.Semitrailer.Cargo is ITemperature currentCargo && cargo is ITemperature newCargo)
                        {
                            var flag = true;
                            foreach (var elementCargo in currentCargo.Temperature)
                            {
                                for (var index = 0; index < newCargo.Temperature.Count && flag; index++)
                                {
                                    if (elementCargo == newCargo.Temperature[index])
                                    {
                                        coupling.Semitrailer.ProductAdd(cargo);
                                        flag = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            coupling.Semitrailer.ProductAdd(cargo);
                        }
                    }
                    else
                    {
                        throw new Exception("Груз не может быть догружен из-за массы/объёма");
                    }
                }
        }
    }
}