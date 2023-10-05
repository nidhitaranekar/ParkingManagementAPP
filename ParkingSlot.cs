using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagementApp
{
    public enum SlotType
    {
        Small,
        Medium,
        Large
    }
    public class ParkingSlot : IParkingSlot
    {
        /// <summary>
        /// Parking slot number 1-100
        /// </summary>
        public int SlotNumber { get; set; }

        /// <summary>
        /// Parking slots - small, medium, large
        /// </summary>
        public SlotType ParkingSlotType { get; set; }
        
        /// <summary>
        /// Slot is available or empty
        /// </summary>
        public bool IsOccupied { get; set; }
    }
}
