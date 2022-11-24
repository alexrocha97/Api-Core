using Application.Common.Erros;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            // var (statusCode, message) = exception switch
            // {
            //     IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            //     _ => (StatusCodes.Status500InternalServerError, "Um erro inesperado ocorreu."),
            // };

            // return Problem(statusCode: statusCode, title: message);
            return Problem();
        }
    }
}