using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Transport.BaseElements;
using TransportCompany;

namespace TransportCompanyTests
{
    /// <summary>
    /// LogisticianTests
    /// </summary>
    /// <seealso cref="TransportCompanyTests.BaseElement" />
    [TestClass()]
    public class LogisticianTests : BaseElement
    {
        /// <summary>
        /// Removes all cargo test.
        /// </summary>
        [TestMethod()]
        public void RemoveAllCargoTest()
        {
            CarPark = new CarPark();
            var coupling = GetCouplings()[0];
            CarPark.Couplings.Add(coupling);
            var logistician = new Logistician("", "", CarPark);
            logistician.AddCargo(coupling, GetCargo()[1]);
            logistician.RemoveAllCargo(coupling);
            Assert.IsNull(CarPark.Couplings[0].Semitrailer.Cargo);
        }

        /// <summary>
        /// Removes the part cargo test.
        /// </summary>
        [TestMethod()]
        public void RemovePartCargoTest()
        {
            CarPark = new CarPark();
            var coupling = GetCouplings()[0];
            CarPark.Couplings.Add(coupling);
            var logistician = new Logistician("", "", CarPark);
            logistician.AddCargo(coupling, GetCargo()[0]);
            var payloadCapacity = coupling.Semitrailer.Cargo.PayloadCapacity;
            var volume = coupling.Semitrailer.Cargo.Volume;
            logistician.RemovePartCargo(coupling, 10, 10);
            Assert.AreNotEqual(coupling.Semitrailer.Cargo.PayloadCapacity, payloadCapacity);
            Assert.AreNotEqual(coupling.Semitrailer.Cargo.Volume, volume);
        }

        /// <summary>
        /// Adds the cargo test.
        /// </summary>
        [TestMethod()]
        public void AddCargoTest()
        {
            CarPark = new CarPark();
            var coupling = new Coupling(GetTrcuckTractors()[0], GetSemitrailers()[0]);
            CarPark.Couplings.Add(coupling);
            var logistician = new Logistician("", "", CarPark);
            logistician.AddCargo(coupling, GetCargo()[1]);
            var payloadCapacity = coupling.Semitrailer.Cargo.PayloadCapacity;
            var volume = coupling.Semitrailer.Cargo.Volume;
            logistician.AddCargo(coupling, GetCargo()[1]);

            Assert.AreNotEqual(coupling.Semitrailer.Cargo.PayloadCapacity, payloadCapacity);
            Assert.AreNotEqual(coupling.Semitrailer.Cargo.Volume, volume);
        }

        /// <summary>
        /// Adds the cargo test exception.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void AddCargoTestException()
        {
            CarPark = new CarPark();
            var coupling = new Coupling(GetTrcuckTractors()[0], GetSemitrailers()[0]);
            CarPark.Couplings.Add(coupling);
            var logistician = new Logistician("", "", CarPark);
            logistician.AddCargo(coupling, GetCargo()[2]);
            var payloadCapacity = coupling.Semitrailer.Cargo.PayloadCapacity;
            var volume = coupling.Semitrailer.Cargo.Volume;
            logistician.AddCargo(coupling, GetCargo()[0]);

            Assert.AreNotEqual(coupling.Semitrailer.Cargo.PayloadCapacity, payloadCapacity);
            Assert.AreNotEqual(coupling.Semitrailer.Cargo.Volume, volume);
        }
    }
}