using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VehicleWebService.API.Data;
using VehicleWebService.CORE;

namespace VehicleWebService.API.Controllers
{
    public class VehiclesController : ApiController
    {
        private IVehicleRepository @object;

        public VehiclesController() { }

        public VehiclesController(IVehicleRepository @object)
        {
            this.@object = @object;
        }

        public IVehicleRepository VehicleRepository { get; set; }


        // GET: api/Vehicles
        public IList<Vehicle> GetVehicles()
        {

            return VehicleRepository.GetAll();

        }

        //public IEnumerable<Vehicle> GetVehicles(string make, string model)
        //{

        //    IEnumerable<Vehicle> vehicles = VehicleRepository.GetAll();

        //    // Check for Vehicle make input
        //    if (!string.IsNullOrEmpty(make)) vehicles = vehicles.Where(v => v.Make == make);

        //    // Check for Vehicle model input
        //    if (!string.IsNullOrEmpty(model)) vehicles = vehicles.Where(v => v.Model == model);

        //    return vehicles;

        //}


        // GET: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult GetVehicle(int id)
        {

            var vehicle = VehicleRepository.Get(id);

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

            var existingEntity = VehicleRepository.Get(vehicle.Id);

            if (existingEntity == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            VehicleRepository.Update(vehicle);
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

            var result = VehicleRepository.Add(vehicle);
            return CreatedAtRoute("DefaultApi", new { id = vehicle.Id }, vehicle);

        }

        // DELETE: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult DeleteVehicle(int id)
        {

            var vehicle = VehicleRepository.Get(id);

            VehicleRepository.Delete(vehicle);

            return Ok(vehicle);

        }

    }

}