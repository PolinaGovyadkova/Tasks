using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Transport.BaseElements;
using TransportCompany;

namespace TransportCompanyTests
{
    /// <summary>
    /// CarParkTests
    /// </summary>
    /// <seealso cref="TransportCompanyTests.BaseElement" />
    [TestClass()]
    public class CarParkTests
    {
        Random Random = new Random();
        private CarPark _carPark;
        /// <summary>
        /// Adds the transport test.
        /// </summary>
        [TestMethod()]
        public virtual void AddTransportTest()
        {
            _carPark = new CarPark();
            _carPark.AddTransport(BaseElement.GetTrcuckTractors()[0]);
            _carPark.AddTransport(BaseElement.GetSemitrailers()[0]);
            Assert.IsTrue(_carPark.Transports.Count() == 2);
        }

        /// <summary>
        /// Couplings the with specific cargo test.
        /// </summary>
        [TestMethod()]
        public virtual void CouplingWithSpecificCargoTest()
        {
            _carPark = new CarPark();
            var coupling = new Coupling(BaseElement.GetTrcuckTractors()[0], BaseElement.GetSemitrailers()[0]);
            var coupling1 = new Coupling(BaseElement.GetTrcuckTractors()[1], BaseElement.GetSemitrailers()[1]);
            var coupling2 = new Coupling(BaseElement.GetTrcuckTractors()[2], BaseElement.GetSemitrailers()[2]);
            _carPark.Couplings.Add(coupling);
            _carPark.Couplings.Add(coupling1);
            _carPark.Couplings.Add(coupling2);
            var logistician = new Logistician("", "", _carPark);
            logistician.AddCargo(coupling, BaseElement.GetCargo()[1]);
            logistician.AddCargo(coupling1, BaseElement.GetCargo()[2]);
            logistician.AddCargo(coupling2, BaseElement.GetCargo()[0]);
            Assert.IsTrue(_carPark.CouplingWithSpecificCargo(BaseElement.GetCargo()[1]).Count() == 1);
        }

        /// <summary>
        /// Couplingses the with free space test1.
        /// </summary>
        [TestMethod()]
        public virtual void CouplingsWithFreeSpaceTest1()
        {

            _carPark = new CarPark();
            var coupling = new Coupling(BaseElement.GetTrcuckTractors()[Random.Next(1, 3)], BaseElement.GetSemitrailers()[Random.Next(1, 3)]);
            var coupling1 = new Coupling(BaseElement.GetTrcuckTractors()[Random.Next(1, 3)], BaseElement.GetSemitrailers()[Random.Next(1, 3)]);
            var coupling2 = new Coupling(BaseElement.GetTrcuckTractors()[Random.Next(1, 3)], BaseElement.GetSemitrailers()[Random.Next(1, 3)]);
            _carPark.Couplings.Add(coupling);
            _carPark.Couplings.Add(coupling1);
            _carPark.Couplings.Add(coupling2);
            _carPark.CouplingsWithFreeSpace();
            Assert.IsTrue(_carPark.CouplingsWithFreeSpace().Count() == 3);
        }

        /// <summary>
        /// Creates the couplings test.
        /// </summary>
        [TestMethod()]
        public virtual void CreateCouplingsTest()
        {
            var coupling = new Coupling(BaseElement.GetTrcuckTractors()[Random.Next(1, 3)], BaseElement.GetSemitrailers()[Random.Next(1, 3)]);
            Assert.IsTrue(coupling != null);
        }

        /// <summary>
        /// Changes the truck tractor test.
        /// </summary>
        [TestMethod()]
        public void ChangeTruckTractorTest()
        {
            _carPark = new CarPark();
            var coupling = new Coupling(BaseElement.GetTrcuckTractors()[2], BaseElement.GetSemitrailers()[Random.Next(1, 3)]);
            _carPark.Couplings.Add(coupling);
            _carPark.ChangeTruckTractor(_carPark.Couplings[0], BaseElement.GetTrcuckTractors()[1]);
            var resultCouping = new Coupling(BaseElement.GetTrcuckTractors()[1], BaseElement.GetSemitrailers()[Random.Next(1, 3)]);

            Assert.AreEqual(_carPark.Couplings[0].ToString(), resultCouping.ToString());
        }
    }
}