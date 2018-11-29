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
        List<Payment> GetPayments(int id);
        Vehicle Get(int id);
        Vehicle Create(Vehicle vehicle);
        Vehicle Update(Vehicle vehicle);
    }
}
