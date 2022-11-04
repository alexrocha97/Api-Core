using Aplication.Model;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            try
            {
                return Ok("Hello Word!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
