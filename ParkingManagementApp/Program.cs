using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using ParkingManagementApp;

public class Program
{
    private static IParkingService parkingService;

   

    static void Main(string[] args)
    {
        AppDomain.CurrentDomain.UnhandledException += ExceptionHandler.UnhandledExceptionHandler;
        
        parkingService = new ParkingService();
        var parkingLot = parkingService.GetParkingLot();

        while (true)
        {
            Console.WriteLine("1. Park Vehicle");
            Console.WriteLine("2. Leave Parking");
            Console.WriteLine("3. Get Available Slots");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Vehicle Type (0: Hatchback, 1: Sedan, 2: Compact SUV, 3: SUV, 4: Large Car): ");
                    VehicleType vehicleType = (VehicleType)Enum.Parse(typeof(VehicleType), Console.ReadLine());
                    IParkingSlot parkedSlot = parkingLot.ParkVehicle(vehicleType);
                    if (parkedSlot != null)
                    {
                        Console.WriteLine($"Parked in Slot {parkedSlot.SlotNumber}");
                    }
                    else
                    {
                        Console.WriteLine("No available slots for this vehicle type.");
                    }
                    break;

                case 2:
                    Console.Write("Enter Slot Number to Leave Parking: ");
                    int slotNumber = int.Parse(Console.ReadLine());
                    if (parkingLot.LeaveParking(slotNumber))
                    {
                        Console.WriteLine($"Left Slot {slotNumber}");
                    }
                    else
                    {
                        Console.WriteLine("Parking is empty for this slot or Invalid slot number.");
                    }
                    break;

                case 3:
                    List<IParkingSlot> availableSlots = parkingLot.GetAvailableSlots();
                    Console.WriteLine("Available Parking Slots:");
                    foreach (var slot in availableSlots)
                    {
                        Console.WriteLine($"Slot {slot.SlotNumber} ({slot.ParkingSlotType})");
                    }
                    break;

                case 4:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid Selection. Please try again.");
                    break;
            }
        }
    }
}