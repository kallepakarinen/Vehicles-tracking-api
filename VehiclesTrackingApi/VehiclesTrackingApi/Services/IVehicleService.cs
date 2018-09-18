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
    }
}
