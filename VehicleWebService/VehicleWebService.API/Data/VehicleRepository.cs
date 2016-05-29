using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleWebService.CORE;

namespace VehicleWebService.API.Data
{
    public class VehicleRepository : IVehicleRepository
    {

        private readonly IRedisClient _redisClient;

        public VehicleRepository(IRedisClient redisClient)
        {
            _redisClient = redisClient;
        }

        //Create

        public Vehicle Add(Vehicle vehicle)
        {
            var typedClient = _redisClient.As<Vehicle>();

            return typedClient.Store(vehicle);
        }

        //Retrieve
        public Vehicle Get(int id)
        {
            var typedClient = _redisClient.As<Vehicle>();

            return typedClient.GetById(id);
        }
        
        public IList<Vehicle> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

     

        public void Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}