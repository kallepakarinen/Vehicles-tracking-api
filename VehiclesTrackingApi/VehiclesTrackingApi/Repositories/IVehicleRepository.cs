using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesTrackingApi.Models;

namespace VehiclesTrackingApi.Repositories
{
    public interface IVehicleRepository
    {
        List<Vehicle> Get();
        Vehicle Get(int id);
    }
}
