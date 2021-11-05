using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoProduct.Chemicals;

namespace WorkWithFile.Factories.CargoFactories
{
    /// <summary>
    /// OAlkylFactory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="WorkWithFile.AbstractFactory&lt;CargoProduct.Chemicals.OAlkyl&gt;" />
    public class OAlkylFactory<T> : AbstractFactory<OAlkyl>
    {
        /// <summary>
        /// Create the element.
        /// </summary>
        /// <returns></returns>
        public override OAlkyl CreateElement() => new OAlkyl();
    }
}
