using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagementApp
{
    public interface IParkingLot
    {
        /// <summary>
        /// Method to park vehicle for availale parking slot
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IParkingSlot ParkVehicle(VehicleType type);

        /// <summary>
        /// Method to left parking slot
        /// </summary>
        /// <param name="slotNumber"></param>
        /// <returns></returns>
        bool LeaveParking(int slotNumber);

        /// <summary>
        /// Check if VehicleType fits for the available parking slot
        /// </summary>
        /// <returns></returns>
        List<IParkingSlot> GetAvailableSlots();
    }
}
