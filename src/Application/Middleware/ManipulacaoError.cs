using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Application.Middleware
{
    public class ManipulacaoError
    {
        private readonly RequestDelegate _next;
        public ManipulacaoError(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code  = HttpStatusCode.InternalServerError; // Status 500
            var result = JsonSerializer.Serialize(new { error = "Ocorreu um erro!" });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}