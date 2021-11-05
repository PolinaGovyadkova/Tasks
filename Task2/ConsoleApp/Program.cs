using CargoProduct.BaseCargo;
using CargoProduct.Foods;
using CargoProduct.Fuels;
using System;
using Transport.BaseElements;
using Transport.Trailer;
using Transport.TruckTractors;
using TransportCompany;
using WorkWithFile.WorkWithFile;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var carPark = new CarPark();
            var ivecoSWay = new IvecoSWay();
            ivecoSWay.PayloadCapacity = 200;
            var mercedesBenzActros = new MercedesBenzActros();
            mercedesBenzActros.PayloadCapacity = 200;
            var refrigerated = new Refrigerated();
            var tilt = new Tanker();
            tilt.PayloadCapacity = 50;
            tilt.Volume = 50;

            refrigerated.PayloadCapacity = 100;
            refrigerated.Volume = 100;

            carPark.Semitrailers.Add(refrigerated);
            carPark.Semitrailers.Add(tilt);

            carPark.TruckTractors.Add(ivecoSWay);
            carPark.TruckTractors.Add(mercedesBenzActros);
            carPark.TruckTractors[0].AddTrailer(refrigerated);
            carPark.TruckTractors[1].AddTrailer(tilt);
            Cargo fuel = new Milk();
            fuel.PayloadCapacity = 10;
            fuel.Volume = 10;

            Cargo dt = new DT();
            dt.PayloadCapacity = 10;
            dt.Volume = 10;

            var logistician = new Logistician("", "", carPark);
            //carPark.Semitrailers[0].ProductAdd(fuel);
            var coupling = new Coupling(ivecoSWay, refrigerated);
            var coupling1 = new Coupling(mercedesBenzActros, tilt);
            carPark.Couplings.Add(coupling);
            carPark.Couplings.Add(coupling1);
            //carPark.TruckTractors[0].Semitrailer.Cargo = fuel;
            logistician.AddCargo(coupling, fuel);
            logistician.AddCargo(coupling1, dt);
            carPark.AddTransport(ivecoSWay);
            carPark.AddTransport(mercedesBenzActros);
            carPark.AddTransport(refrigerated);
            carPark.AddTransport(tilt);
            var carParkXmlReader = new CarParkXmlReader();
            carParkXmlReader.WriteToXmlFile(carPark, "CarParkXmlReader.xml");
            var carParkStreamReader = new CarParkStreamReader();
            carParkStreamReader.WriteToXmlFile(carPark, "CarParkStreamReader.xml");

            Console.WriteLine(carPark.TruckTractors[0] + " " + carPark.TruckTractors[0].Semitrailer + " " +
                              carPark.TruckTractors[0].Semitrailer.Cargo);
            Console.WriteLine(carPark.TruckTractors[1] + " " + carPark.TruckTractors[1].Semitrailer + " " +
                              carPark.TruckTractors[1].Semitrailer.Cargo);
            Console.ReadKey();
        }
    }
}