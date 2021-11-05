using CargoProduct.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Transport.BaseElements;
using Transport.Intefaces;

namespace TransportCompany
{
    /// <summary>
    /// CarPark
    /// </summary>
    /// <seealso cref="TransportCompany.ICarPark" />
    public class CarPark : ICarPark
    {
        /// <summary>
        /// Gets or sets the transports.
        /// </summary>
        /// <value>
        /// The transports.
        /// </value>
        public List<ITransport> Transports { get; set; } = new List<ITransport>();
        /// <summary>
        /// Gets or sets the semitrailers.
        /// </summary>
        /// <value>
        /// The semitrailers.
        /// </value>
        public List<Semitrailer> Semitrailers { get; set; } = new List<Semitrailer>();
        /// <summary>
        /// Gets or sets the truck tractors.
        /// </summary>
        /// <value>
        /// The truck tractors.
        /// </value>
        public List<TruckTractor> TruckTractors { get; set; } = new List<TruckTractor>();
        /// <summary>
        /// Gets the couplings.
        /// </summary>
        /// <value>
        /// The couplings.
        /// </value>
        public List<Coupling> Couplings { get; } = new List<Coupling>();

        /// <summary>
        /// Adds the transport.
        /// </summary>
        /// <param name="transport">The transport.</param>
        public void AddTransport(ITransport transport) => Transports.Add(transport);

        /// <summary>
        /// Couplings the with specific cargo.
        /// </summary>
        /// <param name="cargo">The cargo.</param>
        /// <returns></returns>
        public List<Coupling> CouplingWithSpecificCargo(ICargo cargo) => Couplings.Where(rt => Equals(rt.Semitrailer.Cargo, cargo)).ToList();

        /// <summary>
        /// Coupling with free space.
        /// </summary>
        /// <returns></returns>
        public List<Coupling> CouplingsWithFreeSpace() =>
            Couplings.Where(element =>
                element.Semitrailer.FreeWeight > 0 && element.Semitrailer.FreeWeight > 0).ToList();

        /// <summary>
        /// Creates the couplings.
        /// </summary>
        /// <param name="semitrailer">The semitrailer.</param>
        /// <param name="truckTractor">The truck tractor.</param>
        /// <exception cref="System.Exception">Тягач/прицеп уже заняты</exception>
        public void CreateCouplings(Semitrailer semitrailer, TruckTractor truckTractor)
        {
            var flag = false;
            foreach (var element in Couplings.Where(element =>
                ReferenceEquals(element.Semitrailer, semitrailer) ||
                ReferenceEquals(element.TruckTractor, truckTractor))) flag = true;
            if (truckTractor.PayloadCapacity >= semitrailer.TotalWeight && flag)
                Couplings.Add(new Coupling(truckTractor, semitrailer));
            else throw new Exception("Тягач/прицеп уже заняты");
        }

        /// <summary>
        /// Change the truck tractor.
        /// </summary>
        /// <param name="coupling">The coupling.</param>
        /// <param name="truckTractor">The truck tractor.</param>
        /// <exception cref="System.Exception">Тягач нельзя добавить</exception>
        public void ChangeTruckTractor(Coupling coupling, TruckTractor truckTractor)
        {
            if (Couplings.Any(element => ReferenceEquals(element.TruckTractor, truckTractor)))
                throw new Exception("Тягач нельзя добавить");
            for (var i = 0; i < Couplings.Count; i++)
                if (ReferenceEquals(Couplings[i], coupling))
                    Couplings[i] = new Coupling(truckTractor, Couplings[i].Semitrailer);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// Object <see cref="T:System.Collections.IEnumerator" />, which is used to pass through the collection.
        /// </returns>
        public IEnumerator GetEnumerator() => Transports.GetEnumerator();
    }
}