using CargoProduct.BaseCargo;
using CargoProduct.Clothes;
using CargoProduct.Foods;
using CargoProduct.Fuels;
using System;
using System.Collections.Generic;
using Transport.BaseElements;
using Transport.Trailer;
using Transport.TruckTractors;
using TransportCompany;

namespace TransportCompanyTests
{
    /// <summary>
    /// BaseElement
    /// </summary>
    public class BaseElement
    {
        /// <summary>
        /// Gets the semitrailers.
        /// </summary>
        /// <returns></returns>
        public static List<Semitrailer> GetSemitrailers()
        {
            var refrigerated = new Refrigerated();
            refrigerated.PayloadCapacity = 100;
            refrigerated.Volume = 100;
            var tilt = new Tilt();
            tilt.PayloadCapacity = 200;
            tilt.Volume = 50;
            var tanker = new Tanker();
            tanker.PayloadCapacity = 200;
            tanker.Volume = 200;
            var semitrailers = new List<Semitrailer>()
            {
                refrigerated, tilt, tanker
            };
            return semitrailers;
        }

        /// <summary>
        /// Gets the trcuck tractors.
        /// </summary>
        /// <returns></returns>
        public static List<TruckTractor> GetTrcuckTractors()
        {
            var ivecoSWay = new IvecoSWay();
            ivecoSWay.PayloadCapacity = 200;
            var mercedesBenzActros = new MercedesBenzActros();
            mercedesBenzActros.PayloadCapacity = 200;
            var volvoFhiSave = new VolvoFHISave();
            volvoFhiSave.PayloadCapacity = 100;
            var truckTractors = new List<TruckTractor>()
            {
                ivecoSWay,mercedesBenzActros,volvoFhiSave
            };
            return truckTractors;
        }

        /// <summary>
        /// Gets the couplings.
        /// </summary>
        /// <returns></returns>
        public static List<Coupling> GetCouplings()
        {
            Random random = new Random();
            var coupling = new Coupling(GetTrcuckTractors()[random.Next(1, 3)], GetSemitrailers()[random.Next(1, 3)]);
            var coupling1 = new Coupling(GetTrcuckTractors()[random.Next(1, 3)], GetSemitrailers()[random.Next(1, 3)]);
            var coupling2 = new Coupling(GetTrcuckTractors()[random.Next(1, 3)], GetSemitrailers()[random.Next(1, 3)]);
            var couplings = new List<Coupling>()
            {
                coupling,coupling1,coupling2
            };
            return couplings;
        }

        /// <summary>
        /// Gets the cargo.
        /// </summary>
        /// <returns></returns>
        public static List<Cargo> GetCargo()
        {
            Cargo milk = new Milk();
            milk.PayloadCapacity = 10;
            milk.Volume = 10;

            Cargo dt = new DT();
            dt.PayloadCapacity = 10;
            dt.Volume = 10;

            Cargo shooes = new Shooes();
            shooes.PayloadCapacity = 30;
            shooes.Volume = 10;

            var cargo = new List<Cargo>()
            {
                dt,milk,shooes
            };
            return cargo;
        }
    }
}