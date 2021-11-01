using CargoProduct;
using CargoProduct.Foods;
using CargoProduct.Fuels;
using System;
using Transport;
using Transport.Trailer;
using Transport.TruckTractors;
using TransportCompany;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Random rnd = new Random();
            CarPark carPark = new CarPark();
            Console.WriteLine("SAMITRAILERS Number");
            while (Convert.ToInt32(Console.ReadLine()) != 4)
            {
                Console.WriteLine("1-t, 2-r, 3-a");
                switch (rnd.Next(1, 4))
                {
                    case 1:
                        {
                            Semitrailer refrigerated = new Refrigerated(rnd.Next(1, 10), rnd.Next(1, 10));
                            carPark.Semitrailers.Add(refrigerated);
                        }
                        break;

                    case 2:
                        {
                            Semitrailer refrigerated = new Tanker(rnd.Next(1, 10), rnd.Next(1, 10));
                            carPark.Semitrailers.Add(refrigerated);
                        }
                        break;

                    case 3:
                        {
                            Semitrailer refrigerated = new Tilt(rnd.Next(1, 10), rnd.Next(1, 10));
                            carPark.Semitrailers.Add(refrigerated);
                        }
                        break;
                }
            }
            foreach (var item in carPark.Semitrailers)
                Console.WriteLine(item);

            Console.WriteLine("TRANSPORT Count");
            while (Convert.ToInt32(Console.ReadLine()) != 4)
            {
                Console.WriteLine("1-IvecoSWay, 2-MercedesBenzActros, 3-VolvoFHISave");
                switch (rnd.Next(1, 4))
                {
                    case 1:
                        {
                            TruckTractor refrigerated = new IvecoSWay(rnd.Next(1, 20));
                            carPark.Couplings.Add(new Coupling(refrigerated, carPark.Semitrailers[new Random().Next(1, carPark.Semitrailers.Count)]));
                            //carPark.CreateCouplings((carPark.Semitrailers[new Random().Next(1, carPark.Semitrailers.Count)]), refrigerated);
                        }
                        break;

                    case 2:
                        {
                            TruckTractor refrigerated = new MercedesBenzActros(rnd.Next(1, 20));
                            carPark.Couplings.Add(new Coupling(refrigerated, carPark.Semitrailers[new Random().Next(1, carPark.Semitrailers.Count)]));
                            //carPark.CreateCouplings((carPark.Semitrailers[new Random().Next(1, carPark.Semitrailers.Count)]), refrigerated);
                        }
                        break;

                    case 3:
                        {
                            TruckTractor refrigerated = new VolvoFHISave(rnd.Next(1, 20));
                            carPark.Couplings.Add(new Coupling(refrigerated, carPark.Semitrailers[new Random().Next(1, carPark.Semitrailers.Count)]));
                            //carPark.CreateCouplings((carPark.Semitrailers[new Random().Next(1, carPark.Semitrailers.Count)]), refrigerated);
                        }
                        break;
                }
            }

            foreach (var item in carPark.Couplings)
                Console.WriteLine(item);

            Console.WriteLine("CARGO Count");
            while (Convert.ToInt32(Console.ReadLine()) != 4)
            {
                Console.WriteLine("1-Fuel, 2-Food, 3-Chemicals");
                switch (rnd.Next(1, 4))
                {
                    case 1:
                        {
                            switch (rnd.Next(1, 4))
                            {
                                case 1:
                                    Cargo cargo = new AI92(rnd.Next(1, 3), rnd.Next(1, 3));
                                    carPark.AddCargo(carPark.Couplings[new Random().Next(1, carPark.Semitrailers.Count)], cargo);
                                    break;

                                case 2:
                                    Cargo cargo1 = new AI95(rnd.Next(1, 3), rnd.Next(1, 3));
                                    carPark.AddCargo(carPark.Couplings[new Random().Next(1, carPark.Semitrailers.Count)], cargo1);
                                    break;

                                case 3:
                                    Cargo cargo2 = new DT(rnd.Next(1, 3), rnd.Next(1, 3));
                                    carPark.AddCargo(carPark.Couplings[new Random().Next(1, carPark.Semitrailers.Count)], cargo2);
                                    break;
                            }
                        }
                        break;

                    case 2:
                        {
                            switch (rnd.Next(1, 2))
                            {
                                case 1:
                                    Cargo cargo = new Fish(rnd.Next(1, 3), rnd.Next(1, 3));
                                    carPark.AddCargo(carPark.Couplings[new Random().Next(1, carPark.Semitrailers.Count)], cargo);
                                    break;

                                case 2:
                                    Cargo cargo1 = new Milk(rnd.Next(1, 3), rnd.Next(1, 3));
                                    carPark.AddCargo(carPark.Couplings[new Random().Next(1, carPark.Semitrailers.Count)], cargo1);
                                    break;
                            }
                        }
                        break;

                    case 3:
                        {
                            Cargo cargo = new Shooes(rnd.Next(1, 3), rnd.Next(1, 3));
                            carPark.AddCargo(carPark.Couplings[new Random().Next(1, carPark.Semitrailers.Count)], cargo);
                        }
                        break;
                }
            }
            carPark.CreateCouplings((carPark.Semitrailers[new Random().Next(1, carPark.Semitrailers.Count)]), new VolvoFHISave(rnd.Next(15, 20)));
            carPark.RemoveAllCargo(carPark.Couplings[new Random().Next(1, carPark.Semitrailers.Count)]);
            carPark.RemovePartCargo(carPark.Couplings[new Random().Next(1, carPark.Semitrailers.Count)], 10, 10);
            foreach (var item in carPark.CouplingsWithFreeSpace())
                Console.WriteLine(item);
            foreach (var item in carPark.FindSemitrailerByCharacteristics<Semitrailer>(10, 10))
                Console.WriteLine(item);
            foreach (var item in carPark.FindSemitrailerByType<Refrigerated>())
                Console.WriteLine(item);
            Console.ReadKey();
        }
    }
}