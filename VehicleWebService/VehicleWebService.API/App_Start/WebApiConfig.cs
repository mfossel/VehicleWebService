using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;


namespace VehicleWebService.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var rules = new EnableCorsAttribute("*", "*", "*");

            config.EnableCors(rules);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //SET API TO RETURN JSON INSTEAD OF XML
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);


        }
    }
}
