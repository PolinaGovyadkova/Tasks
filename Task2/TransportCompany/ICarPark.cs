using CargoProduct.Interfaces;
using System.Collections;
using System.Collections.Generic;
using Transport.BaseElements;
using Transport.Intefaces;

namespace TransportCompany
{
    /// <summary>
    /// ICarPark
    /// </summary>
    /// <seealso cref="System.Collections.IEnumerable" />
    public interface ICarPark : IEnumerable
    {
        /// <summary>
        /// Coupling the with specific cargo.
        /// </summary>
        /// <param name="cargo">The cargo.</param>
        /// <returns></returns>
        List<Coupling> CouplingWithSpecificCargo(ICargo cargo);

        /// <summary>
        /// Coupling with free space.
        /// </summary>
        /// <returns></returns>
        List<Coupling> CouplingsWithFreeSpace();

        /// <summary>
        /// Create the couplings.
        /// </summary>
        /// <param name="semitrailer">The semitrailer.</param>
        /// <param name="truckTractor">The truck tractor.</param>
        void CreateCouplings(Semitrailer semitrailer, TruckTractor truckTractor);

        /// <summary>
        /// Change the truck tractor.
        /// </summary>
        /// <param name="coupling">The coupling.</param>
        /// <param name="truckTractor">The truck tractor.</param>
        void ChangeTruckTractor(Coupling coupling, TruckTractor truckTractor);

        /// <summary>
        /// Add the transport.
        /// </summary>
        /// <param name="truck">The truck.</param>
        void AddTransport(ITransport truck);
    }
}