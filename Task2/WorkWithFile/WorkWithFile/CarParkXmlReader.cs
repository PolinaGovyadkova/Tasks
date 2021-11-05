using System;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using CargoProduct;
using CargoProduct.Interfaces;
using Transport.Intefaces;
using TransportCompany;
using WorkWithFile.Interfaces;

namespace WorkWithFile.WorkWithFile
{
    /// <summary>
    /// CarParkXmlReader
    /// </summary>
    /// <seealso cref="WorkWithFile.ICarParkXml" />
    public class CarParkXmlReader : ICarParkXml
    {
        /// <summary>
        /// The settings
        /// </summary>
        private XmlReaderSettings _settings;

        /// <summary>
        /// The root element
        /// </summary>
        private XmlElement _xRoot;
        /// <summary>
        /// Reads from XML file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        private void ReadFromXmlFile(string filePath)
        {
            var xDoc = new XmlDocument();
            var xr = XmlReader.Create(filePath, _settings);
            xDoc.Load(xr);
            _xRoot = xDoc.DocumentElement;
        }

        /// <summary>
        /// Parser the specified file path XML.
        /// </summary>
        /// <param name="filePathXml">The file path XML.</param>
        /// <param name="mainContainer">The main container.</param>
        /// <returns></returns>
        public ICarPark Parser(string filePathXml, IBaseRepository mainContainer)
        {
            ReadFromXmlFile(filePathXml);

            ICarPark carPark = null;

            foreach (XmlElement node in _xRoot.ChildNodes)
            {
                if (node.Name == "CarPark")
                    carPark = mainContainer.GetFactory<ICarPark>(node.Name)["CarPark"].CreateElement();

                foreach (XmlElement element in node.ChildNodes)
                {
                    var listElement = element.ChildNodes;

                    switch (element.Name)
                    {
                        case "TruckTractor":
                            var truck = mainContainer.GetFactory<ITurkTractor>(element.Name)[listElement[0].InnerText].CreateElement();
                            SubNode(truck, (XmlElement)listElement[1], mainContainer);
                            carPark?.AddTransport(truck);
                            break;

                        case "Semitrailer":
                            var semiTrailer = mainContainer.GetFactory<ISemitrailer>(element.Name)[listElement[0].InnerText].CreateElement();
                            SubNode(semiTrailer, (XmlElement)listElement[1], mainContainer);
                            carPark?.AddTransport(semiTrailer);
                            break;
                    }
                }
            }

            return carPark;
        }

        /// <summary>
        /// Sub-node.
        /// </summary>
        /// <param name="transport">The transport.</param>
        /// <param name="element">The element.</param>
        /// <param name="mainContainer">The main container.</param>
        private static void SubNode(ITransport transport, XmlElement element, IBaseRepository mainContainer)
        {
            if (element is null) return;
            var listElement = element.ChildNodes;

            switch (element.Name)
            {
                case "Semitrailer":
                    var semiTrailer = mainContainer.GetFactory<ISemitrailer>(element.Name)[listElement[0].InnerText].CreateElement();
                    SubNode(semiTrailer, (XmlElement)listElement[1], mainContainer);
                    (transport as ITurkTractor)?.AddTrailer(semiTrailer);
                    break;

                case "Cargo":
                    var product = mainContainer.GetFactory<ICargo>(element.Name)[listElement[0].InnerText].CreateElement();
                    product.PayloadCapacity = float.Parse(listElement[1].InnerText);
                    product.Volume = float.Parse(listElement[2].InnerText);
                    (transport as ISemitrailer)?.ProductAdd(product);
                    break;
            }
        }

        /// <summary>
        /// Write to XML file.
        /// </summary>
        /// <param name="carPark">The car park.</param>
        /// <param name="filePath">The file path.</param>
        public void WriteToXmlFile(ICarPark carPark, string filePath)
        {
            var settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "     ",
                NewLineOnAttributes = false,
                OmitXmlDeclaration = true
            };

            using (var xw = XmlWriter.Create(filePath, settings))
            {
                xw.WriteStartDocument();
                xw.WriteStartElement("TransportCompany");

                xw.WriteStartElement("CarPark");

                foreach (var element in carPark)
                {
                    switch (element)
                    {
                        case ITurkTractor tractor:
                            SerializerTruck(xw, tractor);
                            break;

                        case ISemitrailer semitrailer:
                            SerializerSemiTrailer(xw, semitrailer);
                            break;
                    }
                }

                xw.WriteEndElement();
                xw.WriteEndElement();
                xw.WriteEndDocument();
                xw.Flush();
            }
        }

        /// <summary>
        /// Serializers the truck.
        /// </summary>
        /// <param name="xw">The xw.</param>
        /// <param name="truck">The truck.</param>
        private void SerializerTruck(XmlWriter xw, ITurkTractor truck)
        {
            xw.WriteStartElement("TruckTractor");
            xw.WriteElementString("Name", GetNameClass(truck));
            if (truck.Semitrailer != null)
                SerializerSemiTrailer(xw, truck.Semitrailer);

            xw.WriteEndElement();
        }

        /// <summary>
        /// Serializers the semitrailer.
        /// </summary>
        /// <param name="xw">The xw.</param>
        /// <param name="semitrailer">The semitrailer.</param>
        private void SerializerSemiTrailer(XmlWriter xw, ISemitrailer semitrailer)
        {
            xw.WriteStartElement("Semitrailer");
            xw.WriteElementString("Name", GetNameClass(semitrailer));
            if (semitrailer.PayloadCapacity > 0 && semitrailer.Volume > 0)
                SerializerProduct(xw, semitrailer.TypeProduct, semitrailer.PayloadCapacity, semitrailer.Volume);

            xw.WriteEndElement();
        }

        /// <summary>
        /// Serializers the product.
        /// </summary>
        /// <param name="xw">The xw.</param>
        /// <param name="type">The type.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="volume">The volume.</param>
        private void SerializerProduct(XmlWriter xw, Type type, double weight, double volume)
        {
            xw.WriteStartElement("Cargo");
            xw.WriteElementString("Name", type.Name);
            xw.WriteElementString("Weight", weight.ToString(CultureInfo.InvariantCulture));
            xw.WriteElementString("Volume", volume.ToString(CultureInfo.InvariantCulture));
            xw.WriteEndElement();
        }

        /// <summary>
        /// Gets the name class.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        private static string GetNameClass(object obj)
        {
            var text = obj.GetType().ToString();
            var separatedText = text.Split('.');
            return separatedText[separatedText.Length - 1];
        }
    }
}