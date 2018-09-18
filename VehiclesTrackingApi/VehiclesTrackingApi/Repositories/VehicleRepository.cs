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
        private readonly VehiclesDbContext _context;

        public VehicleRepository(VehiclesDbContext context)
        {
            _context = context;
        }

        public List<Vehicle> Get()
        {
            return _context.Vehicle.AsNoTracking().ToList();
        }

        public Vehicle Get(int id)
        {
            return _context.Vehicle.AsNoTracking().FirstOrDefault(v => v.Id == id);
        }
     
   
    }
}
