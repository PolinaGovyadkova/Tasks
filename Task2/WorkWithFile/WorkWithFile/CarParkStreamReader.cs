using CargoProduct.Interfaces;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using Transport.Intefaces;
using TransportCompany;
using WorkWithFile.Interfaces;

namespace WorkWithFile.WorkWithFile
{
    /// <summary>
    /// CarParkStreamReader
    /// </summary>
    /// <seealso cref="WorkWithFile.ICarParkXml" />
    public class CarParkStreamReader : ICarParkXml
    {
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
            var xmlDocument = new XmlDocument();
            var xr = new StreamReader(filePath);
            xmlDocument.Load(xr);
            _xRoot = xmlDocument.DocumentElement;
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
        /// Sub-noDe.
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
            var xmlDocument = new XmlDocument();
            ConfigureFile(xmlDocument, filePath);
            var tabulation = new StringBuilder();
            tabulation.Append("\n");
            var padding = 1;
            StartElement(GetNameClass(carPark), ref padding, tabulation);

            foreach (var element in carPark)
            {
                switch (element)
                {
                    case ITurkTractor tractor:
                        SerializerTruck(tabulation, tractor, ref padding);
                        break;

                    case ISemitrailer semitrailer:
                        SerializerSemiTrailer(tabulation, semitrailer, ref padding);
                        break;
                }
            }

            EndElement(GetNameClass(carPark), ref padding, tabulation);

            var fragment = xmlDocument.CreateDocumentFragment();
            fragment.InnerXml = tabulation.ToString();
            xmlDocument.LastChild.AppendChild(fragment);
            Save(xmlDocument, filePath);
        }

        /// <summary>
        /// Save the specified XML document.
        /// </summary>
        /// <param name="xmlDocument">The XML document.</param>
        /// <param name="filePath">The file path.</param>
        private static void Save(XmlDocument xmlDocument, string filePath)
        {
            using (var xw = new StreamWriter(filePath)) xmlDocument.Save(xw);
        }

        /// <summary>
        /// Start the element.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="padding">The padding.</param>
        /// <param name="tabulation">The tabulation.</param>
        private static void StartElement(string text, ref int padding, StringBuilder tabulation)
        {
            tabulation.Append(new string('\t', padding) + "<" + text + ">\n");
            padding += 1;
        }

        /// <summary>
        /// End the element.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="padding">The padding.</param>
        /// <param name="tabulation">The tabulation.</param>
        private static void EndElement(string text, ref int padding, StringBuilder tabulation)
        {
            padding -= 1;
            tabulation.Append(new string('\t', padding) + "</" + text + ">\n");
        }

        /// <summary>
        /// Write the element string.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="text">The text.</param>
        /// <param name="padding">The padding.</param>
        /// <param name="tabulation">The tabulation.</param>
        private static void WriteElementString(string tag, string text, ref int padding, StringBuilder tabulation) => tabulation.Append(new string('\t', padding) + "<" + tag + ">" + text + "</" + tag + ">\n");

        /// <summary>
        /// Serializer the truck.
        /// </summary>
        /// <param name="tabulation">The tabulation.</param>
        /// <param name="truck">The truck.</param>
        /// <param name="padding">The padding.</param>
        private void SerializerTruck(StringBuilder tabulation, ITurkTractor truck, ref int padding)
        {
            StartElement("TruckTractor", ref padding, tabulation);

            WriteElementString("Name", GetNameClass(truck), ref padding, tabulation);
            if (truck.Semitrailer != null)
                SerializerSemiTrailer(tabulation, truck.Semitrailer, ref padding);

            EndElement("TruckTractor", ref padding, tabulation);
        }

        /// <summary>
        /// Serializers the semi trailer.
        /// </summary>
        /// <param name="tabulation">The tabulation.</param>
        /// <param name="semitrailer">The semitrailer.</param>
        /// <param name="padding">The padding.</param>
        private void SerializerSemiTrailer(StringBuilder tabulation, ISemitrailer semitrailer, ref int padding)
        {
            StartElement("Semitrailer", ref padding, tabulation);
            WriteElementString("Name", GetNameClass(semitrailer), ref padding, tabulation);
            if (semitrailer.PayloadCapacity > 0 && semitrailer.Volume > 0)
                SerializerProduct(tabulation, semitrailer.TypeProduct, semitrailer.PayloadCapacity, semitrailer.Volume, ref padding);
            EndElement("Semitrailer", ref padding, tabulation);
        }

        /// <summary>
        /// Serializers the product.
        /// </summary>
        /// <param name="tabulation">The tabulation.</param>
        /// <param name="type">The type.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="volume">The volume.</param>
        /// <param name="padding">The padding.</param>
        private void SerializerProduct(StringBuilder tabulation, Type type, double weight, double volume, ref int padding)
        {
            StartElement("Cargo", ref padding, tabulation);
            WriteElementString("Name", GetNameClass(type), ref padding, tabulation);
            WriteElementString("Weight", weight.ToString(CultureInfo.InvariantCulture), ref padding, tabulation);
            WriteElementString("Volume", volume.ToString(CultureInfo.InvariantCulture), ref padding, tabulation);
            EndElement("Cargo", ref padding, tabulation);
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

        /// <summary>
        /// Gets the name class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        private static string GetNameClass(Type type)
        {
            var text = type.ToString();
            var separatedText = text.Split('.');
            return separatedText[separatedText.Length - 1];
        }

        /// <summary>
        /// Configures the file.
        /// </summary>
        /// <param name="xmlDocument">The XML document.</param>
        /// <param name="filePath">The file path.</param>
        private void ConfigureFile(XmlDocument xmlDocument, string filePath)
        {
            if (File.Exists(filePath) == false)
            {
                var declaration = xmlDocument.CreateXmlDeclaration("1.0", null, null);
                var mainList = xmlDocument.CreateElement($"TransportCompanys");
                xmlDocument.AppendChild(declaration);
                xmlDocument.AppendChild(mainList);
                Save(xmlDocument, filePath);
            }
            else
            {
                xmlDocument.Load(filePath);
            }
        }
    }
}