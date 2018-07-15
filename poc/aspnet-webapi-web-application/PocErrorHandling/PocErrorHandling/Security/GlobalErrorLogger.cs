using System;
using System.Web.Http.ExceptionHandling;

namespace PocErrorGandling.Security
{
    /// <summary>
    /// Global logger used to trace any error that occurs at application wide level
    /// </summary>
    public class GlobalErrorLogger : ExceptionLogger
    {
        /// <summary>
        /// Method in charge of the management of the error from a tracing point of view
        /// </summary>
        /// <param name="context">Context containing the error details</param>
        public override void Log(ExceptionLoggerContext context)
        {
            //Get the exception
            Exception exception = context.Exception;
            //Log the exception via the content of the variable named "exception" if it is not NULL
            //...
        }
    }
}