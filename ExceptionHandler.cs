using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagementApp
{
    public class ExceptionHandler
    {
        /// <summary>
        /// Global exception handler
        /// </summary>
        public static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;
            if (exception != null)
            {
                Console.WriteLine("Unhandled Exception: " + exception.Message);
            }
            Environment.Exit(1);
        }
    }
}
