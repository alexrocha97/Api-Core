using Application.Common.Erros;
using Application.Servicos.Autenticacoes;
using Application.Servicos.Interfaces;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using Web.Autenticacao;
using Web.Filters;

namespace Web.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuteServico _AuteServico;
        public AuthController(IAuteServico AuteService)
        {
            _AuteServico = AuteService;
        }

        [HttpPost("registro")]
        public IActionResult Registro(RegisterSolicitar registerSolicitar)
        {
            Result<AuteResult> registerResult = _AuteServico.Registro
            (
                registerSolicitar.FirstName,
                registerSolicitar.LastName,
                registerSolicitar.Email,
                registerSolicitar.Password
            );

            if(registerResult.IsSuccess){
                return Ok(MapAuthResult(registerResult.Value));
            }

            var firstError = registerResult.Errors[0];
            if(firstError is DuplicateEmailError){
                return Problem(
                    statusCode: StatusCodes.Status409Conflict,
                    detail: firstError.Message
                );
            }

            return Problem();
        }

        private static AutenticacaoReposta MapAuthResult(AuteResult authResult)
        {
            return new AutenticacaoReposta(
                authResult.user.Id,
                authResult.user.FirstName,
                authResult.user.LastName,
                authResult.user.Email,
                authResult.user.Password
            );
        }

        [HttpPost("login")]
        public IActionResult Login(LoginSolicitar loginSolicitar)
        {
            var auteResult = _AuteServico.Login(
                loginSolicitar.Email,
                loginSolicitar.Password
            );

            var response = new AutenticacaoReposta(
                auteResult.user.Id,
                auteResult.user.FirstName,
                auteResult.user.LastName,
                auteResult.user.Email,
                auteResult.Token
            );

            return Ok(response);
        }
    }
}
