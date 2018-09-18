using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesTrackingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace VehiclesTrackingApi.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicledbContext _context;

        public VehicleRepository(VehicledbContext context)
        {
            _context = context;
        }

        public List<Vehicle> Get()
        {
            return _context.Vehicle.AsNoTracking().ToList();
        }

    }
}
