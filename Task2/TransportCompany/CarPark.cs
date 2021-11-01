using System;
using System.Collections.Generic;
using System.Linq;
using CargoProduct;
using CargoProduct.Foods;
using CargoProduct.Fuels;
using Transport;
using Transport.Trailer;
using Transport.TruckTractors;

namespace TransportCompany
{
    public class CarPark
    {
        public List<Semitrailer> Semitrailers { get; set; } = new List<Semitrailer>();
        public List<Coupling> Couplings { get; } = new List<Coupling>();

        public List<Coupling> CouplingWithSpecificCargo(Cargo cargo)
        {
            return Couplings.Where(rt => Equals(rt.Semitrailer.Cargo, cargo)).ToList();
        }

        public List<Coupling> CouplingsWithFreeSpace()
        {
            return Couplings.Where(element =>
                element.Semitrailer.FreeWeight > 0 && element.Semitrailer.FreeWeight > 0).ToList();
        }

        public void CreateCouplings(Semitrailer semitrailer, TruckTractor truckTractor)
        {
            var flag = false;
            foreach (var element in Couplings.Where(element =>
                ReferenceEquals(element.Semitrailer, semitrailer) ||
                ReferenceEquals(element.TruckTractor, truckTractor))) flag = true;
            if (truckTractor.PayloadCapacity >= semitrailer.TotalWeight && flag)
                Couplings.Add(new Coupling(truckTractor, semitrailer));
            else throw new Exception("Тягач/прицеп уже заняты");
        }

        public void AddCargo(Coupling coupling, Cargo cargo)
        {
            foreach (var element in Couplings.Where(element => ReferenceEquals(element, coupling)))
                if (coupling.Semitrailer.Cargo is null)
                {
                    switch (coupling.Semitrailer)
                    {
                        case Tanker _ when cargo is Fuel:
                        case Refrigerated _ when cargo is ITemperature:
                            coupling.Semitrailer.Cargo = cargo;
                            break;

                        default:
                            coupling.Semitrailer.Cargo = cargo;
                            break;
                    }
                }
                else
                {
                    if (!Equals(coupling.Semitrailer.Cargo, cargo)) throw new Exception("Не совпадают типы грузов");
                    if (coupling.Semitrailer.FreeVolume >= cargo.Volume &&
                        coupling.Semitrailer.FreeWeight >= cargo.PayloadCapacity)
                    {
                        if (coupling.Semitrailer.Cargo is ITemperature currentCargo && cargo is ITemperature newCargo)
                        {
                            var flag = true;
                            foreach (var elementCargo in currentCargo.Temperature)
                                for (var index = 0; index < newCargo.Temperature.Count && flag; index++)
                                {
                                    if (elementCargo != newCargo.Temperature[index]) continue;
                                    coupling.Semitrailer.Cargo.PayloadCapacity += cargo.PayloadCapacity;
                                    coupling.Semitrailer.Cargo.Volume += cargo.Volume;
                                    flag = false;
                                }
                        }
                        else
                        {
                            coupling.Semitrailer.Cargo.PayloadCapacity += cargo.PayloadCapacity;
                            coupling.Semitrailer.Cargo.Volume += cargo.Volume;
                        }
                    }
                    else
                    {
                        throw new Exception("Груз не может быть догружен из-за массы/объёма");
                    }
                }
        }

        public void ChangeTruckTractor(Coupling coupling, TruckTractor truckTractor)
        {
            if (Couplings.Any(element => ReferenceEquals(element.TruckTractor, truckTractor)))
                throw new Exception("Тягач нельзя добавить");
            for (var i = 0; i < Couplings.Count; i++)
                if (ReferenceEquals(Couplings[i], coupling))
                    Couplings[i] = new Coupling(truckTractor, Couplings[i].Semitrailer);
        }

        public void RemoveAllCargo(Coupling coupling)
        {
            coupling.Semitrailer.Cargo = null;
        }

        public void RemovePartCargo(Coupling coupling, double weight, double volume)
        {
            coupling.Semitrailer.Cargo.PayloadCapacity -= weight;
            coupling.Semitrailer.Cargo.Volume -= volume;
        }

        public List<T> FindSemitrailerByCharacteristics<T>(double payload, double volume)
            where T : Semitrailer
        {
            var transports = FindSemitrailerByType<T>();
            return transports.FindAll(element => element.PayloadCapacity == payload && element.Volume == volume);
        }

        public List<T> FindSemitrailerByType<T>()
            where T : Semitrailer
        {
            var transports = new List<T>();
            foreach (var element in transports)
                if (element is T trailer)
                    transports.Add(trailer);
            return transports;
        }
    }
}