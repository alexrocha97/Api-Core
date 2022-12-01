using Application.Common.Erros;
using Application.Servicos.Autenticacoes;
using Application.Servicos.Interfaces.Commamd;
using Application.Servicos.Interfaces.Queries;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Web.Autenticacao;

namespace Web.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuteCommandServico _AuteCommandServico;
        private readonly IAuteQueryServico _AuteQueryServico;
        public AuthController(IAuteQueryServico AuteQueryService, IAuteCommandServico AuteCommandServico)
        {
            _AuteQueryServico = AuteQueryService;
            _AuteCommandServico = AuteCommandServico;
        }

        [HttpPost("registro")]
        public IActionResult Registro(RegisterSolicitar registerSolicitar)
        {
            Result<AuteResult> registerResult = _AuteCommandServico.Registro
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

        [HttpPost("login")]
        public IActionResult Login(LoginSolicitar loginSolicitar)
        {
            Result<AuteResult> LoginResult = _AuteQueryServico.Login(
                loginSolicitar.Email,
                loginSolicitar.Password
            );

            if(LoginResult.IsSuccess){
                return Ok(MapAuthResultLogin(LoginResult.Value));
            }

            var fistErrorLogin = LoginResult.Errors[0];
            if(fistErrorLogin is SenhaIncorretaError){
                return Problem(
                    statusCode: StatusCodes.Status409Conflict,
                    detail: fistErrorLogin.Message
                );
            }else if(fistErrorLogin is EmailIncorretoError){
                 return Problem(
                    statusCode: StatusCodes.Status409Conflict,
                    detail: fistErrorLogin.Message
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

        private static AutenticacaoReposta MapAuthResultLogin(AuteResult auteResult){
            
            return new AutenticacaoReposta(
                auteResult.user.Id,
                auteResult.user.FirstName,
                auteResult.user.LastName,
                auteResult.user.Email,
                auteResult.Token
            );
        }
    }
}
