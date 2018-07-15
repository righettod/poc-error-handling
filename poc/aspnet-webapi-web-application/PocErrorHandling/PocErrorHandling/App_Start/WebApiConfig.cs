using PocErrorGandling.Security;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace PocErrorGandling
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Register global error logging and handling handlers
            config.Services.Replace(typeof(IExceptionLogger), new GlobalErrorLogger());
            config.Services.Replace(typeof(IExceptionHandler), new GlobalErrorHandler());


            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
