using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesTrackingApi.Models;

namespace VehiclesTrackingApi.Services
{
    public interface IVehicleService
    {
        List<Vehicle> GetVehicles();
        List<Payment> GetPayments(int id);
        Vehicle GetVehicleById(int id);
        Vehicle CreateVehicle(Vehicle vehicle);
        Vehicle UpdateVehicle(int id, Vehicle vehicle);
    }
}
