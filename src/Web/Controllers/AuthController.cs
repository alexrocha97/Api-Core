using Application.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.Autenticacao;

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
            var auteResult = _AuteServico.Registro(
                registerSolicitar.FirstName,
                registerSolicitar.LastName,
                registerSolicitar.Email,
                registerSolicitar.Password
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
