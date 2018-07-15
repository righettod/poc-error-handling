using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PocErrorGandling
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /*
        protected void Application_Error(object sender, EventArgs e)
        {
            //Get the exception
            Exception exception = Server.GetLastError();
            //Log the exception via the content of the variable named "exception" if it is not NULL
            //...
            //We build a generic response with a JSON format because we are in a REST API app context
            //We also add an HTTP response header to indicate to the client app that the response is an error
            var responseBody = new Dictionary<String, String> { { "message", "An error occur, please retry" } };
            Response.Clear();
            Response.AddHeader("X-ERROR", "true");
            Response.ContentEncoding = Encoding.UTF8 ; 
            Response.ContentType = "application/json";
            Response.StatusCode = (int)HttpStatusCode.OK;
            Response.Write(JsonConvert.SerializeObject(responseBody));
        }
        */
    }
}
