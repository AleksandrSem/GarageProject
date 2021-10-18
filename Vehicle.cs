using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingProject
{
    class Vehicle
    {
        private string carName;
        private string carNumber;
        private bool carAccess;

        private static Random random = new Random();

        public Vehicle()
        {
            string[] values = { "Cargo", "Car", "Minibus" };
            carName = values[random.Next(0, values.Length)];
            carNumber = RandomNumber(5);
            carAccess = random.NextDouble() > 0.5;
        }

        public string RandomNumber(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string GetCarName()
        {
            return carName;
        }

        public string GetCarNumber()
        {
            return carNumber;
        }

        public bool GetCarAccess()
        {
            return carAccess;
        }

        public void SetCarNumber(string carInputNumber)
        {
            carNumber = carInputNumber;
        }

        public void SetCarName(string carInputName)
        {
            carNumber = carInputName;
        }
    }
}
