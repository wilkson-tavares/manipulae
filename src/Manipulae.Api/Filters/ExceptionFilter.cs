using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Manipulae.Exception.ExceptionBase;
using Manipulae.Domain.Responses.Error;

namespace Manipulae.Api.Filters
{
    /// <summary>
    /// Filter
    /// </summary>
    public class ExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// Exception treatment
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ManipulaeException)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnknownError(context);
            }
        }

        private static void HandleProjectException(ExceptionContext context)
        {
            var manipulaeException = context.Exception as ManipulaeException;
            var errorResponse = new ErrorResponse(manipulaeException!.GetErrors());

            context.HttpContext.Response.StatusCode = manipulaeException.StatusCode;
            context.Result = new ObjectResult(errorResponse);
        }

        private static void ThrowUnknownError(ExceptionContext context)
        {
            var errorResponse = new ErrorResponse("UNKNOWN_ERROR");

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}
