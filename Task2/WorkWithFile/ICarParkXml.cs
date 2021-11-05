using TransportCompany;
using WorkWithFile.Interfaces;

namespace WorkWithFile
{
    /// <summary>
    /// ICarParkXml
    /// </summary>
    public interface ICarParkXml
    {
        /// <summary>
        /// Parser the specified file path XML.
        /// </summary>
        /// <param name="filePathXml">The file path XML.</param>
        /// <param name="baseRepository">The base repository.</param>
        /// <returns></returns>
        ICarPark Parser(string filePathXml, IBaseRepository baseRepository);

        /// <summary>
        /// Write to XML file.
        /// </summary>
        /// <param name="carPark">The car park.</param>
        /// <param name="filePath">The file path.</param>
        void WriteToXmlFile(ICarPark carPark, string filePath);
    }
}