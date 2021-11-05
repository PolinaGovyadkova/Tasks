using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CargoProduct.BaseCargo;
using CargoProduct.Foods;
using CargoProduct.Fuels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transport.BaseElements;
using Transport.Trailer;
using Transport.TruckTractors;
using TransportCompany;
using WorkWithFile.WorkWithFile;

namespace XMLFileTests.WorkWithFile
{
    /// <summary>
    /// BaseFileCreator
    /// </summary>
    public class BaseFileCreator
    {
        /// <summary>
        /// Files the creator.
        /// </summary>
        /// <param name="fieName">Name of the fie.</param>
        /// <param name="key">The key.</param>
        public static void FileCreator(string fieName, string key)
        {
            if (File.Exists(fieName)) File.Delete(fieName);
            var carPark = new CarPark();
            var ivecoSWay = new IvecoSWay();
            ivecoSWay.PayloadCapacity = 200;
            var refrigerated = new Refrigerated();

            refrigerated.PayloadCapacity = 100;
            refrigerated.Volume = 100;

            carPark.Semitrailers.Add(refrigerated);

            carPark.TruckTractors.Add(ivecoSWay);
            carPark.TruckTractors[0].AddTrailer(refrigerated);
            Cargo fuel = new Milk();
            fuel.PayloadCapacity = 10;
            fuel.Volume = 10;

            Cargo dt = new DT();
            dt.PayloadCapacity = 10;
            dt.Volume = 10;

            var logistician = new Logistician("", "", carPark);
            var coupling = new Coupling(ivecoSWay, refrigerated);
            carPark.Couplings.Add(coupling);
            logistician.AddCargo(coupling, fuel);
            carPark.AddTransport(ivecoSWay);
            switch (key)
            {
                case "StreamReader":
                {
                    var carParkStreamReader = new CarParkStreamReader();
                    carParkStreamReader.WriteToXmlFile(carPark, fieName);
                }
                    break;
                case "XmlReader":
                {
                    var carParkXmlReader = new CarParkXmlReader();
                    carParkXmlReader.WriteToXmlFile(carPark, fieName);
                } 
                    break;
                    
            }
            
        }

        /// <summary>
        /// Files the write tester.
        /// </summary>
        /// <param name="kyName">Name of the ky.</param>
        /// <param name="fileName">Name of the file.</param>
        public static void FileWriteTester(string kyName, string fileName)
        {
            FileCreator(fileName, kyName);
            var doc = new XmlDocument();
            doc.Load("CarParkXmlReaderTests.xml");
            var elemCarPark = doc.GetElementsByTagName("CarPark");
            var elemTruck = doc.GetElementsByTagName("TruckTractor");
            var elemSemiTrailer = doc.GetElementsByTagName("Semitrailer");
            var elemProduct = doc.GetElementsByTagName("Cargo");

            Assert.IsTrue(Counter(elemCarPark) != 0);
            Assert.IsTrue(Counter(elemTruck) != 0);
            Assert.IsTrue(Counter(elemSemiTrailer) != 0);
            Assert.IsTrue(Counter(elemProduct) != 0);
        }
        /// <summary>
        /// Counters the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static int Counter(XmlNodeList element)
        {
            var count = 0;
            for (var i = 0; i < element.Count; i++)
            {
                count++;
            }

            return count;
        }
    }
}
