using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Buddy.AspNetCore.Filter
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public GlobalExceptionFilter()
        {

        }

        public void OnException(ExceptionContext context)
        {
            var statusCode = (int?)HttpStatusCode.InternalServerError;
            
            context.Result = new ObjectResult(new ErrorResponse { Message = context.Exception.Message, StackTrace = context.Exception.StackTrace})
            {
                StatusCode = statusCode,
                DeclaredType = typeof(ErrorResponse)
            };
        }
    }
}
