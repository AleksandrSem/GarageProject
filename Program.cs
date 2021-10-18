using System;
using System.Linq;

namespace ParkingProject
{

    class Program
    {
        static void Main(string[] args)
        {
            //Check number of free places in Parking
            MyDelegate myDelegate = new MyDelegate(Parking.GetQuantityFreePlacesInParking);
            myDelegate.Invoke();

            //Park N number cars in Parking
            Parking.CreateCarsPull();
            myDelegate.Invoke();
            Parking.GetCarsInfoInParking();

            //Remove car from parking
            Console.Write("Which car should be removed from Parking. Enter car Number = ");
            string carNumber = Console.ReadLine();
            Parking.CarRemovedFromParking(carNumber);

            //Info
            myDelegate.Invoke();
            Parking.GetCarsInfoInParking();
        }
    }
}
