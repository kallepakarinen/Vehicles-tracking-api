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
        private readonly VehicleDbContext _context;

        public VehicleRepository(VehicleDbContext context)
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

        public Vehicle Create(Vehicle vehicle)
        {
            _context.Vehicle.Add(vehicle);
            _context.SaveChanges();
            return vehicle;
        }

        public Vehicle Update(Vehicle vehicle)
        {
            _context.Vehicle.Update(vehicle);
            _context.SaveChanges();
            return vehicle;
        }
    }
}
