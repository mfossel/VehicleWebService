using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using VehicleWebService.API.Data;
using VehicleWebService.CORE;

namespace VehicleWebService.API.Controllers
{
    public class VehiclesController : ApiController
    {

        public VehiclesController() { }

        public VehiclesController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        private readonly IVehicleRepository _vehicleRepository;


        // GET: api/Vehicles
        public IEnumerable<Vehicle> GetVehicles()
        {

            return _vehicleRepository.GetAll();

        }

        // GET: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult GetVehicle(int id)
        {

            var vehicle = _vehicleRepository.Get(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);

        }


        // PUT: api/Vehicles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicle(Vehicle vehicle)
        {

            var existingEntity = _vehicleRepository.Get(vehicle.Id);

            if (existingEntity == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _vehicleRepository.Update(vehicle);
            return StatusCode(HttpStatusCode.NoContent);

        }


        // POST: api/Vehicles
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult PostVehicle(Vehicle vehicle)
        {

            if (vehicle.Make == null || vehicle.Model == null)
            {
                throw new Exception("Make and Model required.");
            }

            if (vehicle.Year < 1950 || vehicle.Year >2050)
            {
                throw new Exception("Vehicle year must be between 1950 and 2050.");
            }

            var result = _vehicleRepository.Add(vehicle);
            return CreatedAtRoute("DefaultApi", new { id = vehicle.Id }, vehicle);

        }


        // DELETE: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult DeleteVehicle(int id)
        {

            var vehicle = _vehicleRepository.Get(id);

            _vehicleRepository.Delete(vehicle);

            return Ok(vehicle);

        }

    }

}