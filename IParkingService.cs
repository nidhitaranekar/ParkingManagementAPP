using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagementApp
{
    /// <summary>
    /// Create parking space -> 50 small, 30 Medium and 20 Large Parking slot
    /// </summary>
    public interface IParkingService
    {
        IParkingLot GetParkingLot();
    }
}
