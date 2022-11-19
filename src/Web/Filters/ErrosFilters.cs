using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Filters
{
    public class ErrosFilters : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var DetalheDoErro = new ProblemDetails
            {
                /*
                    6.6.1 - 500
                    6.6.2 - 501
                    6.6.3 - 502
                */
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title = "Ocorreu um erro inesperado, tente novamente mais tarde",
                // Instance = context.HttpContext.Request.Path,
                Status = (int)HttpStatusCode.InternalServerError
            };

            context.Result = new ObjectResult(DetalheDoErro);

            context.ExceptionHandled = true;
        }
    }
}