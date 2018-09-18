using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiclesTrackingApi.Models;
using VehiclesTrackingApi.Services;

namespace VehiclesTrackingApi.Controllers
{
    [Route("api/[controller]")]
    public class VehiclesController : Controller
    {
        private readonly IVehicleService _vehicleService;
        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET api/vehicles
        [HttpGet]
        public IActionResult Get()
        {
            List<Vehicle> vehicles = _vehicleService.GetVehicles();
            return new JsonResult(vehicles);
        }

        // GET api/vechiles/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Vehicle vehicle = _vehicleService.GetVehicleById(id);
            return new JsonResult(vehicle);
        }

        // Post api/vehicles
        [HttpPost]
        public IActionResult Create([FromBody] Vehicle vehicle)
        {
            Vehicle createdVehicle = _vehicleService.CreateVehicle(vehicle);
            return new JsonResult(createdVehicle);
        }

        // Put api/vehicles
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] Vehicle vehicle)
        {
            Vehicle updateVehicle = _vehicleService.UpdateVehicle(id, vehicle);
            return new JsonResult(updateVehicle);
        }
    }
}
