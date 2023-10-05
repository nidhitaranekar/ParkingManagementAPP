using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagementApp
{
    public class ParkingService : IParkingService
    {
        private readonly IServiceCollection _services;
        private IServiceProvider _provider;

        public ParkingService()
        {
            _services = new ServiceCollection();
            ConfigureServices();
        }

        /// <summary>
        /// Configure the services
        /// </summary>
        private void ConfigureServices()
        {
            _services.AddSingleton<IParkingLot>(_ => new ParkingLot(5, 3, 2));
        }

        /// <summary>
        /// Resolve and Get instance of registered services
        /// </summary>
        /// <returns></returns>
        public IParkingLot GetParkingLot()
        {
            if (_provider == null)
            {
                _provider = _services.BuildServiceProvider();
            }
            return _provider.GetService<IParkingLot>();
        }
    }
}
