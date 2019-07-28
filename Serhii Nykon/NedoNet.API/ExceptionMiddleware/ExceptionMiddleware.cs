using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace NedoNet.API.Exceptions {
    public class ExceptionMiddleware {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware( RequestDelegate next ) {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try {
                await _next.Invoke( context );
            }
            catch (Exception e) {
                await HandleExceptionAsync( context, e );
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            var customException = exception as CustomExceptionBase;
            var statusCode = StatusCodes.Status500InternalServerError;
            var message = "Unexpected error";
            object body = null;

            if (null != customException) {
                message = customException.Message;   
                body = customException.Body;
                statusCode = customException.Code;
            }

            response.ContentType = "application/json";
            response.StatusCode = statusCode;
            await response.WriteAsync(JsonConvert.SerializeObject(new CustomErrorResponse
            {
                Message = message,
                Body = body
            }));
        }
    }
}