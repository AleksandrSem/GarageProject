using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingProject
{
    class Parking
    {
        static private List<ParkoPlace> AllParkingPlaces = new List<ParkoPlace>();

        static Parking()
        {
            for (int i = 0; i < 20; i++)
            {
                ParkoPlace parkoMesto = new ParkoPlace();
                Parking.AllParkingPlaces.Add(parkoMesto);
            }
        }

        static public void CreateCarsPull()
        {
            for (int i = 0; i < 8; i++)
            {
                Vehicle customVehicle = new Vehicle();
                Parking.CarParkedInParking(customVehicle);
            }
        }

        static public bool CarParkedInParking(Vehicle vehicle)
        {
            var isCarParked = false;
            if (vehicle.GetCarAccess() == false)
            {
                Console.WriteLine("{0} hasn't access to Parking", vehicle.GetCarName());
                return isCarParked;
            }

            var isFreePlacePresent = Parking.AllParkingPlaces.Exists(i => i.GetStatusOfPlace() == true);
            if (isFreePlacePresent == false)
            {
                Console.WriteLine("No free places in Parking");
                return isCarParked;
            }

            var firstEmptyParkoPlace = Parking.AllParkingPlaces.FirstOrDefault(i => i.GetCarInPlace() == null);
            var indexOfParkoPlaceWithoutCar = Parking.AllParkingPlaces.IndexOf(firstEmptyParkoPlace);
            Parking.AllParkingPlaces[indexOfParkoPlaceWithoutCar].TakeParkoPlace(vehicle);
            Console.WriteLine("{0} is parked in Parking.", vehicle.GetCarName());
            isCarParked = true;

            return isCarParked;
        }

        static public void GetQuantityFreePlacesInParking()
        {
            int numberOfCars = Parking.AllParkingPlaces.Count(i => i.GetCarInPlace() == null);
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"There are {numberOfCars} free places in Parking");
            Console.WriteLine(new string('-', 40));
        }

        static public void GetCarsInfoInParking()
        {
            for (int i = 0; i < Parking.AllParkingPlaces.Count(); i++)
            {
                if (Parking.AllParkingPlaces[i].GetCarInPlace() != null)
                {
                    Console.WriteLine(Parking.AllParkingPlaces[i].GetCarInPlace().GetCarName() + 
                        " " + Parking.AllParkingPlaces[i].GetCarInPlace().GetCarNumber());
                }
            }
            Console.WriteLine(new string('-', 40));
        }

        static public bool CarRemovedFromParking(string carNumber)
        {
            var isCarRemoved = false;

            var isCarExists = Parking.AllParkingPlaces.Exists(i => i.GetStatusOfPlace() == false 
            && i.GetCarInPlace().GetCarNumber() == carNumber);

            if (isCarExists == false)
            {
                Console.WriteLine("Car with such number NOT present in Parking");
                return isCarRemoved;
            }

            var parkoPlaceWithCar = Parking.AllParkingPlaces.Find(i => i.GetCarInPlace().GetCarNumber() == carNumber);
            var indexOfParkoPlaceWithCar = Parking.AllParkingPlaces.IndexOf(parkoPlaceWithCar);
            Parking.AllParkingPlaces[indexOfParkoPlaceWithCar].UntakeParkoPlace();
            Console.WriteLine("Car with number {0} goes out from parking", carNumber);
            isCarRemoved = true;

            return isCarRemoved;
        }
    }
}
