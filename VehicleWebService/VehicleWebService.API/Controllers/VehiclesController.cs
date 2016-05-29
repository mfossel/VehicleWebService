using StackExchange.Redis;
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
        //private VehicleWebServiceDataContext db = new VehicleWebServiceDataContext();
        public IVehicleRepository VehicleRepository { get; set; }



        // GET: api/Vehicles
        //public IQueryable<Vehicle> GetVehicles(string make, string model)
        //{
        //    IQueryable<Vehicle> vehicles = db.Vehicles;

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

        //// PUT: api/Vehicles/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutVehicle(int id, Vehicle vehicle)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != vehicle.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(vehicle).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!VehicleExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Vehicles
        [ResponseType(typeof(Vehicle))]
        public HttpResponseMessage PostVehicle(Vehicle vehicle)
        {

            var result = VehicleRepository.Add(vehicle);
            return Request.CreateResponse(HttpStatusCode.Created, result);

        }

        // DELETE: api/Vehicles/5
        //[ResponseType(typeof(Vehicle))]
        //public IHttpActionResult DeleteVehicle(int id)
        //{
        //    Vehicle vehicle = db.Vehicles.Find(id);
        //    if (vehicle == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Vehicles.Remove(vehicle);
        //    db.SaveChanges();

        //    return Ok(vehicle);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool VehicleExists(int id)
        //{
        //    return db.Vehicles.Count(e => e.Id == id) > 0;
        //}
    }
}