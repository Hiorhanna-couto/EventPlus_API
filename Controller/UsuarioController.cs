using EventPlus_.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioRepository? _tipoUsuarioRepository;

        public UsuarioController(ITipoUsuarioRepository tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }

    
        [HttpPost]

        public IActionResult Post(UsuarioController usuariocontroller)
        {

        }

    }

}
