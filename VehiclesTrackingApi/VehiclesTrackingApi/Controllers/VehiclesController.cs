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

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
