using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagementApp
{
    public interface IParkingSlot
    {
        /// <summary>
        /// Parking slot number 1-100
        /// </summary>
        int SlotNumber { get; }

        /// <summary>
        /// Parking slots - small, medium, large
        /// </summary>
        SlotType ParkingSlotType { get; }

        /// <summary>
        /// Slot is available or empty
        /// </summary>
        bool IsOccupied { get; set; }
    }
}
