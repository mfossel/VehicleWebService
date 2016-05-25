using System.Data.Entity;
using VehicleWebService.CORE;

namespace VehicleWebService.API
{
    public class VehicleWebServiceDataContext : DbContext
    {

        public VehicleWebServiceDataContext()
        {
        }

        //SQL TABLES
        public IDbSet<Vehicle> Vehicles { get; set; }


    }

}
