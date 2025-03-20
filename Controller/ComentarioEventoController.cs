using EventPlus_.Domains;
using EventPlus_.Interfaces;
using EventPlus_.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioEventoController : ControllerBase
    {
        private readonly IComentarioEventoRepository _comentarioEventoRepository;


        public ComentarioEventoController(IComentarioEventoRepository comentarioEventorepository)
        {
            _comentarioEventoRepository = comentarioEventorepository;
        }

       
        [Authorize]
        [HttpPost]

        public IActionResult Post(ComentarioEvento novoComentarioEvento)
        {
            try
            {
                _comentarioEventoRepository.Cadastrar(novoComentarioEvento);
                return Created();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        private void Cadastrar(ComentarioEvento novoComentarioEvento)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpDelete("{idComentario}")]
        public IActionResult Delete(Guid idComentario)
        {
            try
            {
                _comentarioEventoRepository.Deletar(idComentario);
                return NoContent();

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<ComentarioEvento> listaDeComentarios = _comentarioEventoRepository.Listar();
                return Ok(listaDeComentarios);

            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpGet("BuscarPorIdUsuario/{id}")]
        public IActionResult GetById(Guid UsuarioId, Guid EventosId)
        {
            try
            {
                ComentarioEvento comentarioBuscado = _comentarioEventoRepository.BuscarPorIdUsuario(UsuarioId, EventosId);
                return Ok(comentarioBuscado);
               
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

    }
}






