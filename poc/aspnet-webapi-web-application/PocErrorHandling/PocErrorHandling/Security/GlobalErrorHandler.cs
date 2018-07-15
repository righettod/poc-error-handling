using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace PocErrorGandling.Security
{
    /// <summary>
    /// Global handler used to handle any error that occurs at application wide level
    /// </summary>
    public class GlobalErrorHandler : ExceptionHandler
    {
        /// <summary>
        /// Method in charge of handle the generic response send in case of error
        /// </summary>
        /// <param name="context">Error context</param>
        public override void Handle(ExceptionHandlerContext context)
        {  
            context.Result = new GenericResult();              
        }

        /// <summary>
        /// Class used to represent the generic response send
        /// </summary>
        private class GenericResult : IHttpActionResult
        {
            /// <summary>
            /// Method in charge of creating the generic response
            /// </summary>
            /// <param name="cancellationToken">Object to cancel the task</param>
            /// <returns>A task in charge of sending the generic response</returns>
            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                //We build a generic response with a JSON format because we are in a REST API app context
                //We also add an HTTP response header to indicate to the client app that the response is an error
                var responseBody = new Dictionary<String, String> { { "message", "An error occur, please retry" } };
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Headers.Add("X-ERROR", "true");
                response.Content = new StringContent(JsonConvert.SerializeObject(responseBody), Encoding.UTF8, "application/json");
                return Task.FromResult(response);
            }
        }
    }
}