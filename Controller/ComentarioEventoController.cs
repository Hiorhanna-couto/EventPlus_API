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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para deletar Feedbacks
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

       
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioEventoRepository.Deletar(id);
                return NoContent();

            }
            catch (Exception)
            {

                throw;
            }

        }
        // <summary>
        /// Endpoint para listar Feedbacks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_comentarioEventoRepository.Listar(id));

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar Feedbacks por Id dos usuarios
        /// </summary>
        /// <param name="UsuarioId"></param>
        /// <param name="EventoId"></param>
        /// <returns></returns>
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






