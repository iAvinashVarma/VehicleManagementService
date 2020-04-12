using System.Net.Http.Headers;
using System.Web.Http;

namespace VehicleManagementSystemApi
{
    /// <summary>
    /// Web Api Configuration
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Web Api Configuration Registration
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultCatchall",
                routeTemplate: "api/{*url}",
                defaults: new
                {
                    controller = "Error",
                    action = "404"
                }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.XmlFormatter.UseXmlSerializer = true;
        }
    }
}
