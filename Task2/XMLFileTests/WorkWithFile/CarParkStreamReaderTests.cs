using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransportCompany;
using WorkWithFile;
using WorkWithFile.Interfaces;
using WorkWithFile.WorkWithFile;

namespace XMLFileTests.WorkWithFile
{
    /// <summary>
    /// CarParkStreamReaderTests
    /// </summary>
    [TestClass()]
    public class CarParkStreamReaderTests 
    {
        /// <summary>
        /// Writes to XML file test.
        /// </summary>
        [TestMethod()]
        public void WriteToXmlFileTest()
        {
            BaseFileCreator.FileWriteTester("StreamReader", "CarParkStreamReaderTests.xml");
        }

        /// <summary>
        /// Parsers the test.
        /// </summary>
        [TestMethod()]
        public void ParserTest()
        {
            BaseFileCreator.FileWriteTester("StreamReader", "CarParkStreamReaderTests.xml");
            var carParkXmlReader = new CarParkStreamReader();
            var baseRepository = new BaseRepository();
            var carPark = carParkXmlReader.Parser("CarParkStreamReaderTests.xml", baseRepository);
            Assert.AreEqual(carPark, 1);
        }
    }
}