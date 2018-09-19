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

        public Vehicle GetVehicleById(int id)
        {
            return _vehicleRepository.Get(id);
        }

        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            return _vehicleRepository.Create(vehicle);
        }

        public Vehicle UpdateVehicle(int id, Vehicle vehicle)
        {
            var savedVehicle = _vehicleRepository.Get(id);
            if (savedVehicle == null)
            {
                throw new Exception("Vehicle not found");
            }
            else
            {
                return _vehicleRepository.Update(vehicle);
            }
        }
    }
}
