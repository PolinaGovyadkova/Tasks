using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transport.Trailer;
using TransportCompany;

namespace TransportCompanyTests
{
    /// <summary>
    /// TransportSearchEngineTests
    /// </summary>
    [TestClass()]
    public class TransportSearchEngineTests
    {
        /// <summary>
        /// The transport search engine
        /// </summary>
        private TransportSearchEngine _transportSearchEngine;


        /// <summary>
        /// Finds the semitrailer by type test.
        /// </summary>
        [TestMethod()]
        public void FindSemitrailerByTypeTest()
        {
            _transportSearchEngine = new TransportSearchEngine();
            Assert.IsNotNull(_transportSearchEngine.FindSemitrailerByType<Refrigerated>());
            Assert.IsNotNull(_transportSearchEngine.FindSemitrailerByType<Container>());
            Assert.IsNotNull(_transportSearchEngine.FindSemitrailerByType<Tilt>());
            Assert.IsNotNull(_transportSearchEngine.FindSemitrailerByType<Tanker>());
        }

        /// <summary>
        /// Finds the semitrailer by characteristics test.
        /// </summary>
        [TestMethod()]
        public void FindSemitrailerByCharacteristicsTest()
        {
            _transportSearchEngine = new TransportSearchEngine();
            Assert.IsNotNull(_transportSearchEngine.FindSemitrailerByCharacteristics<Refrigerated>(10,10));

        }
    }
}