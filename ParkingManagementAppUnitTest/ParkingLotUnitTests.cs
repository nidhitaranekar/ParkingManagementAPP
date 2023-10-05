using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ParkingManagementApp;

namespace ParkingManagementAppUnitTest
{
    public class ParkingLotUnitTests
    {
        [Fact]
        public void ParkingLot_Vehicle_should_Park()
        {
            //arrange
            var parkingLot = new ParkingLot(5, 3, 2);
            var vehicleType = VehicleType.Sedan;

            //act
            var parkedSlot = parkingLot.ParkVehicle(vehicleType);

            //assert
            Assert.NotNull(parkedSlot);
            Assert.True(parkedSlot.IsOccupied);
        }

        [Fact]
        public void ParkVehicle_Should_Return_Null_If_No_Slots_Available()
        {
            //arrange
            var parkingLot = new ParkingLot(0, 0, 0);
            var vehicleType = VehicleType.SUV;

            //Act
            var parkedSlot = parkingLot.ParkVehicle(vehicleType);

            //Assert
            Assert.Null(parkedSlot);
        }

        [Fact]
        public void LeaveParking_Vehicle_should_Leave_Parking()
        {
            // Arrange
            var parkingLot = new ParkingLot(5, 3, 2);
            var vehicleType = VehicleType.Sedan;
            var parkedSlot = parkingLot.ParkVehicle(vehicleType);

            // Act
            var leaveParking = parkingLot.LeaveParking(parkedSlot.SlotNumber);

            // Assert
            Assert.True(leaveParking);
            Assert.False(parkedSlot.IsOccupied);
        }
        [Fact]
        public void LeaveParking_Should_Return_False_If_Slot_Not_Found()
        {
            // Arrange
            var parkingLot = new ParkingLot(5, 3, 2);

            // Act
            var result = parkingLot.LeaveParking(99);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetAvailableSlots_Should_Return_List_Of_Available_Slots()
        {
            // Arrange
            var parkingLot = new ParkingLot(5, 3, 2);
            var vehicleType = VehicleType.Sedan;
            parkingLot.ParkVehicle(vehicleType);

            // Act
            var availableSlots = parkingLot.GetAvailableSlots();

            // Assert
            Assert.NotNull(availableSlots);
            Assert.True(availableSlots.Count > 0);
            Assert.False(availableSlots.Exists(slot => slot.IsOccupied));
        }
    }
}
