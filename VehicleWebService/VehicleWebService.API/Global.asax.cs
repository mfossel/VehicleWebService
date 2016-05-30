using Autofac;
using Autofac.Integration.WebApi;
using ServiceStack.Redis;
using System.Reflection;
using System.Web.Http;
using VehicleWebService.API.Data;

namespace VehicleWebService.API
{

    public class WebApiApplication : System.Web.HttpApplication
    {
        public IRedisClientsManager ClientsManager;
        private const string RedisUri = "CmlTJScXSQDqn5sz3HcC+kzGFDFrtMpBIr3Ycmi0U+A=@VehicleDataStore.redis.cache.windows.net?ssl=true";

        protected void Application_Start()
        {
            ClientsManager = new PooledRedisClientManager(RedisUri);


            WebApiConfig.Register(GlobalConfiguration.Configuration);
            ConfigureDependencyResolver(GlobalConfiguration.Configuration);

         GlobalConfiguration.Configuration.EnsureInitialized();

        }

        private void ConfigureDependencyResolver(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly())
                .PropertiesAutowired();

            builder.RegisterType<VehicleRepository>()
                .As<IVehicleRepository>()
                .PropertiesAutowired()
                .InstancePerApiRequest();

            builder.Register<IRedisClient>(c => ClientsManager.GetClient())
                .InstancePerApiRequest();

            configuration.DependencyResolver
                = new AutofacWebApiDependencyResolver(builder.Build());
        }

        protected void Application_OnEnd()
        {
            ClientsManager.Dispose();
        }

    }
}