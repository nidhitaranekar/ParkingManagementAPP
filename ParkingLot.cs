using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagementApp
{
    public enum VehicleType
    {
        Hatchback,
        Sedan,
        CompactSUV,
        SUV,
        LargeCar
    }
    public class ParkingLot : IParkingLot
    {
        private List<IParkingSlot> slots;

        /// <summary>
        /// Create Parking Space --  50 small, 30 Medium and 20 Large Parking slot
        /// </summary>
        /// <param name="smallSlots"></param>
        /// <param name="mediumSlots"></param>
        /// <param name="largeSlots"></param>
        public ParkingLot(int smallSlots, int mediumSlots, int largeSlots)
        {
            slots = new List<IParkingSlot>();

            for (int i = 1; i <= smallSlots; i++)
            {
                slots.Add(new ParkingSlot { SlotNumber = i, ParkingSlotType = SlotType.Small });
            }

            for (int i = smallSlots + 1; i <= smallSlots + mediumSlots; i++)
            {
                slots.Add(new ParkingSlot { SlotNumber = i, ParkingSlotType = SlotType.Medium });
            }

            for (int i = smallSlots + mediumSlots + 1; i <= smallSlots + mediumSlots + largeSlots; i++)
            {
                slots.Add(new ParkingSlot { SlotNumber = i, ParkingSlotType = SlotType.Large });
            }
        }

        /// <summary>
        /// Park Vehicle -> If slot is available 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IParkingSlot ParkVehicle(VehicleType type)
        {
            foreach (var slot in slots)
            {
                if (!slot.IsOccupied && IsSlotCompatible(slot, type))
                {
                    slot.IsOccupied = true;
                    return slot; 
                }
            }
            return null; // No slot found
        }

        /// <summary>
        /// Left Parking, Make slot unoccupied
        /// </summary>
        /// <param name="slotNumber"></param>
        /// <returns></returns>
        public bool LeaveParking(int slotNumber)
        {
            var slot = slots.Find(s => s.SlotNumber == slotNumber);
            if (slot != null && slot.IsOccupied)
            {
                slot.IsOccupied = false;
                return true;
            }
            return false; // Slot not found or already empty
        }

        /// <summary>
        /// Fetch all available slot
        /// </summary>
        /// <returns></returns>
        public List<IParkingSlot> GetAvailableSlots()
        {
            return slots.FindAll(s => !s.IsOccupied);
        }

        /// <summary>
        /// Check if VehicleType fits for the available parking slot
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool IsSlotCompatible(IParkingSlot slot, VehicleType type)
        {
            if (type == VehicleType.Hatchback)
            {
                return true;
            }
            else if ((type == VehicleType.Sedan || type == VehicleType.CompactSUV) && (slot.ParkingSlotType == SlotType.Medium || slot.ParkingSlotType == SlotType.Large))
            {
                return true;
            }
            else if ((type == VehicleType.SUV || type == VehicleType.LargeCar) && slot.ParkingSlotType == SlotType.Large)
            {
                return true;
            }
            return false;
        }
    }
}
