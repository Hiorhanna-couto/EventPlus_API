using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventosRepository;
        public EventoController(IEventoRepository eventosRepository)
        {
            _eventosRepository = eventosRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Eventos> listaDeEventos = _eventosRepository.Listar();
                return Ok(listaDeEventos);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(Eventos novoEvento)
        {
            try
            {
                _eventosRepository.Cadastrar(novoEvento);
                return Created();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [Authorize]
        [HttpPut("id")]
        public IActionResult Put(Guid id, Eventos eventos)
        {
            try
            {
                _eventosRepository.Atualizar(id, eventos);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);

            }
        }
        [Authorize]
        [HttpDelete("id")]

        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventosRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<Eventos> ListarPorId = _eventosRepository.ListarPorId(id);
                return Ok(ListarPorId);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Eventos eventoBuscado = _eventosRepository.BuscarPorId(id);
                return Ok(eventoBuscado);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAction(Guid idProximoEvento)
        {
            try
            {
                List<Eventos> ListarProximoEvento = _eventosRepository.ListarProximosEventos(idProximoEvento);
                return Ok(ListarProximoEvento);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

    }
}
