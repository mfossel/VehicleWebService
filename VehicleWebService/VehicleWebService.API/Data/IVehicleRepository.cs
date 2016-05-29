using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleWebService.CORE;

namespace VehicleWebService.API.Data
{
    public interface IVehicleRepository
    {

        //Create, Update
        Vehicle Add(Vehicle vehicle);

        //Read
        IList<Vehicle> GetAll();
        Vehicle Get(int id);

        // DELETE
        void Delete(Vehicle vehicle);
    }
}
