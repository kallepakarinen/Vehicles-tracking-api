using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesTrackingApi.Models;
using VehiclesTrackingApi.Repositories;

namespace VehiclesTrackingApi.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository VehicleRepository)
        {
            _vehicleRepository = VehicleRepository;
        }
           public List<Vehicle> GetVehicles()
        {
            return _vehicleRepository.Get();
        }
    }
}
