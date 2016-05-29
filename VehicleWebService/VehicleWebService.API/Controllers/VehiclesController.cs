using StackExchange.Redis;
using System.Collections.Generic;
using System.Data;
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

        public IVehicleRepository VehicleRepository { get; set; }


        // GET: api/Vehicles
        public IEnumerable<Vehicle> GetVehicles(string make, string model)
        {
            IEnumerable<Vehicle> vehicles = VehicleRepository.GetAll();

            // Check for Vehicle make input
            if (!string.IsNullOrEmpty(make)) vehicles = vehicles.Where(v => v.Make == make);

            // Check for Vehicle model input
            if (!string.IsNullOrEmpty(model)) vehicles = vehicles.Where(v => v.Model == model);

                 return vehicles;

            }

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
        public HttpResponseMessage PutVehicle(int id, Vehicle vehicle)
        {

            var existingEntity = VehicleRepository.Get(id);

            if (existingEntity == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

           vehicle.Id = id;
            VehicleRepository.Add(vehicle);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // POST: api/Vehicles
        [ResponseType(typeof(Vehicle))]
        public HttpResponseMessage PostVehicle(Vehicle vehicle)
        {

            var result = VehicleRepository.Add(vehicle);
            return Request.CreateResponse(HttpStatusCode.Created, result);

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