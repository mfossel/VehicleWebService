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

        //Create
        Vehicle Add(Vehicle vehicle);

        //Update
        Vehicle Update(Vehicle vehicle);

        //Read
        IList<Vehicle> GetAll();
        Vehicle Get(int id);

        // Delete
        void Delete(Vehicle vehicle);

    }
}
