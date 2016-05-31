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


        public Vehicle Add(Vehicle vehicle)
        {
            var typedClient = _redisClient.As<Vehicle>();

            //Auto increment Id
            vehicle.Id = (int)typedClient.GetNextSequence();

            return typedClient.Store(vehicle);
        }

        public Vehicle Update(Vehicle vehicle)
        {
            var typedClient = _redisClient.As<Vehicle>();

            return typedClient.Store(vehicle);
        }


        public Vehicle Get(int id)
        {
            var typedClient = _redisClient.As<Vehicle>();

            return typedClient.GetById(id);
        }
        
        public IList<Vehicle> GetAll()
        {
            var typedClient = _redisClient.As<Vehicle>();

            return typedClient.GetAll();
        }

        public void Delete(Vehicle vehicle)
        {
            var typedClient = _redisClient.As<Vehicle>();

            typedClient.Delete(vehicle);

        }    



    }
}