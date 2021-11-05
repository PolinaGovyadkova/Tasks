using System;
using System.IO;
using System.Xml;
using CargoProduct.BaseCargo;
using CargoProduct.Foods;
using CargoProduct.Fuels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transport.BaseElements;
using Transport.Trailer;
using Transport.TruckTractors;
using TransportCompany;
using WorkWithFile;
using WorkWithFile.WorkWithFile;

namespace XMLFileTests.WorkWithFile
{
    /// <summary>
    /// CarParkXmlReaderTests
    /// </summary>
    [TestClass()]
    public class CarParkXmlReaderTests 
    {
        /// <summary>
        /// Parsers the test.
        /// </summary>
        [TestMethod()]
        public void ParserTest()
        {
            BaseFileCreator.FileWriteTester("XmlReader", "CarParkXmlReaderTests.xml");
            var carParkXmlReader = new CarParkXmlReader();
            var baseRepository = new BaseRepository();
            var carPark = carParkXmlReader.Parser("CarParkXmlReaderTests.xml", baseRepository);
            Assert.AreEqual(carPark, 1);
        }

        /// <summary>
        /// Writes to XML file test.
        /// </summary>
        [TestMethod()]
        public  void WriteToXmlFileTest()
        {
            BaseFileCreator.FileWriteTester("XmlReader", "CarParkXmlReaderTests.xml");
        }

        
    }
}