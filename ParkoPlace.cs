using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingProject
{
    class ParkoPlace
    {
        private bool freePlace = true;
        private Vehicle vehicleOnPlace = null;

        public bool GetStatusOfPlace()
        {
            return freePlace;
        }

        public Vehicle GetCarInPlace()
        {   
            return vehicleOnPlace;
        }

        public void TakeParkoPlace(Vehicle vehicle)
        {
            freePlace = false;
            vehicleOnPlace = vehicle;
        }

        public void UntakeParkoPlace()
        {
            freePlace = true;
            vehicleOnPlace = null;
        }
    }
}
